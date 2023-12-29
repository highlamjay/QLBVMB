using QLBVMB.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QLBVMB.ViewModel
{
    public class CustomerViewModel : BaseViewModel
    {
        private ObservableCollection<Customer> _CustomerList;
        public ObservableCollection<Customer> CustomerList { get { return _CustomerList; } set { _CustomerList = value; OnPropertyChanged(); } }

        private ObservableCollection<Locate> _LocateList;
        public ObservableCollection<Locate> LocateList { get { return _LocateList; } set { _LocateList = value; OnPropertyChanged(); } }
        public CustomerViewModel()
        {
            CustomerList = new ObservableCollection<Customer>(DataProvider.Ins.DB.Customers);
            LocateList = new ObservableCollection<Locate>(DataProvider.Ins.DB.Locates);

            var displayListCustomer = DataProvider.Ins.DB.Customers.Where(x => x.Id_Customer == Id_Customer);
            var displayListLocate = DataProvider.Ins.DB.Customers.Where(x => x.Locate == SelectedLocate.Id_Locate);

            AddCustomerCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(Id_Customer) && string.IsNullOrEmpty(Name_Customer))
                    return false;

                if ((displayListCustomer != null && displayListCustomer.Count() != 0))
                    return false;
                return true;
            }, (p) =>
            {
                var Customer = new Customer() { Id_Customer = Id_Customer, Name_Customer = Name_Customer, Id_Locate = SelectedLocate.Id_Locate };

                DataProvider.Ins.DB.Customers.Add(Customer);
                DataProvider.Ins.DB.SaveChanges();

                CustomerList.Add(Customer);
            });

            EditCustomerCommand = new RelayCommand<object>((p) =>
            {
                if (CustomerSelectedItem == null)
                    return false;

                if (CustomerSelectedItem.Locate.Id_Locate == SelectedLocate.Id_Locate)
                    return true;
                return false;
            }, (p) =>
            {
                var Customer = DataProvider.Ins.DB.Customers.Where(x => x.Id_Customer == CustomerSelectedItem.Id_Customer).SingleOrDefault();
                Customer.Id_Customer = Id_Customer;
                Customer.Name_Customer = Name_Customer;
                Customer.Id_Locate = SelectedLocate.Id_Locate;
                DataProvider.Ins.DB.SaveChanges();

            });
            DeleteCustomerCommand = new RelayCommand<object>((p) =>
            {
                if (CustomerSelectedItem != null)
                    return true;
                return false;
            }, (p) =>
            {
                var Customer = new Customer() { Id_Customer = Id_Customer, Name_Customer = Name_Customer, Id_Locate = SelectedLocate.Id_Locate };

                DataProvider.Ins.DB.Customers.Remove(CustomerSelectedItem);
                DataProvider.Ins.DB.SaveChanges();

                CustomerList.Remove(CustomerSelectedItem);
            });
        }
        private Customer _CustomerSelectedItem;
        public Customer CustomerSelectedItem
        {
            get => _CustomerSelectedItem;
            set
            {
                _CustomerSelectedItem = value;
                OnPropertyChanged();
                if (CustomerSelectedItem != null)
                {
                    Id_Customer = CustomerSelectedItem.Id_Customer;
                    Name_Customer = CustomerSelectedItem.Name_Customer;
                    SelectedLocate = CustomerSelectedItem.Locate;
                }
            }
        }
        private Locate _SelectedLocate;
        public Locate SelectedLocate
        {
            get => _SelectedLocate;
            set
            {
                _SelectedLocate = value;
                OnPropertyChanged();
            }
        }
        private string _Id_Customer;
        public string Id_Customer { get => _Id_Customer; set { _Id_Customer = value; OnPropertyChanged(); } }

        private string _Name_Customer;
        public string Name_Customer { get => _Name_Customer; set { _Name_Customer = value; OnPropertyChanged(); } }

        private string _Id_Locate;
        public string Id_Locate { get => _Id_Locate; set { _Id_Locate = value; OnPropertyChanged(); } }
        public ICommand AddCustomerCommand { get; set; }
        public ICommand EditCustomerCommand { get; set; }
        public ICommand DeleteCustomerCommand { get; set; }
    }
}
