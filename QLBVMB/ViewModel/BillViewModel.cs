using QLBVMB.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace QLBVMB.ViewModel
{
    public class BillViewModel : BaseViewModel
    {
        private ObservableCollection<Bill> _BillList;
        public ObservableCollection<Bill> BillList { get { return _BillList; } set { _BillList = value; OnPropertyChanged(); } }

        private ObservableCollection<Bill> _BillListFull;
        public ObservableCollection<Bill> BillListFull { get { return _BillListFull; } set { _BillListFull = value; OnPropertyChanged(); } }

        private ObservableCollection<Bill> _BillItems;
        public ObservableCollection<Bill> BillItems { get { return _BillItems; } set { _BillItems = value; OnPropertyChanged(); } }

        Booked preId_Flight, preId_Customer = null;
        public BillViewModel()
        {
            BillList = new ObservableCollection<Bill>();
            BillListFull = new ObservableCollection<Bill>();

            UpdateData();
            BtClick = new RelayCommand<object>((p) => { return true; }, (p) => { UpdateData(); });
        }

        void UpdateData()
        {
            var booked = DataProvider.Ins.DB.Bookeds;

            BillList.Clear();
            foreach (var book in booked)
            {
                var ticket = DataProvider.Ins.DB.Tickets.Where(x => x.Id_Ticket == book.Id_Ticket).FirstOrDefault();
                var cb = DataProvider.Ins.DB.Checked_Baggage.Where(x => x.Id_CB == book.Id_CB).FirstOrDefault();

                int count = 1;
                int sum = (int)(ticket.Price + cb.Extra_Price);
                Bill bill = new Bill();
                bill.Id_Flight = book.Id_Flight;
                bill.Id_Customer = book.Id_Customer;
                bill.CountTicket = count;
                bill.SumMoney = sum;

                BillList.Add(bill);
            }

            var finalBill = BillList.GroupBy(item => new { item.Id_Flight, item.Id_Customer }).Select(group => new Bill
            {

                Id_Flight = group.Key.Id_Flight,
                Id_Customer = group.Key.Id_Customer,
                CountTicket = group.Sum(x => x.CountTicket),
                SumMoney = group.Sum(x => x.SumMoney)
            });

            BillListFull = new ObservableCollection<Bill>(finalBill);
            //BillItems = new ObservableCollection<Bill>(finalBill);

            //int i = 1;
            //BillListFull.Clear();
            //foreach (var item in BillItems)
            //{
            //    Bill bill = new Bill();
            //    bill.Id_Bill = i;
            //    bill.Id_Flight = item.Id_Flight;
            //    bill.Id_Customer = item.Id_Customer;
            //    bill.CountTicket = item.CountTicket;
            //    bill.SumMoney = item.SumMoney;

            //    i++;
            //    BillListFull.Add(bill);

            //}
        }
        
        public ICommand BtClick {  get; set; }
    }

}

