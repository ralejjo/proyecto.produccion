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
    /// Lógica de interacción para CutStationView.xaml
    /// </summary>
    public partial class CutStationView : Window
    {
        private CutStationViewModel _ViewModel;
        public CutStationView()
        {
            InitializeComponent();
            _ViewModel = new CutStationViewModel()
            {
                CloseAction = Close
            };

            DataContext = _ViewModel;
        }
    }
}
