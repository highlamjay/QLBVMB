using QLBVMB.Model;
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

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(LvBill.ItemsSource);
            view.Filter = UserFilter;
        }
        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(FindBillBox.Text))
                return true;
            else
                return ((item as Bill).Id_Customer.IndexOf(FindBillBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void txtFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(LvBill.ItemsSource).Refresh();
        }
    }
}
