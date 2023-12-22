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

namespace QLBVMB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewModel.BaseViewModel temp = new ViewModel.BaseViewModel();
            switch (tcontrol.SelectedIndex)
            {
                case 0:
                    temp.SetPrimaryColor(Colors.Cyan);
                    break;
                case 1:
                    temp.SetPrimaryColor(Colors.Red);
                    break;
                case 2:
                    temp.SetPrimaryColor(Colors.Green);
                    break;
                case 3:
                    temp.SetPrimaryColor(Colors.Blue);
                    break;
                case 4:
                    temp.SetPrimaryColor(Colors.Orange);
                    break;
                case 5:
                    temp.SetPrimaryColor(Colors.Yellow);
                    break;
                case 6:
                    temp.SetPrimaryColor(Colors.Green);
                    break;
            }
        }
    }
}
