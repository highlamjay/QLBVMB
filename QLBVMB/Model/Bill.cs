using QLBVMB.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBVMB.Model
{
    public class Bill : BaseViewModel
    {
        private int _Id_Bill;
        public int Id_Bill { get => _Id_Bill; set { _Id_Bill = value; OnPropertyChanged(); } }

        private int _CountTicket;
        public int CountTicket { get => _CountTicket; set { _CountTicket = value; OnPropertyChanged(); } }

        private int _SumMoney;
        public int SumMoney { get => _SumMoney; set { _SumMoney = value; OnPropertyChanged(); } }

        private string _Id_Flight;
        public string Id_Flight { get => _Id_Flight; set { _Id_Flight = value; OnPropertyChanged(); } }

        private string _Id_Customer;
        public string Id_Customer { get => _Id_Customer; set { _Id_Customer = value; OnPropertyChanged(); } }

    }
}
