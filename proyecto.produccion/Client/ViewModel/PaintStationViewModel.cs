using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Client.ViewModel;
using Shared;
using Shared.DTO;
using Client.Command;
using System.Data.SqlClient;
using Client.Model;
using System.Collections.ObjectModel;

namespace Client.ViewModel
{
    internal class PaintStationViewModel : INotifyPropertyChanged
    {
        private bool _isReadOnly = true;
        private bool _canClickButton = false;

        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<ColorDto> _colorList;

        public bool IsReadOnly
        {
            get => _isReadOnly;
            set
            {
                _isReadOnly = value;
                OnPropertyChanged(nameof(IsReadOnly));
            }
        }

        public bool CanClickButton
        {
            get => _canClickButton;
            set
            {
                _canClickButton = value;
                OnPropertyChanged(nameof(CanClickButton));
            }
        }

        public ICommand PaintPieceCommand { get; private set; }
        public ICommand PutPieceOnProcessCommand { get; private set; }
        public ICommand AsyncGetColorListCommand { get; private set; }

        public event EventHandler RequestClose;
        public Action CloseAction { get; set; }
        public Action ShowPiecePaintMessage { get; set; }

        public PieceDto Piece { get; set; }

        public StationDto Station { get; set; }
        public WorkOrderDto WorkOrder { get; set; }
        public PieceDto OrderedPiece { get; set; }
        public ColorDto Color { get; set; }
        public PieceTypeDto PieceType { get; set; }
        public PieceOrderDto PieceOrder { get; set; }

        public PaintStationViewModel()
        { 
            Piece = new PieceDto();
            WorkOrder = new WorkOrderDto();
            OrderedPiece = new PieceDto();
            Color = new ColorDto();
            PieceType = new PieceTypeDto();

            StationDto[] station = LibraryManagerInstance.Instance.paintStation.GetStationById((int)StationModel.Pintura).ToArray();
            Station = station[0];

            PaintPieceCommand = new RelayCommand(PaintPiece, CanPaintPiece);
            PutPieceOnProcessCommand = new RelayCommand(PutPieceOnProcess, CanPutPieceOnProcess);
            AsyncGetColorListCommand = new AsyncRelayCommand(AsyncLoadColorList, CanLoadColorList);

            Init();
        }

        private async void Init()
        {
            await AsyncLoadColorList();
        }

        private void PaintPiece()
        {
            int newPieceId = LibraryManagerInstance.Instance.paintStation.ProcessPiece(Piece);
            PieceDto[] piece = LibraryManagerInstance.Instance.piece.GetById(newPieceId);
            Piece = piece[0];

            LibraryManagerInstance.Instance.paintStation.PutPieceOnExit(Station, Piece);
            StationDto[] station = LibraryManagerInstance.Instance.paintStation.GetStationById((int)StationModel.Pintura).ToArray();
            Station = station[0];

            OnPropertyChanged(nameof(Piece));
            OnPropertyChanged(nameof(Station));
            ShowPiecePaintMessage?.Invoke();
        }

        private bool CanPaintPiece()
        {
            return true;
        }

        private void PutPieceOnProcess()
        {
            CanClickButton = true;
            IsReadOnly = false;

            PieceDto[] piece = LibraryManagerInstance.Instance.piece.GetById(Station.pieceIdOnEntry);
            this.Piece = piece[0];

            LibraryManagerInstance.Instance.paintStation.PutPieceOnProcess(Station, Piece);

            StationDto[] station = LibraryManagerInstance.Instance.paintStation.GetStationById((int)StationModel.Pintura).ToArray();
            Station = station[0];

            PieceOrderDto[] pieceOrder = LibraryManagerInstance.Instance.pieceOrder.GetByPieceId(Station.pieceIdOnProcess);
            PieceOrder = pieceOrder[0];

            WorkOrderDto[] workOrder = LibraryManagerInstance.Instance.workOrder.GetById(PieceOrder.workOrderId);
            WorkOrder = workOrder[0];

            PieceDto[] orderedPiece = LibraryManagerInstance.Instance.piece.GetById(WorkOrder.pieceId);
            OrderedPiece = orderedPiece[0];

            ColorDto[] color = LibraryManagerInstance.Instance.color.GetAll().Where(c => c.id == OrderedPiece.colorId).ToArray();
            Color = color[0];

            PieceTypeDto[] pieceType = LibraryManagerInstance.Instance.pieceType.GetAll().Where(p => p.id == OrderedPiece.typeId).ToArray();
            PieceType = pieceType[0];

            OnPropertyChanged(nameof(Station));
            OnPropertyChanged(nameof(OrderedPiece));
            OnPropertyChanged(nameof(Color));
            OnPropertyChanged(nameof(PieceType));
        }

        private bool CanPutPieceOnProcess()
        {
            return true;
        }

        public ObservableCollection<ColorDto> ColorList
        {
            get { return _colorList; }
            set
            {
                _colorList = value;
                OnPropertyChanged("ColorList");
            }
        }

        private bool CanLoadColorList()
        {
            return true;
        }

        private void LoadColorList()
        {
            ColorDto[] colorList = LibraryManagerInstance.Instance.color.GetAll()
                .ToArray();

            if (colorList.Length > 0)
            {
                ColorList = new ObservableCollection<ColorDto>(colorList);
            }
        }

        private Task AsyncLoadColorList()
        {
            return Task.Run(LoadColorList);
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnRequestClose()
        {
            RequestClose?.Invoke(this, EventArgs.Empty);
        }
    }
}
