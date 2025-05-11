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
    internal class CreateWorkOrderViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<ClientDto> _clientList;
        private ObservableCollection<ColorDto> _colorList;
        private ObservableCollection<ProcessTypeDto> _processTypeList;
        private ObservableCollection<PieceTypeDto> _pieceTypeList;
        private ObservableCollection<MaterialDto> _materialList;
        private ObservableCollection<StateDto> _stateList;

        public ICommand CreateWorkOrderCommand { get; private set; }
        public ICommand AsyncGetClientListCommand { get; private set; }
        public ICommand AsyncGetColorListCommand { get; private set; }
        public ICommand AsyncGetProcessTypeListCommand { get; private set; }
        public ICommand AsyncGetPieceTypeListCommand { get; private set; }
        public ICommand AsyncGetMaterialListCommand { get; private set; }
        public ICommand AsyncGetStateListCommand { get; private set; }


        public event EventHandler RequestClose;
        public Action CloseAction { get; set; }

        public CreateWorkOrderDto WorkOrder { get; set; }

        public CreateWorkOrderViewModel()
        {
            WorkOrder = new CreateWorkOrderDto();

            AsyncGetClientListCommand = new AsyncRelayCommand(AsyncLoadClientList, CanLoadClientList);
            AsyncGetColorListCommand = new AsyncRelayCommand(AsyncLoadColorList, CanLoadColorList);
            AsyncGetProcessTypeListCommand = new AsyncRelayCommand(AsyncLoadProcessTypeList, CanLoadProcessTypeList);
            AsyncGetPieceTypeListCommand = new AsyncRelayCommand(AsyncLoadPieceTypeList, CanLoadPieceTypeList);
            AsyncGetMaterialListCommand = new AsyncRelayCommand(AsyncLoadMaterialList, CanLoadMaterialList);
            AsyncGetStateListCommand = new AsyncRelayCommand(AsyncLoadStateList, CanLoadStateList);
            CreateWorkOrderCommand = new RelayCommand(AddWorkOrder, CanAddWorkOrder);

            Init();
        }

        private async void Init()
        {
            await AsyncLoadClientList();
            await AsyncLoadColorList();
            await AsyncLoadProcessTypeList();
            await AsyncLoadPieceTypeList();
            await AsyncLoadMaterialList();
            await AsyncLoadStateList();
        }

        public ObservableCollection<ClientDto> ClientList
        {
            get { return _clientList; }
            set
            {
                _clientList = value;
                OnPropertyChanged("ClientList");
            }
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

        public ObservableCollection<ProcessTypeDto> ProcessTypeList
        {
            get { return _processTypeList; }
            set
            {
                _processTypeList = value;
                OnPropertyChanged("ProcessTypeList");
            }
        }

        public ObservableCollection<PieceTypeDto> PieceTypeList
        {
            get { return _pieceTypeList; }
            set
            {
                _pieceTypeList = value;
                OnPropertyChanged("PieceTypeList");
            }
        }

        public ObservableCollection<MaterialDto> MaterialList
        {
            get { return _materialList; }
            set
            {
                _materialList = value;
                OnPropertyChanged("MaterialList");
            }
        }

        public ObservableCollection<StateDto> StateList
        {
            get { return _stateList; }
            set
            {
                _stateList = value;
                OnPropertyChanged("StateList");
            }
        }

        private bool CanLoadClientList()
        {
            return true;
        }

        private void LoadClientList()
        {
            ClientDto[] clientList = LibraryManagerInstance.Instance.client.GetAll()
                .ToArray();

            if (clientList.Length > 0)
            {
                ClientList = new ObservableCollection<ClientDto>(clientList);
            }
        }

        private Task AsyncLoadClientList()
        {
            return Task.Run(LoadClientList);
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

        private bool CanLoadProcessTypeList()
        {
            return true;
        }

        private void LoadProcessTypeList()
        {
            ProcessTypeDto[] processTypeList = LibraryManagerInstance.Instance.processType.GetAll()
                .ToArray();

            if (processTypeList.Length > 0)
            {
                ProcessTypeList = new ObservableCollection<ProcessTypeDto>(processTypeList);
            }
        }

        private Task AsyncLoadProcessTypeList()
        {
            return Task.Run(LoadProcessTypeList);
        }

        private bool CanLoadPieceTypeList()
        {
            return true;
        }

        private void LoadPieceTypeList()
        {
            PieceTypeDto[] pieceTypeList = LibraryManagerInstance.Instance.pieceType.GetAll()
                .ToArray();

            if (pieceTypeList.Length > 0)
            {
                PieceTypeList = new ObservableCollection<PieceTypeDto>(pieceTypeList);
            }
        }

        private Task AsyncLoadPieceTypeList()
        {
            return Task.Run(LoadPieceTypeList);
        }

        private bool CanLoadMaterialList()
        {
            return true;
        }

        private void LoadMaterialList()
        {
            MaterialDto[] materialList = LibraryManagerInstance.Instance.material.GetAll()
                .ToArray();

            if (materialList.Length > 0)
            {
                MaterialList = new ObservableCollection<MaterialDto>(materialList);
            }
        }

        private Task AsyncLoadMaterialList()
        {
            return Task.Run(LoadMaterialList);
        }

        private bool CanLoadStateList()
        {
            return true;
        }

        private void LoadStateList()
        {
            StateDto[] stateList = LibraryManagerInstance.Instance.state.GetAll()
                .ToArray();

            if (stateList.Length > 0)
            {
                StateList = new ObservableCollection<StateDto>(stateList);
            }
        }

        private Task AsyncLoadStateList()
        {
            return Task.Run(LoadStateList);
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnRequestClose()
        {
            RequestClose?.Invoke(this, EventArgs.Empty);
        }

        private void AddWorkOrder()
        {
            // LibraryManagerInstance.Instance.workOrder.InitializeWorkOrder(WorkOrder);
            LibraryManagerInstance.Instance.workOrder.CreateWorkOrder(WorkOrder);

            OnRequestClose();
        }

        private bool CanAddWorkOrder()
        {
            return true;
        }
    }
}
