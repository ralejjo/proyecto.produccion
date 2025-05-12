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
    internal class QualityStationViewModel : INotifyPropertyChanged
    {
        private bool _canClickButton = false;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool CanClickButton
        {
            get => _canClickButton;
            set
            {
                _canClickButton = value;
                OnPropertyChanged(nameof(CanClickButton));
            }
        }

        public ICommand ApprovePieceCommand { get; private set; }
        public ICommand PutPieceOnProcessCommand { get; private set; }

        public event EventHandler RequestClose;
        public Action CloseAction { get; set; }
        public Action ShowApprovePieceMessage { get; set; }

        public PieceDto Piece { get; set; }

        public StationDto Station { get; set; }
        public WorkOrderDto WorkOrder { get; set; }
        public PieceDto OrderedPiece { get; set; }
        public PieceTypeDto PieceType { get; set; }
        public ColorDto Color { get; set; }
        public PieceOrderDto PieceOrder { get; set; }
        public ColorDto OrderedColor { get; set; }
        public PieceTypeDto OrderedPieceType { get; set; }

        public QualityStationViewModel()
        {
            Piece = new PieceDto();
            WorkOrder = new WorkOrderDto();
            OrderedPiece = new PieceDto();
            PieceType = new PieceTypeDto();

            StationDto[] station = LibraryManagerInstance.Instance.qualityStation.GetStationById((int)StationModel.Calidad).ToArray();
            Station = station[0];

            ApprovePieceCommand = new RelayCommand(ApprovePiece, CanApprovePiece);
            PutPieceOnProcessCommand = new RelayCommand(PutPieceOnProcess, CanPutPieceOnProcess);

        }

        private void ApprovePiece()
        {
            int newPieceId = LibraryManagerInstance.Instance.qualityStation.ProcessPiece(Piece);
            PieceDto[] piece = LibraryManagerInstance.Instance.piece.GetById(newPieceId);
            Piece = piece[0];

            LibraryManagerInstance.Instance.qualityStation.PutPieceOnExit(Station, Piece);
            StationDto[] station = LibraryManagerInstance.Instance.qualityStation.GetStationById((int)StationModel.Calidad).ToArray();
            Station = station[0];

            OnPropertyChanged(nameof(Station));
            ShowApprovePieceMessage?.Invoke();
        }

        private bool CanApprovePiece()
        {
            return true;
        }

        private void PutPieceOnProcess()
        {
            CanClickButton = true;

            PieceDto[] piece = LibraryManagerInstance.Instance.piece.GetById(Station.pieceIdOnEntry);
            this.Piece = piece[0];

            LibraryManagerInstance.Instance.qualityStation.PutPieceOnProcess(Station, Piece);

            StationDto[] station = LibraryManagerInstance.Instance.qualityStation.GetStationById((int)StationModel.Calidad).ToArray();
            Station = station[0];

            PieceOrderDto[] pieceOrder = LibraryManagerInstance.Instance.pieceOrder.GetByPieceId(Station.pieceIdOnProcess);
            PieceOrder = pieceOrder[0];

            WorkOrderDto[] workOrder = LibraryManagerInstance.Instance.workOrder.GetById(PieceOrder.workOrderId);
            WorkOrder = workOrder[0];

            PieceDto[] orderedPiece = LibraryManagerInstance.Instance.piece.GetById(WorkOrder.pieceId);
            OrderedPiece = orderedPiece[0];

            ColorDto[] color = LibraryManagerInstance.Instance.color.GetAllIncludingNoColor().Where(c => c.id == Piece.colorId).ToArray();
            Color = color[0];

            PieceTypeDto[] pieceType = LibraryManagerInstance.Instance.pieceType.GetAll().Where(p => p.id == Piece.typeId).ToArray();
            PieceType = pieceType[0];

            ColorDto[] orderedColor = LibraryManagerInstance.Instance.color.GetAll().Where(c => c.id == OrderedPiece.colorId).ToArray();
            OrderedColor = orderedColor[0];

            PieceTypeDto[] orderedPieceType = LibraryManagerInstance.Instance.pieceType.GetAll().Where(p => p.id == OrderedPiece.typeId).ToArray();
            OrderedPieceType = orderedPieceType[0];

            _canClickButton = true;

            OnPropertyChanged(nameof(Station));
            OnPropertyChanged(nameof(Piece));
            OnPropertyChanged(nameof(OrderedPiece));
            OnPropertyChanged(nameof(PieceType));
            OnPropertyChanged(nameof(Color));
            OnPropertyChanged(nameof(OrderedPieceType));
            OnPropertyChanged(nameof(OrderedColor));
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
