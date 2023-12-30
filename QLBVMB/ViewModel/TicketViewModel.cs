using QLBVMB.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;

namespace QLBVMB.ViewModel
{
    public class TicketViewModel : BaseViewModel
    {
        private ObservableCollection<Ticket> _TicketList;
        public ObservableCollection<Ticket> TicketList { get { return _TicketList; } set { _TicketList = value; OnPropertyChanged(); } }

        private ObservableCollection<Flight> _FlightList;
        public ObservableCollection<Flight> FlightList { get { return _FlightList; } set { _FlightList = value; OnPropertyChanged(); } }
        public TicketViewModel()
        {
            TicketList = new ObservableCollection<Ticket>(DataProvider.Ins.DB.Tickets);
            FlightList = new ObservableCollection<Flight>(DataProvider.Ins.DB.Flights);

            var displayListTicket = DataProvider.Ins.DB.Tickets.Where(x => x.Id_Ticket == Id_Ticket);

            AddTicketCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(Id_Ticket))
                    return false;

                if (displayListTicket == null || displayListTicket.Count() != 0)
                { return false; }
                
                return true;
            }, (p) =>
            {
                var Ticket = new Ticket() { Id_Ticket = Id_Ticket, Id_Flight = SelectedFlight.Id_Flight, Type_Ticket = Type_Ticket, Id_Seat = Id_Seat, Price= Price, Status = "Remained" };

                DataProvider.Ins.DB.Tickets.Add(Ticket);
                DataProvider.Ins.DB.SaveChanges();

                TicketList.Add(Ticket);
            });

            ComboBoxClick = new RelayCommand<object>((p) => { return true; }, (p) => { FlightList = new ObservableCollection<Flight>(DataProvider.Ins.DB.Flights); });
        }
        private Ticket _TicketSelectedItem;
        public Ticket TicketSelectedItem
        {
            get => _TicketSelectedItem;
            set
            {
                _TicketSelectedItem = value;
                OnPropertyChanged();
                if (TicketSelectedItem != null)
                {
                    Id_Ticket = TicketSelectedItem.Id_Ticket;
                    SelectedFlight = TicketSelectedItem.Flight;
                    Type_Ticket = TicketSelectedItem.Type_Ticket;
                    Id_Seat = TicketSelectedItem.Id_Seat;
                    Price = TicketSelectedItem.Price;
                }
            }
        }
        private Flight _SelectedFlight;
        public Flight SelectedFlight
        {
            get => _SelectedFlight;
            set
            {
                _SelectedFlight = value;
                OnPropertyChanged();
            }
        }

        private string _Id_Ticket;
        public string Id_Ticket { get => _Id_Ticket; set { _Id_Ticket = value; OnPropertyChanged(); } }

        private string _Id_Seat;
        public string Id_Seat { get => _Id_Seat; set { _Id_Seat = value; OnPropertyChanged(); } }

        private string _Type_Ticket;
        public string Type_Ticket { get => _Type_Ticket; set { _Type_Ticket = value; OnPropertyChanged(); } }

        private Nullable<decimal> _Price;
        public Nullable<decimal> Price { get => _Price; set { _Price = value; OnPropertyChanged(); } }

        private string _Status;
        public string Status { get => _Status; set { _Status = value; OnPropertyChanged(); } }
        public ICommand AddTicketCommand { get; set; }
       
        public ICommand ComboBoxClick {  get; set; }
    }
}
