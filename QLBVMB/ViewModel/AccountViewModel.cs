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
        private ObservableCollection<Position> _PositionList;
        public ObservableCollection<Position> PositionList { get { return _PositionList; } set { _PositionList = value; OnPropertyChanged(); } }
        public AccountViewModel()
        {
            AccountList = new ObservableCollection<Account>(DataProvider.Ins.DB.Accounts);
            PositionList = new ObservableCollection<Position>(DataProvider.Ins.DB.Positions);

            var displayListAccount = DataProvider.Ins.DB.Accounts.Where(x => x.Id_Account == Id_Account);

            AddAccountCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(Id_Account))
                    return false;

                if (displayListAccount == null || displayListAccount.Count() != 0)
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
                if (displayListAccount1 != null && displayListAccount.Count() != 0)
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
                if (displayListAccount1 != null && displayListAccount.Count() != 0)
                    return true;

                return false;
            }, (p) =>
            {
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
        public ICommand DeleteAccountCommand { get; set; }
    }


}
