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

namespace Client.ViewModel
{
    internal class CreateWorkOrderViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand CreateWorkOrderCommand { get; private set; }

        public event EventHandler RequestClose;
        public Action CloseAction { get; set; }

        public CreateWorkOrderDto WorkOrder { get; set; }

        public CreateWorkOrderViewModel()
        {
            WorkOrder = new CreateWorkOrderDto();

            CreateWorkOrderCommand = new RelayCommand(AddWorkOrder, CanAddWorkOrder);
        }
        
        private void AddWorkOrder()
        {
            // LibraryManagerInstance.Instance.workOrder.InitializeWorkOrder(WorkOrder);
            LibraryManagerInstance.Instance.workOrder.CreateWorkOrder(WorkOrder);
            //MessageBox.Show($"Book added successfully with ID: {identity}!", "Insert", MessageBoxButton.OK, MessageBoxImage.Information);

            OnRequestClose();
        }

        private bool CanAddWorkOrder()
        {
            return true;
        }

        private void OnRequestClose()
        {
            RequestClose?.Invoke(this, EventArgs.Empty);
        }
    }
}
