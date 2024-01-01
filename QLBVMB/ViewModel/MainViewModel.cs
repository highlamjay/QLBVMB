using MaterialDesignThemes.Wpf;
using Microsoft.Xaml.Behaviors.Core;
using QLBVMB.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace QLBVMB.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<Account> _AccountList;
        public ObservableCollection<Account> AccountList { get { return _AccountList; } set { _AccountList = value; OnPropertyChanged(); } }

        public bool Isloaded = false;
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand SelectionChangedCommand { get; set; }
        public MainViewModel()
        {
            SetPrimaryColor(Colors.DeepSkyBlue);
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
                LoadMainWindow();

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

            SelectionChangedCommand = new RelayCommand<TabControl>((p) =>
            {
                return true;
            }, (p) =>
            {
                switch (p.SelectedIndex)
                {
                    case 0:
                        SetPrimaryColor(Colors.DeepSkyBlue);
                        break;
                    case 1:
                        SetPrimaryColor(Colors.Red);
                        break;
                    case 2:
                        SetPrimaryColor(Colors.Green);
                        break;
                    case 3:
                        SetPrimaryColor(Colors.Blue);
                        break;
                    case 4:
                        SetPrimaryColor(Colors.DeepSkyBlue);
                        break;
                    case 5:
                        SetPrimaryColor(Colors.Orange);
                        break;
                    case 6:
                        SetPrimaryColor(Colors.Green);
                        break;
                    case 7:
                        SetPrimaryColor(Colors.OrangeRed);
                        break;
                    case 8:
                        SetPrimaryColor(Colors.DeepSkyBlue);
                        break;
                }
            });
        }
             
        void LoadMainWindow()
        {
            AccountList = new ObservableCollection<Account>(DataProvider.Ins.DB.Accounts);
        }
    }
}
