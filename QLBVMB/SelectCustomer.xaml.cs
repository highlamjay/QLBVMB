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
    /// Interaction logic for SelectCustomer.xaml
    /// </summary>
    public partial class SelectCustomer : Window
    {
        public SelectCustomer()
        {
            InitializeComponent();

            //CollectionView viewCustomer = (CollectionView)CollectionViewSource.GetDefaultView(LvCustomer.ItemsSource);
            //viewCustomer.Filter = UserFilter;
        }
        private bool UserFilter(object item)
        {
            if (String.IsNullOrEmpty(FindCustomerBox.Text))
                return true;
            else
                return ((item as Customer).Tel.IndexOf(FindCustomerBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private void txtFilter_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(LvCustomer.ItemsSource).Refresh();
        }
    }
}
