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
