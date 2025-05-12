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
    /// Lógica de interacción para QualityStationView.xaml
    /// </summary>
    public partial class QualityStationView : Window
    {
        private QualityStationViewModel _ViewModel;
        public QualityStationView()
        {
            InitializeComponent();
            _ViewModel = new QualityStationViewModel()
            {
                CloseAction = Close,
                ShowApprovePieceMessage = () =>
                {
                    MessageBox.Show("La pieza fue aprobada", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
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

