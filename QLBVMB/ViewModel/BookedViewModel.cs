using QLBVMB.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace QLBVMB.ViewModel
{
    public class BookedViewModel : BaseViewModel
    {
        Random random = new Random();

        public bool IsSelectLoaded = false;

        private ObservableCollection<Booked> _BookedList;
        public ObservableCollection<Booked> BookedList { get { return _BookedList; } set { _BookedList = value; OnPropertyChanged(); } }

        private ObservableCollection<Ticket> _TicketList;
        public ObservableCollection<Ticket> TicketList { get { return _TicketList; } set { _TicketList = value; OnPropertyChanged(); } }

        private ObservableCollection<Checked_Baggage> _Checked_BaggageList;
        public ObservableCollection<Checked_Baggage> Checked_BaggageList { get { return _Checked_BaggageList; } set { _Checked_BaggageList = value; OnPropertyChanged(); } }

        private ObservableCollection<Account> _AccountList;
        public ObservableCollection<Account> AccountList { get { return _AccountList; } set { _AccountList = value; OnPropertyChanged(); } }

        private ObservableCollection<Customer> _CustomerList;
        public ObservableCollection<Customer> CustomerList { get { return _CustomerList; } set { _CustomerList = value; OnPropertyChanged(); } }

        private ObservableCollection<Airport> _AirportList;
        public ObservableCollection<Airport> AirportList { get { return _AirportList; } set { _AirportList = value; OnPropertyChanged(); } }

        private ObservableCollection<Locate> _LocateList;
        public ObservableCollection<Locate> LocateList { get { return _LocateList; } set { _LocateList = value; OnPropertyChanged(); } }


        public BookedViewModel()
        {
            BookedList = new ObservableCollection<Booked>(DataProvider.Ins.DB.Bookeds);
            TicketList = new ObservableCollection<Ticket>(DataProvider.Ins.DB.Tickets);
            Checked_BaggageList = new ObservableCollection<Checked_Baggage>(DataProvider.Ins.DB.Checked_Baggage);
            CustomerList = new ObservableCollection<Customer>(DataProvider.Ins.DB.Customers);
            AirportList = new ObservableCollection<Airport>(DataProvider.Ins.DB.Airports);
            LocateList = new ObservableCollection<Locate>(DataProvider.Ins.DB.Locates);

            var displayListTicket = DataProvider.Ins.DB.Bookeds.Where(x => x.Id_Ticket == Id_Ticket);

            DateFlight = DateTime.Now;

            AddBookedCommand = new RelayCommand<object>((p) =>
            {
                if (Id_Seat == null || DateFlight == null || Id_Flight == null || SelectedCB == null)
                    return false;
                if (SelectedCustomer == null || SelectedCustomer.Id_Customer == null)
                {
                    if (Name == null || Sex == null || Age == null || SelectedLocate == null || Email == null || Tel == null 
                    || Name == "" || Sex == "" || Email == "" || Tel == "" || Age.ToString() == "")
                        return false;
                    else return true;
                }
                if (displayListTicket == null || displayListTicket.Count() != 0)
                    return false;
                return true;
            }, (p) =>
            {
                if (Id_Customer == null)
                {
                    Customer customer = new Customer();
                    var customerList = DataProvider.Ins.DB.Customers;
                    while (true)
                    {
                        bool test = true;
                        customer.Id_Customer = random.Next(0, 1000000).ToString();
                        foreach (var item in customerList)
                        {
                            if (item.Id_Customer == customer.Id_Customer)
                            {
                                test = false;
                                break;
                            }
                        }
                        if (test)
                            break;
                    }
                    Id_Customer = customer.Id_Customer;
                    customer.Name = Name;
                    customer.Sex = Sex;
                    customer.Age = Age;
                    customer.Locate = SelectedLocate.Id_Locate;
                    customer.Email = Email;
                    customer.Tel = Tel;
                    customerList.Add(customer);
                    IsLoadedCustomerVM = false;
                }
                var book = DataProvider.Ins.DB.Bookeds;
                while (true)
                {
                    Id_Booked = random.Next(0, 1000000).ToString();
                    bool test = true;
                    foreach (var item in book)
                    {
                        if (item.Id_Booked == Id_Booked)
                        {
                            test = false; 
                            break;
                        }
                    }
                    if (test)
                        break;
                }
                var Booked = new Booked() 
                { 
                    Id_Booked = Id_Booked, 
                    Id_Customer = Id_Customer,
                    Id_Ticket = Id_Ticket,
                    Id_CB = SelectedCB.Id_CB,
                    Date = DateTime.Now,
                    Id_Flight = Id_Flight,
                    Account = AccountLogin
                };
                var ticket = DataProvider.Ins.DB.Tickets.Where(x => x.Id_Ticket == Id_Ticket).SingleOrDefault();
                ticket.Status = "Booked";

                DataProvider.Ins.DB.Bookeds.Add(Booked);
                DataProvider.Ins.DB.SaveChanges();
                BookedList.Add(Booked);
            });
            DeleteBookedCommand = new RelayCommand<object>((p) =>
            {
                if (AccountLogin.Position != "Quản lý") 
                    return false;
                if (DateFlight == null || SelectedCustomer == null)
                    return false;
                if (BookedSelectedItem == null)
                    return false;
                var displayListBook = DataProvider.Ins.DB.Bookeds.Where(x => x.Id_Booked == BookedSelectedItem.Id_Booked);
                if (displayListBook != null && displayListBook.Count() != 0)
                    return true;
                return false;
            }, (p) =>
            {
                var ticket = DataProvider.Ins.DB.Tickets.Where(x => x.Id_Ticket == BookedSelectedItem.Id_Ticket).SingleOrDefault();
                ticket.Status = "Remained";

                DataProvider.Ins.DB.Bookeds.Remove(BookedSelectedItem);
                DataProvider.Ins.DB.SaveChanges();

                BookedList.Remove(BookedSelectedItem);
            });

            ComboBoxIDKhackHang_Click = new RelayCommand<object>((p) => { return true; }, (p) => { CustomerList = new ObservableCollection<Customer>(DataProvider.Ins.DB.Customers); CustomerList.Add(new Customer()); });
            TabItemClick = new RelayCommand<object>((p) => { return true; }, (p) => { if (!IsLoadedBooked) { BookedList = new ObservableCollection<Booked>(DataProvider.Ins.DB.Bookeds); IsLoadedBooked = true; } });
            ComboBoxClick = new RelayCommand<object>((p) => { return true; }, (p) => { AirportList = new ObservableCollection<Airport>(DataProvider.Ins.DB.Airports); });

            TextBoxIDFlight_Click = new RelayCommand<TextBox>((p) => 
                {
                    return true;
                }, (p) => 
                {
                    if (SelectedAirport == null || SelectedAirport1 == null || DateFlight == null)
                    {
                        MessageBox.Show("Chưa chọn nơi khởi hành, nơi cất cách hoặc ngày bay");
                        return;
                    }

                    if (p == null)
                    {
                        return;
                    }

                    SelectFlight selectWindow = new SelectFlight();
                    var selectFlightVM = selectWindow.DataContext as SelectFlightViewModel;
                    selectFlightVM.SelectedAirport = SelectedAirport;
                    selectFlightVM.SelectedAirport1 = SelectedAirport1;
                    selectFlightVM.DateFlight = DateFlight;
                    
                    selectWindow.ShowDialog();

                    if (selectFlightVM.IsSelect == true)
                    {              
                        selectFlightVM.IsSelect = false;
                        Id_Flight = selectFlightVM.FlightSelectedItem.Id_Flight;
                    }

                    
                }
            );

            TextBoxIDSeat_Click = new RelayCommand<TextBox>((p) => { return true; }, (p) =>           
            {
                if (Id_Flight == null)
                {
                    MessageBox.Show("Chưa chọn mã chuyến bay");
                    return;
                }

                if (p == null)
                {
                    return;
                }

                SelectSeat selectWindow = new SelectSeat();
                var selectSeatVM = selectWindow.DataContext as SelectSeatViewModel;
                selectSeatVM.Id_Flight = Id_Flight;
     
                selectWindow.ShowDialog();

                if (selectSeatVM.IsSelect == true)
                {
                    selectSeatVM.IsSelect = false;
                    Id_Seat = selectSeatVM.SeatSelectedItem.Id_Seat;
                    Id_Ticket = selectSeatVM.SeatSelectedItem.Id_Ticket;
                }
            }
            );

            TextBoxIDCustomer_Click = new RelayCommand<TextBox>((p) => { return true; }, (p) =>
            {
                if (p == null)
                {
                    return;
                }

                SelectCustomer selectWindow = new SelectCustomer();
                var selectCustomerVM = selectWindow.DataContext as SelectCustomerViewModel;
                selectCustomerVM.Id_Customer = Id_Customer;

                selectWindow.ShowDialog();

                if (selectCustomerVM.IsSelect == true)
                {
                    selectCustomerVM.IsSelect = false;
                    Id_Customer = selectCustomerVM.CustomerSelectedItem.Id_Customer;
                    Name = selectCustomerVM.CustomerSelectedItem.Name;
                    Sex = selectCustomerVM.CustomerSelectedItem.Sex;
                    Age = selectCustomerVM.CustomerSelectedItem.Age;
                    Email = selectCustomerVM.CustomerSelectedItem.Email;
                    Tel = selectCustomerVM.CustomerSelectedItem.Tel;
                    SelectedLocate = selectCustomerVM.CustomerSelectedItem.Locate1;
                }
            }
            );
        }


        private Booked _BookedSelectedItem;
        public Booked BookedSelectedItem
        {
            get => _BookedSelectedItem;
            set
            {
                _BookedSelectedItem = value;
                OnPropertyChanged();
                if (BookedSelectedItem != null)
                {
                    Id_Booked = BookedSelectedItem.Id_Booked;
                    Id_Ticket = BookedSelectedItem.Id_Ticket;

                    SelectedAirport = BookedSelectedItem.Flight.Airport;
                    SelectedAirport1 = BookedSelectedItem.Flight.Airport1;
                    DateFlight = BookedSelectedItem.Flight.Time_Start.Date;
                    Id_Flight = BookedSelectedItem.Id_Flight;
                    SelectedCB = BookedSelectedItem.Checked_Baggage;
                    Id_Seat = BookedSelectedItem.Ticket.Id_Seat;
                    
                    SelectedCustomer = BookedSelectedItem.Customer;
                    Name = BookedSelectedItem.Customer.Name;
                    Age = BookedSelectedItem.Customer.Age;
                    Sex = BookedSelectedItem.Customer.Sex;
                    Tel = BookedSelectedItem.Customer.Tel;
                    Email = BookedSelectedItem.Customer.Email;
                    SelectedLocate = BookedSelectedItem.Customer.Locate1;              
                }
            }
        }
        private Ticket _SelectedTicket;
        public Ticket SelectedTicket
        {
            get => _SelectedTicket;
            set
            {
                _SelectedTicket = value;
                OnPropertyChanged();
                var ticket = DataProvider.Ins.DB.Tickets.Where(x => x.Id_Ticket == SelectedTicket.Id_Ticket).SingleOrDefault();
                Id_Seat = ticket.Id_Seat;
                Id_Flight = ticket.Id_Flight;
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

        private Customer _SelectedCustomer;
        public Customer SelectedCustomer
        {
            get => _SelectedCustomer;
            set
            {
                _SelectedCustomer = value;
                OnPropertyChanged();
                var customer = DataProvider.Ins.DB.Customers.Where(x => x.Id_Customer == SelectedCustomer.Id_Customer).SingleOrDefault();
                Name = customer.Name;
                Age = customer.Age;
                Sex = customer.Sex;
                Tel = customer.Tel;
                Email = customer.Email;
                Name_Locate = customer.Locate1.Name_Locate;
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

        private string _Id_Booked;
        public string Id_Booked { get => _Id_Booked; set { _Id_Booked = value; OnPropertyChanged(); } }

        private DateTime _DateFlight;
        public DateTime DateFlight { get => _DateFlight; set { _DateFlight = value; OnPropertyChanged(); } }

        private DateTime _Date;
        public DateTime Date { get => _Date; set { _Date = value; OnPropertyChanged(); } }

        private string _Id_Flight;
        public string Id_Flight { get => _Id_Flight; set { _Id_Flight = value; OnPropertyChanged(); } }

        private string _Id_Ticket;
        public string Id_Ticket { get => _Id_Ticket; set { _Id_Ticket = value; OnPropertyChanged(); } }

        private string _Id_Seat;
        public string Id_Seat { get => _Id_Seat; set { _Id_Seat = value; OnPropertyChanged(); } }

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

        private string _Name_Locate;
        public string Name_Locate { get => _Name_Locate; set { _Name_Locate = value; OnPropertyChanged(); } }
        public ICommand AddBookedCommand { get; set; }
        public ICommand DeleteBookedCommand { get; set; }
        public ICommand ComboBoxIDKhackHang_Click {  get; set; }
        public ICommand TabItemClick { get; set; }
        public ICommand ComboBoxClick { get; set; }
        public ICommand TextBoxIDFlight_Click { get; set; }
        public ICommand TextBoxIDSeat_Click { get; set; }
        public ICommand TextBoxIDCustomer_Click { get; set; }
    }
}
