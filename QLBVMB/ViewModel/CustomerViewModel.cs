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
        public ObservableCollection<Customer> CustomerList { get {  return _CustomerList; } set { _CustomerList = value; OnPropertyChanged(); } }
        private ObservableCollection<Locate> _LocateList;
        public ObservableCollection<Locate> LocateList { get { return _LocateList; } set { _LocateList = value; OnPropertyChanged(); } }
        public CustomerViewModel()
        {
            //CustomerList = new ObservableCollection<Customer>(DataProvider.Ins.DB.Customers);
            //LocateList = new ObservableCollection<Locate>(DataProvider.Ins.DB.Locates);

            var displayListCustomer = DataProvider.Ins.DB.Customers.Where(x => x.Id_Customer == Id_Customer);

            AddCustomerCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(Id_Customer))
                    return false;

                if (displayListCustomer == null || displayListCustomer.Count() != 0)
                { return false; }
                return true;
            }, (p) =>
            {
                var customer = new Customer() { Id_Customer = Id_Customer, Name = Name, Age = Age, Sex = Sex, Email = Email, Tel = Tel, Locate = SelectedLocate.Id_Locate };

                DataProvider.Ins.DB.Customers.Add(customer);
                DataProvider.Ins.DB.SaveChanges();

                CustomerList.Add(customer);
            });

            EditCustomerCommand = new RelayCommand<object>((p) =>
            {
                if (CustomerSelectedItem == null)
                    return false;
              
                if (displayListCustomer != null && displayListCustomer.Count() != 0)
                    return true;
                return false;
            }, (p) =>
            {
                var customer = DataProvider.Ins.DB.Customers.Where(x=> x.Id_Customer == CustomerSelectedItem.Id_Customer).SingleOrDefault();
                customer.Id_Customer = Id_Customer;
                customer.Name = Name;
                customer.Age = Age;
                customer.Sex = Sex;
                customer.Email = Email;
                customer.Tel = Tel;
                customer.Locate = SelectedLocate.Id_Locate;
                DataProvider.Ins.DB.SaveChanges();          
            });

            DeleteCustomerCommand = new RelayCommand<object>((p) =>
            {
                if (CustomerSelectedItem == null)
                    return false;

                if (displayListCustomer != null && displayListCustomer.Count() != 0)
                    return true;
                return false;
            }, (p) =>
            {
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
                    Name = CustomerSelectedItem.Name;
                    Age = CustomerSelectedItem.Age;
                    Sex = CustomerSelectedItem.Sex;
                    Email = CustomerSelectedItem.Email;
                    Tel = CustomerSelectedItem.Tel;
                    SelectedLocate = CustomerSelectedItem.Locate1;
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

        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }

        private Nullable<byte> _Age;
        public Nullable<byte> Age { get => _Age; set { _Age = value; OnPropertyChanged(); } }

        private string _Sex;
        public string Sex { get => _Sex; set { _Sex = value; OnPropertyChanged(); } }

        private string _Email;
        public string Email { get => _Email; set { _Email = value; OnPropertyChanged(); } }

        private string _Tel;
        public string Tel { get => _Tel; set { _Tel = value; OnPropertyChanged(); } }

        private string _Locate;
        public string Locate { get => _Locate; set { _Locate = value; OnPropertyChanged(); } }
        public ICommand AddCustomerCommand { get; set; }
        public ICommand EditCustomerCommand { get; set; }
        public ICommand DeleteCustomerCommand { get; set; }
    }
}
