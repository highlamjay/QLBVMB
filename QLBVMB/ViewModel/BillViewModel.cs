using QLBVMB.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace QLBVMB.ViewModel
{
    public class BillViewModel : BaseViewModel
    {
        private ObservableCollection<Bill> _BillList;
        public ObservableCollection<Bill> BillList { get { return _BillList; } set { _BillList = value; OnPropertyChanged(); } }

        private ObservableCollection<Booked> _BookedList;
        public ObservableCollection<Booked> BookedList { get { return _BookedList; } set { _BookedList = value; OnPropertyChanged(); } }
        public BillViewModel()
        {
            BillList = new ObservableCollection<Bill>();
            BookedList = new ObservableCollection<Booked>(DataProvider.Ins.DB.Bookeds);
            int i = 1;

            var booked = DataProvider.Ins.DB.Bookeds;
            foreach (var book in booked)
            {
                var customer = DataProvider.Ins.DB.Customers.Where(x => x.Id_Customer == book.Id_Customer).FirstOrDefault();
                var flight = DataProvider.Ins.DB.Flights.Where(x => x.Id_Flight == book.Id_Flight).FirstOrDefault();
                var ticket = DataProvider.Ins.DB.Tickets.Where(x => x.Id_Ticket == book.Id_Ticket).FirstOrDefault();
                var cb = DataProvider.Ins.DB.Checked_Baggage.Where(x => x.Id_CB == book.Id_CB).FirstOrDefault();

                int count = 0;
                int sum = 0;
                if (customer != null && flight != null)
                {
                    count++;
                }
                if (ticket != null && cb != null)
                {
                    sum += (int)ticket.Price + (int)cb.Extra_Price;
                }


                Bill bill = new Bill();

                bill.Booked = book;
                bill.Booked1 = book;
                bill.Id_Bill = i;
                bill.CountTicket = count;
                bill.SumMoney = sum;
                i++;
                BillList.Add(bill);


            }

        }
    }

}

