using QLBVMB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace QLBVMB.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private string _Username;
        private string _Password;

        public bool IsLogin { get; set; }
        public string Username { get => _Username; set { _Username = value; OnPropertyChanged(); } }
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }
        public ICommand LoginCommand { get; set; }
        public ICommand UsernameChangedCommand { get; set; }
        public ICommand PasswordChangedCommand { get; set; }
        public LoginViewModel()
        {
            IsLogin = false;
            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { Login(p); });
            UsernameChangedCommand = new RelayCommand<TextBox>((p) => { return true; }, (p) => { Username = p.Text; });
            PasswordChangedCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) => { Password = p.Password; });
        }

        void Login(Window p)
        {
            if (p == null)
                return;
            //int accCount = 0;
            //if (Username == "admin" && Password == "admin")
            //    accCount = 1;
            var accCount = DataProvider.Ins.DB.Accounts.Where(a => a.Username == Username && a.Password == Password).SingleOrDefault();
            if (accCount.Position == "Quản lý")
            {
                IsLogin = true;
                p.Close();
            }
            else
            {
                IsLogin = false;
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
            }

        }
    }

}
