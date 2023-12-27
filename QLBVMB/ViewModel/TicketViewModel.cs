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
    public class TicketViewModel : BaseViewModel
    {
        private ObservableCollection<Ticket> _TicketList;
        public ObservableCollection<Ticket> TicketList { get { return _TicketList; } set { _TicketList = value; OnPropertyChanged(); } }

       
        public TicketViewModel()
        {
            TicketList = new ObservableCollection<Ticket>(DataProvider.Ins.DB.Tickets);          

            var displayListTicket = DataProvider.Ins.DB.Tickets.Where(x => x.Id_Ticket == Id_Ticket);
          

            AddTicketCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(Id_Ticket))
                    return false;

                if ((displayListTicket != null && displayListTicket.Count() != 0))
                    return false;
                return true;
            }, (p) =>
            {
                var Ticket = new Ticket() { Id_Ticket = Id_Ticket  };

                DataProvider.Ins.DB.Tickets.Add(Ticket);
                DataProvider.Ins.DB.SaveChanges();

                TicketList.Add(Ticket);
            });
           
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
                    
                }
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
        private string _Id_Ticket;
        public string Id_Ticket { get => _Id_Ticket; set { _Id_Ticket = value; OnPropertyChanged(); } }

        private string _Type_Ticket;
        public string Type_Ticket { get => _Type_Ticket; set { _Type_Ticket = value; OnPropertyChanged(); } }

        private string _Id_Seat;
        public string Id_Seat { get => _Id_Seat; set { _Id_Seat = value; OnPropertyChanged(); } }

        private int _Price;
        public int Price { get => _Price; set { _Price = value; OnPropertyChanged(); } }

        private string _Status;
        public string Status { get => _Status; set { _Status = value; OnPropertyChanged(); } }

        private string _Id_Flight;
        public string Id_Flight { get => _Id_Flight; set { _Id_Flight = value; OnPropertyChanged(); } }
        public ICommand AddTicketCommand { get; set; }
       
    }
}
