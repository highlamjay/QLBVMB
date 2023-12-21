using QLBVMB.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace QLBVMB.ViewModel
{
    public class AccountViewModel : BaseViewModel
    {
        private ObservableCollection<Account> _ListAccount;
        public ObservableCollection<Account> ListAccount { get => _ListAccount; set { _ListAccount = value; OnPropertyChanged();} }

        private Account _SelectedItemAccount;
        public Account SelectedItemAccount { get => _SelectedItemAccount; 
            set 
            {
                _SelectedItemAccount = value; 
                OnPropertyChanged(); 
                if (SelectedItemAccount != null)
                {
                    Id_Account = SelectedItemAccount.Id_Account;
                    Username = SelectedItemAccount.Username;
                    Password = SelectedItemAccount.Password;
                    Position = SelectedItemAccount.Position;
                    DisplayName = SelectedItemAccount.DisplayName;
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

        public IComparable AddAccountCommand { get; set; }
        public IComparable EditAccountCommand { get; set; }

        //public AccountViewModel()
        //{
        //    ListAccount = new ObservableCollection<Account>(DataProvider.Ins.DB.Accounts);

        //    AddAccountCommand = new RelayCommand<object>((p) => 
        //    { 
        //        if (string.IsNullOrEmpty(Id_Account))
        //           return false;

        //        var displayList = DataProvider.Ins.DB.Accounts.Where(x=> x.Id_Account = Id_Account);
        //        if (displayList == null || displayList.Count() != 0 )
        //        { return false; }
        //        return true;
        //    }, (p) => 
        //    {
        //        var account = new Account() { Id_Account = Id_Account};

        //        DataProvider.Ins.DB.Accounts.Add(account);
        //        DataProvider.Ins.DB.SaveChanges();

        //        ListAccount.Add(account);
        //    });

        //    EditAccountCommand = new RelayCommand<object>((p) =>
        //    {
        //        if (SelectedItemAccount == null)
        //            return false;

        //        var displayListAccount = DataProvider.Ins.DB.Accounts.Where(x => x.Id_Account == SelectedItemAccount.Id_Account);
        //        if (displayListAccount != null && displayListAccount.Count() != 0)
        //            return true;

        //        return false;
        //    }, (p) =>
        //    {
        //        var Account = DataProvider.Ins.DB.Accounts.Where(x => x.Id_Account = SelectedItemAccount.Id_Account).SingleOrDefault();
        //        Account.Id_Account = Id_Account;
        //        Account.Username = Username;
        //        Account.Password = Password;
        //        Account.DisplayName = DisplayName;
        //        //Account.Position = Positon;
        //        DataProvider.Ins.DB.SaveChanges();
        //        SelectedItemAccount.DisplayName = DisplayName;
        //    });

        //}
    }

    
}
