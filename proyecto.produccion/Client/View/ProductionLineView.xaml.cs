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
    /// Lógica de interacción para ProductionLineView.xaml
    /// </summary>
    public partial class ProductionLineView : Window
    {
        private ProductionLineViewModel _ViewModel;
        public ProductionLineView()
        {
            InitializeComponent();
            _ViewModel = new ProductionLineViewModel()
            {
                CloseAction = Close
            };

            DataContext = _ViewModel;
        }

        private void CreateWorkOrder_Click(object sender, RoutedEventArgs e)
        {
            var createWorkOrderView = new CreateWorkOrderView();
            createWorkOrderView.Show();
            this.Close();
        }

        private void GoToCutStation_Click(object sender, RoutedEventArgs e)
        {
            var cutStationView = new CutStationView();
            cutStationView.Show();
            this.Close();
        }

        private void GoToQualityStation_Click(object sender, RoutedEventArgs e)
        {
            var qualityStationView = new QualityStationView();
            qualityStationView.Show();
            this.Close();
        }

        private void GoToPaintStation_Click(object sender, RoutedEventArgs e)
        {
            var paintStationView = new PaintStationView();
            paintStationView.Show();
            this.Close();
        }

        private void GoToEntryStation_Click(object sender, RoutedEventArgs e)
        {
            //var entryStationView = new EntryStationView();
            //entryStationView.Show();
            //this.Close();
        }
    }
}
