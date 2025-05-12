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
        private ObservableCollection<PieceDto> _pieceToQualityList;
        private ObservableCollection<PieceDto> _pieceToPaintList;

        public ICommand AsyncGetPieceListCommand { get; private set; }
        public ICommand AsyncGetPieceToQualityListCommand { get; private set; }
        public ICommand AsyncGetPieceToPaintListCommand { get; private set; }
        public ICommand PutPieceOnEntryToCutCommand { get; private set; }
        public ICommand PutPieceOnEntryToQualityCommand { get; private set; }
        public ICommand PutPieceOnEntryToPaintCommand { get; private set; }

        public event EventHandler RequestClose;
        public Action CloseAction { get; set; }

        public PieceDto Piece { get; set; }
        public StationDto Station { get; set; }

        public ProductionLineViewModel()
        {
            Piece = new PieceDto();
            Station = new StationDto();

            AsyncGetPieceListCommand = new AsyncRelayCommand(AsyncLoadPieceList, CanLoadPieceList);
            AsyncGetPieceToQualityListCommand = new AsyncRelayCommand(AsyncLoadPieceToQualityList, CanLoadPieceToQualityList);
            AsyncGetPieceToPaintListCommand = new AsyncRelayCommand(AsyncLoadPieceToPaintList, CanLoadPieceToPaintList);
            PutPieceOnEntryToCutCommand = new RelayCommand(PutPieceOnEntryToCut, CanPutPieceOnEntryToCut);
            PutPieceOnEntryToQualityCommand = new RelayCommand(PutPieceOnEntryToQuality, CanPutPieceOnEntryToQuality);
            PutPieceOnEntryToPaintCommand = new RelayCommand(PutPieceOnEntryToPaint, CanPutPieceOnEntryToPaint);

            Init();
        }

        private async void Init()
        {
            await AsyncLoadPieceList();
            await AsyncLoadPieceToQualityList();
            await AsyncLoadPieceToPaintList();
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

        public ObservableCollection<PieceDto> PieceToQualityList
        {
            get { return _pieceToQualityList; }
            set
            {
                _pieceToQualityList = value;
                OnPropertyChanged("PieceToQualityList");
            }
        }

        private bool CanLoadPieceToQualityList()
        {
            return true;
        }

        private void LoadPieceToQualityList()
        {
            PieceDto[] pieceToQualityList = LibraryManagerInstance.Instance.piece.GetAllByState((int)StateModel.Cortada)
                .ToArray();

            if (pieceToQualityList.Length > 0)
            {
                PieceToQualityList = new ObservableCollection<PieceDto>(pieceToQualityList);
            }
        }

        private Task AsyncLoadPieceToQualityList()
        {
            return Task.Run(LoadPieceToQualityList);
        }

        public ObservableCollection<PieceDto> PieceToPaintList
        {
            get { return _pieceToPaintList; }
            set
            {
                _pieceToPaintList = value;
                OnPropertyChanged("PieceToPaintList");
            }
        }

        private bool CanLoadPieceToPaintList()
        {
            return true;
        }

        private void LoadPieceToPaintList()
        {
            PieceDto[] pieceToPaintList = LibraryManagerInstance.Instance.piece.GetAllByState((int)StateModel.Calidad)
                .ToArray();

            if (pieceToPaintList.Length > 0)
            {
                PieceToPaintList = new ObservableCollection<PieceDto>(pieceToPaintList);
            }
        }

        private Task AsyncLoadPieceToPaintList()
        {
            return Task.Run(LoadPieceToPaintList);
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnRequestClose()
        {
            RequestClose?.Invoke(this, EventArgs.Empty);
        }

        private void PutPieceOnEntryToCut()
        {
            StationDto[] station = LibraryManagerInstance.Instance.cutStation.GetStationById((int)StationModel.Corte).ToArray();
            Station = station[0];
            LibraryManagerInstance.Instance.cutStation.InitializeStation(Station);
            LibraryManagerInstance.Instance.cutStation.PutPieceOnEntry(Station, Piece);
        }

        private bool CanPutPieceOnEntryToCut()
        {
            return true;
        }

        private void PutPieceOnEntryToQuality()
        {
            StationDto[] station = LibraryManagerInstance.Instance.qualityStation.GetStationById((int)StationModel.Calidad).ToArray();
            Station = station[0];
            LibraryManagerInstance.Instance.qualityStation.InitializeStation(Station);
            LibraryManagerInstance.Instance.qualityStation.PutPieceOnEntry(Station, Piece);
        }

        private bool CanPutPieceOnEntryToQuality()
        {
            return true;
        }

        private void PutPieceOnEntryToPaint()
        {
            StationDto[] station = LibraryManagerInstance.Instance.paintStation.GetStationById((int)StationModel.Pintura).ToArray();
            Station = station[0];
            LibraryManagerInstance.Instance.paintStation.InitializeStation(Station);
            LibraryManagerInstance.Instance.paintStation.PutPieceOnEntry(Station, Piece);
        }

        private bool CanPutPieceOnEntryToPaint()
        {
            return true;
        }
    }
}
