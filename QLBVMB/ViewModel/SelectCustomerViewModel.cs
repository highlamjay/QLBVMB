using QLBVMB.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.ComponentModel;
using System.Windows.Data;

namespace QLBVMB.ViewModel
{
    public class SelectCustomerViewModel : BaseViewModel
    {
        public bool IsSelect { get; set; }

        private string _Id_Customer;
        public string Id_Customer { get => _Id_Customer; set { _Id_Customer = value; OnPropertyChanged(); } }
        public ICommand SelectCustomerCommand { get; set; }
        public ICommand ExitCommand { get; set; }

        private ObservableCollection<Customer> _CustomerListFull;
        public ObservableCollection<Customer> CustomerListFull { get { return _CustomerListFull; } set { _CustomerListFull = value; OnPropertyChanged(); } }

        private ICollectionView _CustomerCollection;
        public ICollectionView CustomerCollection { get { return _CustomerCollection; } set { _CustomerCollection = value; OnPropertyChanged(); } }
        public bool FilterByTel(object customer)
        {
            if (!string.IsNullOrEmpty(TextToFilter))
            {
                var customerDetail = customer as Customer;
                return customerDetail != null && customerDetail.Tel.Contains(TextToFilter);
            }
            return true;
        }

        public SelectCustomerViewModel()
        {
            IsSelect = false;
            CustomerCollection = (CollectionView)CollectionViewSource.GetDefaultView(CustomerListFull);

            CustomerListFull = new ObservableCollection<Customer>();
            var customer = DataProvider.Ins.DB.Customers;
            foreach (var item in customer)
            {
                Customer customeritem = new Customer();
                customeritem.Id_Customer = item.Id_Customer;
                customeritem.Name = item.Name;
                customeritem.Sex = item.Sex;
                customeritem.Age = item.Age;
                customeritem.Email = item.Email;
                customeritem.Tel = item.Tel;
                customeritem.Locate1 = item.Locate1;
                CustomerListFull.Add(customeritem);
            }

            SelectCustomerCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (CustomerSelectedItem != null)
                {
                    TextToFilter = string.Empty;
                    IsSelect = true;
                    p.Close();
                }
                else
                {
                    MessageBox.Show("Bạn chưa chọn khách hàng!", "Warning");
                }
            }
            );
            ExitCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                TextToFilter = string.Empty;
                p.Close();
            }
            );
        }
     
        private Customer _CustomerSelectedItem;
        public Customer CustomerSelectedItem
        {
            get => _CustomerSelectedItem;
            set
            {
                _CustomerSelectedItem = value;
                OnPropertyChanged();

            }
        }

        private string _TextToFilter;
        public string TextToFilter
        {
            get => _TextToFilter;
            set
            {
                _TextToFilter = value;
                OnPropertyChanged();
            }
        }
    }
}
