using Microsoft.Xaml.Behaviors.Core;
using QLBVMB.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QLBVMB.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<Account> _AccountList;
        public ObservableCollection<Account> AccountList { get { return _AccountList; }  set { _AccountList = value;OnPropertyChanged(); } }
        private ObservableCollection<Airport> _AirportList;
        private ObservableCollection<Booked> _BookedList;
        private ObservableCollection<Checked_Baggage> _Checked_BaggageList;
        private ObservableCollection<Customer> _CustomerList;
        private ObservableCollection<Flight> _FlightList;
        private ObservableCollection<Locate> _LocateList;
        private ObservableCollection<Plane> _PlaneList;
        private ObservableCollection<Ticket> _TicketList;
        private Account _AccountSelectedItem;
        public Account AccountSelectedItem
        {
            get => _AccountSelectedItem;
            set
            {
                _AccountSelectedItem = value;
                OnPropertyChanged();
                if (AccountSelectedItem != null)
                {
                    Id_Account = AccountSelectedItem.Id_Account;
                    Username = AccountSelectedItem.Username;
                    Password = AccountSelectedItem.Password;
                    Position = AccountSelectedItem.Position;
                    DisplayName = AccountSelectedItem.DisplayName;
                }
            }
        }
        private string _Id_Account;
        public string Id_Account { get => _Id_Account; set { _Id_Account = value; OnPropertyChanged(); } }

        private string _Username;
        public string Username { get => _Username; set { _Username = value; OnPropertyChanged(); } }

        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }

        private string _Position;
        public string Position { get => _Position; set { _Position = value; OnPropertyChanged(); } }

        private string _DisplayName;
        public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }

        public ICommand AddAccountCommand { get; set; }
        public ICommand EditAccountCommand { get; set; }


            //EditAccountCommand = new RelayCommand<object>((p) =>
            //{
            //    if (AccountSelectedItem == null)
            //        return false;

            //    var displayListAccount = DataProvider.Ins.DB.Accounts.Where(x => x.Id_Account == AccountSelectedItem.Id_Account);
            //    if (displayListAccount != null && displayListAccount.Count() != 0)
            //        return true;

            //    return false;
            //}, (p) =>
            //{
            //    var Account = DataProvider.Ins.DB.Accounts.Where(x => x.Id_Account == AccountSelectedItem.Id_Account).SingleOrDefault();
            //    Account.Id_Account = Id_Account;
            //    Account.Username = Username;
            //    Account.Password = Password;
            //    Account.DisplayName = DisplayName;
            //    Account.Position = Position;
            //    DataProvider.Ins.DB.SaveChanges();
            //    AccountSelectedItem.DisplayName = DisplayName;
            //});

       
        public ObservableCollection<Airport> AirportList { get { return _AirportList; } set { _AirportList = value; OnPropertyChanged(); } }
        public ObservableCollection<Booked> BookedList { get { return _BookedList; } set { _BookedList = value; OnPropertyChanged(); } }
        public ObservableCollection<Checked_Baggage> Checked_BaggageList { get { return _Checked_BaggageList; } set { _Checked_BaggageList = value; OnPropertyChanged(); } }
        public ObservableCollection<Customer> CustomerList { get { return _CustomerList; } set { _CustomerList = value; OnPropertyChanged(); } }
        public ObservableCollection<Flight> FlightList { get { return _FlightList; } set { _FlightList = value; OnPropertyChanged(); } }
        public ObservableCollection<Locate> LocateList { get { return _LocateList; } set { _LocateList = value; OnPropertyChanged(); } }
        public ObservableCollection<Plane> PlaneList { get { return _PlaneList; } set { _PlaneList = value; OnPropertyChanged(); } }
        public ObservableCollection<Ticket> TicketList { get { return _TicketList; } set { _TicketList = value; OnPropertyChanged(); } }

        public bool Isloaded = false;
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand LoadedAccountCommand { get; set; }
        public ICommand CustomerCommand { get; set; }
        public ICommand AirportCommand { get; set; }
        public ICommand PlaneCommand { get; set; }
        public ICommand FlightCommand { get; set; }
        public ICommand UserCommand { get; set; }
        public ICommand BillCommand { get; set; }
        public ICommand StatisticalCommand { get; set; }
        public ICommand TicketCommand { get; set; }
        
        public MainViewModel()
        {
            LoadedWindowCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                Isloaded = true;
                if (p == null)
                {
                    return;
                }

                p.Hide();

                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog();

                if (loginWindow.DataContext == null)
                {
                    return;
                }

                var loginVM = loginWindow.DataContext as LoginViewModel;

                if (loginVM.IsLogin == true)
                {
                    p.Show();
                }
                else
                {
                    p.Close();
                }
            }
            );
            AccountList = new ObservableCollection<Account>(DataProvider.Ins.DB.Accounts);
            AddAccountCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(Id_Account))
                    return false;
                var displayListAccount = DataProvider.Ins.DB.Accounts.Where(x => x.Id_Account == Id_Account);
                if (displayListAccount == null || displayListAccount.Count() != 0)
                {
                    return false;
                }
                return true;
            }, (p) =>
            {
                var account = new Account() { Id_Account = Id_Account, Username = Username, Password = Password, Position = Position, DisplayName = DisplayName };

                DataProvider.Ins.DB.Accounts.Add(account);
                DataProvider.Ins.DB.SaveChanges();

                AccountList.Add(account);
            });

        }

        //public void AccountViewModel()
        //{
        //    LoadedAccountCommand = new RelayCommand<Window>((w) => { return true; }, (w) =>
        //    {
                
        //    });
        //}

    }
}
