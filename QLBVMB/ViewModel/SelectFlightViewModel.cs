using QLBVMB.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;

namespace QLBVMB.ViewModel
{
    public class SelectFlightViewModel : BaseViewModel
    {
        public bool IsSelect { get; set; }

        private string _Airport_Take_Off;
        public string Airport_Take_Off { get => _Airport_Take_Off; set { _Airport_Take_Off = value; OnPropertyChanged(); } }

        private string _Airport_Landing;
        public string Airport_Landing { get => _Airport_Landing; set { _Airport_Landing = value; OnPropertyChanged(); } }

        private DateTime _Time_Start;
        public DateTime Time_Start { get => _Time_Start; set { _Time_Start = value; OnPropertyChanged(); } }

        private DateTime _DateFlight;
        public DateTime DateFlight { get => _DateFlight; set { _DateFlight = value; OnPropertyChanged(); } }
        public ICommand LoadedSelectCommand { get; set; }
        public ICommand SelectFlightCommand { get; set; }
        public ICommand ExitCommand { get; set; }

        private ObservableCollection<Flight> _FlightListFull;
        public ObservableCollection<Flight> FlightListFull { get { return _FlightListFull; } set { _FlightListFull = value; OnPropertyChanged(); } }

        public SelectFlightViewModel()
        {
            LoadedSelectCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                FlightListFull = new ObservableCollection<Flight>();
                var flight = DataProvider.Ins.DB.Flights.Where(x=> x.Airport_Take_Off == SelectedAirport.Id_Airport && x.Airport_Landing == SelectedAirport1.Id_Airport && x.Time_Start.Day == DateFlight.Day && x.Time_Start.Month == DateFlight.Month && x.Time_Start.Year == DateFlight.Year);
                foreach (var item in flight)
                {                 
                    Flight itemFlight = new Flight();
                    itemFlight.Id_Flight = item.Id_Flight;
                    itemFlight.Plane = item.Plane;
                    itemFlight.Id_Flight = item.Id_Flight;
                    itemFlight.Time_Start = item.Time_Start;
                    itemFlight.Time_End = item.Time_End;
                    FlightListFull.Add(itemFlight);
                }
            }
            );
            SelectFlightCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                IsSelect = true;
                p.Close();
            }
            );
            ExitCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                p.Close();
            }
            );
        }

        private Airport _SelectedAirport;
        public Airport SelectedAirport
        {
            get => _SelectedAirport;
            set
            {
                _SelectedAirport = value;
                OnPropertyChanged();
            }
        }

        private Airport _SelectedAirport1;
        public Airport SelectedAirport1
        {
            get => _SelectedAirport1;
            set
            {
                _SelectedAirport1 = value;
                OnPropertyChanged();
            }
        }

        private Flight _FlightSelectedItem;
        public Flight FlightSelectedItem
        {
            get => _FlightSelectedItem;
            set
            {
                _FlightSelectedItem = value;
                OnPropertyChanged();
                
            }
        }

    }

}
