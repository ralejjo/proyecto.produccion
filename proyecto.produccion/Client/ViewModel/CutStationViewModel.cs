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

namespace Client.ViewModel
{
    internal class CutStationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand CutPieceCommand { get; private set; }
        //public ICommand PutPieceOnEntryCommand {  get; private set; }

        public event EventHandler RequestClose;
        public Action CloseAction { get; set; }

        public PieceDto Piece { get; set; }

        public StationDto Station { get; set; }

        public CutStationViewModel()
        { 
            Station = new StationDto();
            Piece = new PieceDto();

            CutPieceCommand = new RelayCommand(CutPiece, CanCutPiece);
            //PutPieceOnEntryCommand = new RelayCommand(PutPieceOnEntry, CanPutPieceOnEntry);
        }

        //private void PutPieceOnEntry()
        //{
        //    LibraryManagerInstance.Instance.cutStation.InitializeStation(Station);
        //    LibraryManagerInstance.Instance.cutStation.PutPieceOnEntry(Station, Piece);
        //}

        //private bool CanPutPieceOnEntry()
        //{
        //    return true;
        //}

        private void CutPiece()
        {
            LibraryManagerInstance.Instance.cutStation.ProcessPiece(Piece);

            OnRequestClose();
        }

        private bool CanCutPiece()
        {
            return true;
        }

        private void OnRequestClose()
        {
            RequestClose?.Invoke(this, EventArgs.Empty);
        }
    }
}
