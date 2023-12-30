using QLBVMB.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBVMB.ViewModel
{
    public class StatisticalViewModel : BaseViewModel
    {
        private ObservableCollection<Statistical> _StatisticalList;
        public ObservableCollection<Statistical> StatisticalList { get { return _StatisticalList; } set { _StatisticalList = value; OnPropertyChanged(); } }

        private ObservableCollection<Statistical> _StatisticalListFull;
        public ObservableCollection<Statistical> StatisticalListFull { get { return _StatisticalListFull; } set { _StatisticalListFull = value; OnPropertyChanged(); } }
        public StatisticalViewModel()
        {
            StatisticalList = new ObservableCollection<Statistical>();

            var booked = DataProvider.Ins.DB.Bookeds;

            foreach (var book in booked)
            {
                var ticket = DataProvider.Ins.DB.Tickets.Where(x => x.Id_Ticket == book.Id_Ticket).FirstOrDefault();
                var cb = DataProvider.Ins.DB.Checked_Baggage.Where(x => x.Id_CB == book.Id_CB).FirstOrDefault();

                int sum = 1;
                int count = (int)(ticket.Price + cb.Extra_Price);
                Statistical statistical = new Statistical();
                statistical.Id_Flight = ticket.Id_Flight;
                statistical.SumSeat = (int)book.Flight.Total_Seat;
                statistical.SumSeatBooked = 1;
                statistical.Revenue = count;

                StatisticalList.Add(statistical);

            }
            var finalStatistical = StatisticalList.GroupBy(item => new {item.Id_Flight, item.SumSeat}).Select(group => new Statistical
            {
                Id_Flight = group.Key.Id_Flight,
                SumSeat = group.Key.SumSeat,
                SumSeatBooked = group.Sum(x=>x.SumSeatBooked),
                Revenue = group.Sum(x=>x.Revenue)
            });
            StatisticalListFull = new ObservableCollection<Statistical>(finalStatistical);
        }
    }
}
