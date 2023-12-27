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
    public class ListViewModel : BaseViewModel  
    {
        private ObservableCollection<List> _List;
        public ObservableCollection<List> List { get { return _List; } set { _List = value; OnPropertyChanged(); } }

        private ObservableCollection<Ticket> _TicketList;
        public ObservableCollection<Ticket> TicketList { get { return _TicketList; } set { _TicketList = value; OnPropertyChanged(); } }

        private ObservableCollection<Locate> _LocateList;
        public ObservableCollection<Locate> LocateList { get { return _LocateList; } set { _LocateList = value; OnPropertyChanged(); } }

        private ObservableCollection<Customer> _CustomerList;
        public ObservableCollection<Customer> CustomerList { get { return _CustomerList; } set { _CustomerList = value; OnPropertyChanged(); } }

        private ObservableCollection<Flight> _FlightList;
        public ObservableCollection<Flight> FlightList { get { return _FlightList; } set { _FlightList = value; OnPropertyChanged(); } }

        private ObservableCollection<Checked_Baggage> _Checked_BaggageList;
        public ObservableCollection<Checked_Baggage> Checked_BaggageList { get { return _Checked_BaggageList; } set { _Checked_BaggageList = value; OnPropertyChanged(); } }

        Random r = new Random();
        public ListViewModel() 
        {
            
            List = new ObservableCollection<List>();
            Checked_BaggageList = new ObservableCollection<Checked_Baggage>(DataProvider.Ins.DB.Checked_Baggage);
            LocateList = new ObservableCollection<Locate>(DataProvider.Ins.DB.Locates);
            FlightList = new ObservableCollection<Flight>(DataProvider.Ins.DB.Flights);
            TicketList = new ObservableCollection<Ticket>(DataProvider.Ins.DB.Tickets);


            var displayListCustomer = DataProvider.Ins.DB.Customers.Where(x => x.Id_Customer == SelectedList.Id_Customer);
            var bookedList = DataProvider.Ins.DB.Bookeds;
            
            foreach (var item in bookedList)
            {
                var ticketList = DataProvider.Ins.DB.Tickets.Where(x => x.Id_Ticket == item.Id_Ticket).SingleOrDefault();
                var customerList = DataProvider.Ins.DB.Customers.Where(x => x.Id_Customer == item.Id_Customer).SingleOrDefault();

                List list =new List();

                list.Id_Ticket = item.Id_Ticket;
                list.Id_Customer = item.Id_Customer;
                list.Name = customerList.Name;
                list.Id_Flight = item.Id_Flight;
                list.Id_Seat = ticketList.Id_Seat;
                list.Status = ticketList.Status;
                list.Type_Ticket = ticketList.Type_Ticket;
                list.Price = (int)ticketList.Price;

                List.Add(list);
            }

            AddListCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(Id_Ticket) && string.IsNullOrEmpty(Id_Flight) )
                    return false;
               
                return true;
            }, (p) =>
            {
                int ran = r.Next(100000, 999999);
                foreach (var i in bookedList)
                {
                    if (i.Id_Booked == ran.ToString())
                    {
                        ran = r.Next(100000, 999999999);
                    }

                }

                int ran_cus = r.Next(100000, 999999);
                foreach (var i in bookedList)
                {
                    if (i.Id_Booked == ran_cus.ToString())
                    {
                        ran_cus = r.Next(100000, 999999999);
                    }

                }
                string id = ran_cus.ToString();
                var customer = DataProvider.Ins.DB.Customers.Where(x=> x.Tel == Tel).Count();
                if (customer == 0)
                {
                    
                    var cus = new Customer() { Id_Customer = ran_cus.ToString(), Name = Name, Locate = SelectedLocate.Id_Locate, Age = Age, Sex = Sex, Email = Email, Tel = Tel };


                    DataProvider.Ins.DB.Customers.Add(cus);
                    DataProvider.Ins.DB.SaveChanges();
                }
                var booked = new Booked() { Id_Booked = ran.ToString(), Date = DateTime.Now , Id_Flight = Id_Flight, Id_Ticket = Id_Ticket, Id_Customer = Id_Customer, Id_CB = SelectedCB.Id_CB};
                DataProvider.Ins.DB.Bookeds.Add(booked);
                DataProvider.Ins.DB.SaveChanges();

                //var list = new List() { Id_Ticket = Id_Ticket, Id_Customer = Id_Customer, Name = Name ,Id_Flight = Id_Flight , Id_Seat = Id_Seat, Type_Ticket = Type_Ticket, Price = Price, Status = "Booked"};
                //List.Add(list);
            });
        }
        private List _SelectedList;
        public List SelectedList
        {
            get => _SelectedList;
            set
            {
                _SelectedList = value;
                OnPropertyChanged();
                if (SelectedList != null)
                {
                    var customer = DataProvider.Ins.DB.Customers.Where(x => x.Id_Customer == SelectedList.Id_Customer).SingleOrDefault();
                    var ticket = DataProvider.Ins.DB.Tickets.Where(x => x.Id_Ticket == SelectedList.Id_Ticket).SingleOrDefault();
                    var bookedList = DataProvider.Ins.DB.Bookeds.Where(x=> x.Id_Ticket == SelectedList.Id_Ticket).SingleOrDefault();
                    
                    Name = SelectedList.Name;
                    Age = customer.Age;
                    Sex = customer.Sex;
                    Email = customer.Email;
                    Tel = customer.Tel;
                    Id_Locate = customer.Locate;
                    SelectedCB = bookedList.Checked_Baggage;
                    SelectedLocate = customer.Locate1;
                    Id_Ticket = SelectedList.Id_Ticket;
                    SelectedFlight = bookedList.Flight;
                    Type_Ticket = SelectedList.Type_Ticket;
                    SelectedSeat = bookedList.Ticket;
                    Price = SelectedList.Price;                  
                }
            }
        }

        private Checked_Baggage _SelectedCB;
        public Checked_Baggage SelectedCB
        {
            get => _SelectedCB;
            set
            {
                _SelectedCB = value;
                OnPropertyChanged();
                
            }
        }

        private Locate _SelectedLocate;
        public Locate SelectedLocate
        {
            get => _SelectedLocate;
            set
            {
                _SelectedLocate = value;
                OnPropertyChanged();

            }
        }

        private Ticket _SelectedSeat;
        public Ticket SelectedSeat
        {
            get => _SelectedSeat;
            set
            {
                _SelectedSeat = value;
                OnPropertyChanged();

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

        public ICommand AddListCommand { get; set; }

        private string _Id_Ticket;
        public string Id_Ticket { get => _Id_Ticket; set { _Id_Ticket = value; OnPropertyChanged(); } }

        private string _Id_Customer;
        public string Id_Customer { get => _Id_Customer; set { _Id_Customer = value; OnPropertyChanged(); } }

        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }

        private Nullable<byte> _Age;
        public Nullable<byte> Age { get => _Age; set { _Age = value; OnPropertyChanged(); } }

        private string _Sex;
        public string Sex { get => _Sex; set { _Sex = value; OnPropertyChanged(); } }

        private string _Email;
        public string Email { get => _Email; set { _Email = value; OnPropertyChanged(); } }

        private string _Tel;
        public string Tel { get => _Tel; set { _Tel = value; OnPropertyChanged(); } }

        private string _Id_Locate;
        public string Id_Locate { get => _Id_Locate; set { _Id_Locate = value; OnPropertyChanged(); } }

        private string _Id_Flight;
        public string Id_Flight { get => _Id_Flight; set { _Id_Flight = value; OnPropertyChanged(); } }

        private string _Type_Ticket;
        public string Type_Ticket { get => _Type_Ticket; set { _Type_Ticket = value; OnPropertyChanged(); } }

        private string _Id_Seat;
        public string Id_Seat { get => _Id_Seat; set { _Id_Seat = value; OnPropertyChanged(); } }

        private int _Price;
        public int Price { get => _Price; set { _Price = value; OnPropertyChanged(); } }


    }
    
}
