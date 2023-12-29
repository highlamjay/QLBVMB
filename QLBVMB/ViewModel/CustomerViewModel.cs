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

            var displayListAccount = DataProvider.Ins.DB.Customers.Where(x => x.Id_Customer == Id_Customer);

            AddCustomerCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(Id_Customer))
                    return false;

                if (displayListAccount == null || displayListAccount.Count() != 0)
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
                //if (AccountSelectedItem == null)
                //    return false;
                //var displayListAccount1 = DataProvider.Ins.DB.Accounts.Where(x => x.Id_Account == AccountSelectedItem.Id_Account);
                //if (displayListAccount1 != null && displayListAccount.Count() != 0)
                //    return true;

                return false;
            }, (p) =>
            {
                //var Account = DataProvider.Ins.DB.Accounts.Where(x => x.Id_Account == AccountSelectedItem.Id_Account).SingleOrDefault();
                //Account.Id_Account = Id_Account;
                //Account.Username = Username;
                //Account.Password = Password;
                //Account.DisplayName = DisplayName;
                //Account.Position = Position;
                //DataProvider.Ins.DB.SaveChanges();

                //AccountSelectedItem.DisplayName = DisplayName;
            });

            DeleteCustomerCommand = new RelayCommand<object>((p) =>
            {
                //if (AccountSelectedItem == null)
                //    return false;

                //var displayListAccount1 = DataProvider.Ins.DB.Accounts.Where(x => x.Id_Account == AccountSelectedItem.Id_Account);
                //if (displayListAccount1 != null && displayListAccount.Count() != 0)
                //    return true;

                return false;
            }, (p) =>
            {
                //DataProvider.Ins.DB.Accounts.Remove(AccountSelectedItem);
                //DataProvider.Ins.DB.SaveChanges();

                //CustomerList.Remove(AccountSelectedItem);
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

        private byte? _Age;
        public byte? Age { get => _Age; set { _Age = value; OnPropertyChanged(); } }

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
