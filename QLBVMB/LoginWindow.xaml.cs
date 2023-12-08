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
using System.Windows.Shapes;

namespace QLBVMB
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        TheControl_Login login = new TheControl_Login();
        public LoginWindow()
        {
            InitializeComponent();
            TheControl_Login.SetIntials(this);
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            login.Minimize(this);
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            login.DoMaximize(this,btn);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            login.Exit(this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
