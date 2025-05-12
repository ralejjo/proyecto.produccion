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

namespace Client.ViewModel
{
    internal class CutStationViewModel : INotifyPropertyChanged
    {
        private bool _isReadOnly = true;
        private bool _canClickButton = false;

        public event PropertyChangedEventHandler PropertyChanged;

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

        public ICommand CutPieceCommand { get; private set; }
        public ICommand PutPieceOnProcessCommand { get; private set; }

        public event EventHandler RequestClose;
        public Action CloseAction { get; set; }
        public Action ShowPieceCutMessage { get; set; }

        public PieceDto Piece { get; set; }

        public StationDto Station { get; set; }
        public WorkOrderDto WorkOrder { get; set; }
        public PieceDto OrderedPiece { get; set; }
        public ColorDto Color { get; set; }
        public PieceTypeDto PieceType { get; set; }

        public CutStationViewModel()
        { 
            Piece = new PieceDto();
            WorkOrder = new WorkOrderDto();
            OrderedPiece = new PieceDto();
            Color = new ColorDto();
            PieceType = new PieceTypeDto();

            StationDto[] station = LibraryManagerInstance.Instance.cutStation.GetStationById((int)StationModel.Corte).ToArray();
            Station = station[0];

            CutPieceCommand = new RelayCommand(CutPiece, CanCutPiece);
            PutPieceOnProcessCommand = new RelayCommand(PutPieceOnProcess, CanPutPieceOnProcess);
        }

        private void CutPiece()
        {
            int newPieceId = LibraryManagerInstance.Instance.cutStation.ProcessPiece(Piece);
            PieceDto[] piece = LibraryManagerInstance.Instance.piece.GetById(newPieceId);
            Piece = piece[0];

            LibraryManagerInstance.Instance.cutStation.PutPieceOnExit(Station, Piece);
            StationDto[] station = LibraryManagerInstance.Instance.cutStation.GetStationById((int)StationModel.Corte).ToArray();
            Station = station[0];

            OnPropertyChanged(nameof(Piece));
            OnPropertyChanged(nameof(Station));
            ShowPieceCutMessage?.Invoke();
        }

        private bool CanCutPiece()
        {
            return true;
        }

        private void PutPieceOnProcess()
        {
            CanClickButton = true;
            IsReadOnly = false;

            PieceDto[] piece = LibraryManagerInstance.Instance.piece.GetById(Station.pieceIdOnEntry);
            this.Piece = piece[0];

            LibraryManagerInstance.Instance.cutStation.PutPieceOnProcess(Station, Piece);

            StationDto[] station = LibraryManagerInstance.Instance.cutStation.GetStationById((int)StationModel.Corte).ToArray();
            Station = station[0];

            WorkOrderDto[] workOrder = LibraryManagerInstance.Instance.workOrder.GetByPieceId(Station.pieceIdOnProcess);
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
