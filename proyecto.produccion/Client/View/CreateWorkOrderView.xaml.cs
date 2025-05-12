using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Shared;
using Client.ViewModel;

namespace Client.View
{
    /// <summary>
    /// Lógica de interacción para CreateWorkOrderView.xaml
    /// </summary>
    public partial class CreateWorkOrderView : Window
    {
        private CreateWorkOrderViewModel _ViewModel;
        public CreateWorkOrderView()
        {
            InitializeComponent();
            _ViewModel = new CreateWorkOrderViewModel()
            {
                CloseAction = Close,
                ShowOrderCreatedMessage = () =>
                {
                    MessageBox.Show("La orden fue creada", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            };

            DataContext = _ViewModel;
        }

        private void BackToProductionLine_Click(object sender, RoutedEventArgs e)
        {
            var productionLineView = new ProductionLineView();
            productionLineView.Show();
            this.Close();
        }
    }
}
