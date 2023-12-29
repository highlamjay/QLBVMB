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
    public class AccountViewModel : BaseViewModel
    {
        private ObservableCollection<Account> _AccountList;
        public ObservableCollection<Account> AccountList { get { return _AccountList; } set { _AccountList = value; OnPropertyChanged(); } }

        private ObservableCollection<RolePosition> _RolePositionList;
        public ObservableCollection<RolePosition> RolePositionList { get { return _RolePositionList; } set { _RolePositionList = value; OnPropertyChanged(); } }

        //private ObservableCollection<Booked> _BookedList;
        //public ObservableCollection<Booked> BookedList { get { return _BookedList; } set { _BookedList = value; OnPropertyChanged(); } }
        public AccountViewModel()
        {
            AccountList = new ObservableCollection<Account>(DataProvider.Ins.DB.Accounts);
            RolePositionList = new ObservableCollection<RolePosition>(DataProvider.Ins.DB.RolePositions);
            //BookedList = new ObservableCollection<Booked>(DataProvider.Ins.DB.Bookeds);

            var displayListAccountId = DataProvider.Ins.DB.Accounts.Where(x => x.Id_Account == Id_Account);
            var displayListAccountUserName = DataProvider.Ins.DB.Accounts.Where(x => x.Username == Username);
            var displayListAccountDisplayName = DataProvider.Ins.DB.Accounts.Where(x => x.DisplayName == DisplayName);

            AddAccountCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(Id_Account))
                    return false;

                if (displayListAccountId == null || displayListAccountId.Count() != 0)
                { return false; }
                if (displayListAccountUserName == null || displayListAccountUserName.Count() != 0)
                { return false; }
                if (displayListAccountDisplayName == null || displayListAccountDisplayName.Count() != 0)
                { return false; }
                return true;
            }, (p) =>
            {

                var account = new Account() { Id_Account = Id_Account,Username = Username,Password = Password,Position = Position, DisplayName = DisplayName };

                DataProvider.Ins.DB.Accounts.Add(account);
                DataProvider.Ins.DB.SaveChanges();

                AccountList.Add(account);
            });

            EditAccountCommand = new RelayCommand<object>((p) =>
            {
                if (AccountSelectedItem == null)
                    return false;
                var displayListAccount1 = DataProvider.Ins.DB.Accounts.Where(x => x.Id_Account == AccountSelectedItem.Id_Account);
                if (displayListAccount1 != null && displayListAccount1.Count() != 0)
                    return true;

                return false;
            }, (p) =>
            {
                var Account = DataProvider.Ins.DB.Accounts.Where(x => x.Id_Account == AccountSelectedItem.Id_Account).SingleOrDefault();
                Account.Id_Account = Id_Account;
                Account.Username = Username;
                Account.Password = Password;
                Account.DisplayName = DisplayName;
                Account.Position = Position;
                DataProvider.Ins.DB.SaveChanges();

                AccountSelectedItem.DisplayName = DisplayName;
            });

            DeleteAccountCommand = new RelayCommand<object>((p) =>
            {
                if (AccountSelectedItem == null)
                    return false;

                var displayListAccount1 = DataProvider.Ins.DB.Accounts.Where(x => x.Id_Account == AccountSelectedItem.Id_Account);
                if (displayListAccount1 != null && displayListAccount1.Count() != 0)
                    return true;

                return false;
            }, (p) =>
            {
                var booked = DataProvider.Ins.DB.Bookeds.Where(x => x.Id_AccountSeller == Id_Account);
                //foreach(var item in booked)
                //{
                //    DataProvider.Ins.DB.Bookeds.Remove(item);            
                //    BookedList.Remove(BookedtSelectedItem);
                //}
                DataProvider.Ins.DB.Accounts.Remove(AccountSelectedItem);
                DataProvider.Ins.DB.SaveChanges();

                AccountList.Remove(AccountSelectedItem);
            });
        }
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

        //private Booked _BookedtSelectedItem;
        //public Booked BookedtSelectedItem
        //{
        //    get => _BookedtSelectedItem;
        //    set
        //    {
        //        _BookedtSelectedItem = value;
        //        OnPropertyChanged();
        //        if (BookedtSelectedItem != null)
        //        {
        //            Id_Booked = BookedtSelectedItem.Id_Booked;
        //            Id_Customer = BookedtSelectedItem.Id_Customer;
        //            Id_Flight = BookedtSelectedItem.Id_Flight;
        //            Id_CB = BookedtSelectedItem.Id_CB;
        //            Id_AccountSeller = BookedtSelectedItem?.Id_AccountSeller;
        //            Id_Ticket = BookedtSelectedItem?.Id_Ticket;
        //            Date = BookedtSelectedItem?.Date;
        //        }
        //    }
        //}

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

        //private string _Id_Booked;
        //public string Id_Booked { get => _Id_Booked; set { _Id_Booked = value; OnPropertyChanged(); } }

        //private string _Id_Ticket;
        //public string Id_Ticket { get => _Id_Ticket; set { _Id_Ticket = value; OnPropertyChanged(); } }

        //private string _Id_Flight;
        //public string Id_Flight { get => _Id_Flight; set { _Id_Flight = value; OnPropertyChanged(); } }

        //private string _Id_Customer;
        //public string Id_Customer { get => _Id_Customer; set { _Id_Customer = value; OnPropertyChanged(); } }

        //private string _Id_AccountSeller;
        //public string Id_AccountSeller { get => _Id_AccountSeller; set { _Id_AccountSeller = value; OnPropertyChanged(); } }

        //private Nullable<System.DateTime> _Date;
        //public Nullable<System.DateTime> Date { get => _Date; set { _Date = value; OnPropertyChanged(); } }

        //private string _Id_CB;
        //public string Id_CB { get => _Id_CB; set { _Id_CB = value; OnPropertyChanged(); } }

        public ICommand AddAccountCommand { get; set; }
        public ICommand EditAccountCommand { get; set; }
        public ICommand DeleteAccountCommand { get; set; }
    }


}
