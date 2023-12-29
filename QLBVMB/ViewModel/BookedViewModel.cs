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
    public class BookedViewModel : BaseViewModel
    {
        private ObservableCollection<Booked> _BookedList;
        public ObservableCollection<Booked> BookedList { get { return _BookedList; } set { _BookedList = value; OnPropertyChanged(); } }

        private ObservableCollection<Ticket> _TicketList;
        public ObservableCollection<Ticket> TicketList { get { return _TicketList; } set { _TicketList = value; OnPropertyChanged(); } }

        private ObservableCollection<Checked_Baggage> _Checked_BaggageList;
        public ObservableCollection<Checked_Baggage> Checked_BaggageList { get { return _Checked_BaggageList; } set { _Checked_BaggageList = value; OnPropertyChanged(); } }

        public BookedViewModel()
        {
            //BookedList = new ObservableCollection<Booked>(DataProvider.Ins.DB.Bookeds);
            //TicketList = new ObservableCollection<Ticket>(DataProvider.Ins.DB.Tickets);
            //Checked_BaggageList = new ObservableCollection<Checked_Baggage>(DataProvider.Ins.DB.Checked_Baggage);

            var displayListBooked = DataProvider.Ins.DB.Bookeds.Where(x => x.Id_Booked == Id_Booked);

            AddBookedCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(Id_Booked))
                    return false;

                if (displayListBooked == null || displayListBooked.Count() != 0)
                { return false; }
                return true;
            }, (p) =>
            {
                var Booked = new Booked() { Id_Booked = Id_Booked};

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

        private string _Id_Booked;
        public string Id_Booked { get => _Id_Booked; set { _Id_Booked = value; OnPropertyChanged(); } }

        private string _Id_Seat;
        public string Id_Seat { get => _Id_Seat; set { _Id_Seat = value; OnPropertyChanged(); } }

        private string _Status;
        public string Status { get => _Status; set { _Status = value; OnPropertyChanged(); } }
        public ICommand AddBookedCommand { get; set; }
    }
}
