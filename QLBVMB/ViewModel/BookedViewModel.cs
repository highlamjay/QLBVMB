using QLBVMB.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QLBVMB.ViewModel
{
    public class BookedViewModel : BaseViewModel
    {
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
        public BookedViewModel()
        {

            BookedList = new ObservableCollection<Booked>(DataProvider.Ins.DB.Bookeds);
            TicketList = new ObservableCollection<Ticket>(DataProvider.Ins.DB.Tickets);
            Checked_BaggageList = new ObservableCollection<Checked_Baggage>(DataProvider.Ins.DB.Checked_Baggage);
            AccountList = new ObservableCollection<Account>(DataProvider.Ins.DB.Accounts);
            CustomerList = new ObservableCollection<Customer>(DataProvider.Ins.DB.Customers);

            var displayListBooked = DataProvider.Ins.DB.Bookeds.Where(x => x.Id_Booked == Id_Booked);
            var displayListTicket = DataProvider.Ins.DB.Bookeds.Where(x => x.Id_Ticket == SelectedTicket.Id_Ticket);

            AddBookedCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(Id_Booked))
                    return false;

                if (displayListBooked == null || displayListBooked.Count() != 0)
                    return false;
                if (displayListTicket == null || displayListTicket.Count() != 0)
                    return false;


                return true;
            }, (p) =>
            {
                var Booked = new Booked() { Id_Booked = Id_Booked, Date = Date, Id_Ticket = SelectedTicket.Id_Ticket, Id_Customer = SelectedCustomer.Id_Customer, Id_CB = SelectedCB.Id_CB, Id_AccountSeller = SelectedAccount.Id_Account, Id_Flight = Id_Flight};
                var ticket = DataProvider.Ins.DB.Tickets.Where(x => x.Id_Ticket == SelectedTicket.Id_Ticket).SingleOrDefault();
                ticket.Id_Ticket = SelectedTicket.Id_Ticket;
                ticket.Id_Flight = SelectedTicket.Id_Flight;
                ticket.Type_Ticket = SelectedTicket.Type_Ticket;
                ticket.Id_Seat = SelectedTicket.Id_Seat;
                ticket.Price = SelectedTicket.Price;
                ticket.Status = "Booked";

                DataProvider.Ins.DB.Bookeds.Add(Booked);
                DataProvider.Ins.DB.SaveChanges();
                BookedList.Add(Booked);
            });
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
                    SelectedTicket = BookedSelectedItem.Ticket;
                    SelectedCB = BookedSelectedItem.Checked_Baggage;
                    Id_Seat = BookedSelectedItem.Ticket.Id_Seat;
                    Date = BookedSelectedItem.Date;
                    SelectedAccount = BookedSelectedItem.Account;
                    SelectedCustomer = BookedSelectedItem.Customer;
                    Name = BookedSelectedItem.Customer.Name;
                    Age = BookedSelectedItem.Customer.Age;
                    Sex = BookedSelectedItem.Customer.Sex;
                    Tel = BookedSelectedItem.Customer.Tel;
                    Email = BookedSelectedItem.Customer.Email;
                    Name_Locate = BookedSelectedItem.Customer.Locate1.Name_Locate;                  
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
        private Account _SelectedAccount;
        public Account SelectedAccount
        {
            get => _SelectedAccount;
            set
            {
                _SelectedAccount = value;
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

        private string _Id_Booked;
        public string Id_Booked { get => _Id_Booked; set { _Id_Booked = value; OnPropertyChanged(); } }

        private string _Id_Ticket;
        public string Id_Ticket { get => _Id_Ticket; set { _Id_Ticket = value; OnPropertyChanged(); } }

        private string _Id_Seat;
        public string Id_Seat { get => _Id_Seat; set { _Id_Seat = value; OnPropertyChanged(); } }

        private string _Id_Flight;
        public string Id_Flight { get => _Id_Flight; set { _Id_Flight = value; OnPropertyChanged(); } }

        private string _Status;
        public string Status { get => _Status; set { _Status = value; OnPropertyChanged(); } }

        private Nullable<System.DateTime> _Date;
        public Nullable<System.DateTime> Date { get => _Date; set { _Date = value; OnPropertyChanged(); } }

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


    }
}
