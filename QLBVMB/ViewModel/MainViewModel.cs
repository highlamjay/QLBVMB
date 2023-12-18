using Microsoft.Xaml.Behaviors.Core;
using QLBVMB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace QLBVMB.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public bool Isloaded = false;
        public ICommand LoadedWindowCommand { get; set; }
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

            CustomerCommand = new RelayCommand<object>((p) => { return true; }, (p) => { CustomerWindow wd = new CustomerWindow(); wd.ShowDialog(); });
            AirportCommand = new RelayCommand<object>((p) => { return true; }, (p) => { AirportWindow wd = new AirportWindow(); wd.ShowDialog(); });
            PlaneCommand = new RelayCommand<object>((p) => { return true; }, (p) => { PlaneWindow wd = new PlaneWindow(); wd.ShowDialog(); });
            FlightCommand = new RelayCommand<object>((p) => { return true; }, (p) => { FlightWindow wd = new FlightWindow(); wd.ShowDialog(); });
            BillCommand = new RelayCommand<object>((p) => { return true; }, (p) => { BillWindow wd = new BillWindow(); wd.ShowDialog(); });
            UserCommand = new RelayCommand<object>((p) => { return true; }, (p) => { UserWindow wd = new UserWindow(); wd.ShowDialog(); });
            StatisticalCommand = new RelayCommand<object>((p) => { return true; }, (p) => { StatisticalWindow wd = new StatisticalWindow(); wd.ShowDialog(); });
            TicketCommand = new RelayCommand<object>((p) => { return true; }, (p) => { TicketWindow wd = new TicketWindow(); wd.ShowDialog(); });

        
        }

        private ActionCommand loginCommand;

        public ICommand LoginCommand
        {
            get
            {
                if (loginCommand == null)
                {
                    loginCommand = new ActionCommand(Login);
                }

                return loginCommand;
            }
        }

        private void Login()
        {
        }
    }
}
