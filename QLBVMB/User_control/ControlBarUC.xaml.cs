using QLBVMB.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QLBVMB.User_control
{

    public partial class ControlBarUC : UserControl
    {
        public ControlBarUC()
        {
            InitializeComponent();
            this.DataContext = Viewmodel = new ControlBarViewModel();
        }

        public ControlBarViewModel Viewmodel { get; set; }

        private void btControlBarMax_Click(object sender, RoutedEventArgs e)
        {
            if (btControlBarMax.Visibility == Visibility.Visible)
            {
                btControlBarMax.Visibility = Visibility.Collapsed;
                btControlBarRestoreDown.Visibility = Visibility.Visible;
            }
            else if (btControlBarRestoreDown.Visibility == Visibility.Visible)
            {
                btControlBarMax.Visibility = Visibility.Visible;
                btControlBarRestoreDown.Visibility = Visibility.Collapsed;
            }
        }
    }
}