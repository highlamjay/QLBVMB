using QLBVMB.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace QLBVMB.ViewModel
{
    public class SelectSeatViewModel : BaseViewModel
    {
        public bool IsSelect { get; set; }

        private string _Id_Flight;
        public string Id_Flight { get => _Id_Flight; set { _Id_Flight = value; OnPropertyChanged(); } }

        public ICommand LoadedSelectCommand { get; set; }
        public ICommand SelectSeatCommand { get; set; }
        public ICommand ExitCommand { get; set; }

        private ObservableCollection<Ticket> _SeatListFull;
        public ObservableCollection<Ticket> SeatListFull { get { return _SeatListFull; } set { _SeatListFull = value; OnPropertyChanged(); } }

        public SelectSeatViewModel()
        {
            LoadedSelectCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                SeatListFull = new ObservableCollection<Ticket>();
                var ticket = DataProvider.Ins.DB.Tickets.Where(x => x.Id_Flight == Id_Flight && x.Status == "Remained");
                foreach (var item in ticket)
                {
                    Ticket ticketitem = new Ticket();
                    ticketitem.Id_Seat = item.Id_Seat;
                    ticketitem.Type_Ticket = item.Type_Ticket;
                    ticketitem.Price = item.Price;
                    SeatListFull.Add(ticketitem);
                }

            }
            );
            SelectSeatCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
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
        private Ticket _SeatSelectedItem;
        public Ticket SeatSelectedItem
        {
            get => _SeatSelectedItem;
            set
            {
                _SeatSelectedItem = value;
                OnPropertyChanged();

            }
        }
    }
}
