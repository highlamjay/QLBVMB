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
    public class FlightViewModel : BaseViewModel
    {
        private ObservableCollection<Flight> _FlightList;
        public ObservableCollection<Flight> FlightList { get { return _FlightList; } set { _FlightList = value; OnPropertyChanged(); } }

        private ObservableCollection<Airport> _AirportList;
        public ObservableCollection<Airport> AirportList { get { return _AirportList; } set { _AirportList = value; OnPropertyChanged(); } }

        private ObservableCollection<Plane> _PlaneList;
        public ObservableCollection<Plane> PlaneList { get { return _PlaneList; } set { _PlaneList = value; OnPropertyChanged(); } }

        public FlightViewModel()
        {
            FlightList = new ObservableCollection<Flight>(DataProvider.Ins.DB.Flights);
            AirportList = new ObservableCollection<Airport>(DataProvider.Ins.DB.Airports);
            PlaneList = new ObservableCollection<Plane>(DataProvider.Ins.DB.Planes);

            var displayListFlight = DataProvider.Ins.DB.Flights.Where(x => x.Id_Flight == Id_Flight);

            AddFlightCommand = new RelayCommand<object>((p) =>
            {
                if (AccountLogin.Position != "Quản lý") return false;
                if (string.IsNullOrEmpty(Id_Flight) || SelectedPlane == null || SelectedAirport == null || SelectedAirport1 == null || Time_Start == null || Time_End == null || Total_Seat == null)
                    return false;
                if (displayListFlight == null || displayListFlight.Count() != 0)
                    return false;
                return true;
            }, (p) =>
            {
                var Flight = new Flight()
                {
                    Id_Flight = Id_Flight,
                    Id_Plane = Id_Plane,
                    Airport_Take_Off = SelectedAirport.Id_Airport,
                    Airport_Landing = SelectedAirport1.Id_Airport,
                    Time_Start = Time_Start,
                    Time_End = Time_End,
                    Total_Seat = Total_Seat,
                };

                DataProvider.Ins.DB.Flights.Add(Flight);
                DataProvider.Ins.DB.SaveChanges();

                FlightList.Add(Flight);
            });

            EditFlightCommand = new RelayCommand<object>((p) =>
            {
                if (AccountLogin.Position != "Quản lý") return false;
                if (string.IsNullOrEmpty(Id_Flight) || SelectedPlane == null || SelectedAirport == null || SelectedAirport1 == null || Time_Start == null || Time_End == null || Total_Seat == null)
                    return false;
                if (FlightSelectedItem == null)
                    return false;
                var displayListFlight1 = DataProvider.Ins.DB.Flights.Where(x => x.Id_Flight == FlightSelectedItem.Id_Flight);
                if (displayListFlight1 != null && displayListFlight.Count() != 0)
                    return true;
                return false;
            }, (p) =>
            {
                var Flight = DataProvider.Ins.DB.Flights.Where(x => x.Id_Flight == FlightSelectedItem.Id_Flight).SingleOrDefault();
                Flight.Id_Flight = Id_Flight;
                Flight.Id_Plane = Id_Plane;
                Flight.Airport_Take_Off = SelectedAirport.Id_Airport;
                Flight.Airport_Landing = SelectedAirport1.Id_Airport;
                Flight.Time_Start = Time_Start;
                Flight.Time_End = Time_End;
                Flight.Total_Seat = Total_Seat;
                DataProvider.Ins.DB.SaveChanges();              
            });

            DeleteFlightCommand = new RelayCommand<object>((p) =>
            {
                if (AccountLogin.Position != "Quản lý") return false;
                if (string.IsNullOrEmpty(Id_Flight) || SelectedPlane == null || SelectedAirport == null || SelectedAirport1 == null || Time_Start == null || Time_End == null || Total_Seat == null)
                    return false;
                if (FlightSelectedItem == null)
                    return false;
                var displayListFlight1 = DataProvider.Ins.DB.Flights.Where(x => x.Id_Flight == FlightSelectedItem.Id_Flight);
                var TicketList = DataProvider.Ins.DB.Tickets.Where(x => x.Id_Flight == FlightSelectedItem.Id_Flight);
                foreach ( var ticket in TicketList )
                {
                    if (ticket.Status == "Booked")
                        return false;
                }
                if (displayListFlight1 != null && displayListFlight.Count() != 0)
                    return true;
                return false;
            }, (p) =>
            {
                DataProvider.Ins.DB.Flights.Remove(FlightSelectedItem);
                DataProvider.Ins.DB.SaveChanges();

                FlightList.Remove(FlightSelectedItem);
            });
            ComboBoxClick = new RelayCommand<object>((p) => { return true; }, (p) => { AirportList = new ObservableCollection<Airport>(DataProvider.Ins.DB.Airports); });
            ComboBoxPlaneClick = new RelayCommand<object>((p) => { return true; }, (p) => { PlaneList = new ObservableCollection<Plane>(DataProvider.Ins.DB.Planes); });
        }

        private Plane _SelectedPlane;
        public Plane SelectedPlane
        {
            get => _SelectedPlane;
            set
            {
                _SelectedPlane = value;
                OnPropertyChanged();               
            }
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
                if (FlightSelectedItem != null)
                {
                    Id_Flight = FlightSelectedItem.Id_Flight;
                    SelectedPlane = FlightSelectedItem.Plane;
                    SelectedAirport = FlightSelectedItem.Airport;
                    SelectedAirport1 = FlightSelectedItem.Airport1;
                    Time_Start = FlightSelectedItem.Time_Start;
                    Time_End = FlightSelectedItem.Time_End;
                    Total_Seat = FlightSelectedItem.Total_Seat;
                }
            }
        }
        
        private string _Id_Flight;
        public string Id_Flight { get => _Id_Flight; set { _Id_Flight = value; OnPropertyChanged(); } }

        private DateTime? _Time_Start;
        public DateTime? Time_Start { get => _Time_Start; set { _Time_Start = value; OnPropertyChanged(); } }

        private DateTime? _Time_End;
        public DateTime? Time_End { get => _Time_End; set { _Time_End = value; OnPropertyChanged(); } }

        private string _Id_Plane;
        public string Id_Plane { get => _Id_Plane; set { _Id_Plane = value; OnPropertyChanged(); } }

        private string _Airport_Take_Off;
        public string Airport_Take_Off { get => _Airport_Take_Off; set { _Airport_Take_Off = value; OnPropertyChanged(); } }

        private string _Airport_Landing;
        public string Airport_Landing { get => _Airport_Landing; set { _Airport_Landing = value; OnPropertyChanged(); } }

        private byte? _Total_Seat;
        public byte? Total_Seat { get => _Total_Seat; set { _Total_Seat = value; OnPropertyChanged(); } }

        public ICommand AddFlightCommand { get; set; }
        public ICommand EditFlightCommand { get; set; }
        public ICommand DeleteFlightCommand { get; set; }
        public ICommand ComboBoxClick {  get; set; }
        public ICommand ComboBoxPlaneClick { get; set; }
    }
}
