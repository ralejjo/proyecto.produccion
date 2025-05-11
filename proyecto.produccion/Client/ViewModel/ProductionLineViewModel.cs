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
using System.Collections.ObjectModel;
using Client.Model;

namespace Client.ViewModel
{
    internal class ProductionLineViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<PieceDto> _pieceList;

        private readonly INavigationService _navigationService;

        public ICommand AsyncGetPieceListCommand { get; private set; }
        public ICommand PutPieceOnEntryCommand { get; private set; }

        public event EventHandler RequestClose;
        public Action CloseAction { get; set; }

        public PieceDto Piece { get; set; }
        public StationDto Station { get; set; }

        public ProductionLineViewModel()
        {
            Piece = new PieceDto();
            Station = new StationDto();

            AsyncGetPieceListCommand = new AsyncRelayCommand(AsyncLoadPieceList, CanLoadPieceList);
            PutPieceOnEntryCommand = new RelayCommand(PutPieceOnEntry, CanPutPieceOnEntry);

            Init();
        }

        private async void Init()
        {
            await AsyncLoadPieceList();
        }

        public ObservableCollection<PieceDto> PieceList
        {
            get { return _pieceList; }
            set
            {
                _pieceList = value;
                OnPropertyChanged("PieceList");
            }
        }

        private bool CanLoadPieceList()
        {
            return true;
        }

        private void LoadPieceList()
        {
            PieceDto[] pieceList = LibraryManagerInstance.Instance.piece.GetAllByState((int)StateModel.Entrada)
                .ToArray();

            if (pieceList.Length > 0)
            {
                PieceList = new ObservableCollection<PieceDto>(pieceList);
            }
        }

        private Task AsyncLoadPieceList()
        {
            return Task.Run(LoadPieceList);
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnRequestClose()
        {
            RequestClose?.Invoke(this, EventArgs.Empty);
        }

        private void PutPieceOnEntry()
        {
            StationDto[] station = LibraryManagerInstance.Instance.cutStation.GetStationById((int)StationModel.Corte).ToArray();
            Station = station[0];
            LibraryManagerInstance.Instance.cutStation.InitializeStation(Station);
            LibraryManagerInstance.Instance.cutStation.PutPieceOnEntry(Station, Piece);
        }

        private bool CanPutPieceOnEntry()
        {
            return true;
        }
    }
}
