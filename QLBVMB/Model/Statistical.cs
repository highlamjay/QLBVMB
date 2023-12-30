using QLBVMB.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBVMB.Model
{
    public class Statistical : BaseViewModel
    {
        private string _Id_Flight;
        public string Id_Flight { get => _Id_Flight; set { _Id_Flight = value; OnPropertyChanged(); } }

        private int _SumSeat;
        public int SumSeat { get => _SumSeat; set { _SumSeat = value; OnPropertyChanged(); } }

        private int _SumSeatBooked;
        public int SumSeatBooked { get => _SumSeatBooked; set { _SumSeatBooked = value; OnPropertyChanged(); } }

        private int _Revenue;
        public int Revenue { get => _Revenue; set { _Revenue = value; OnPropertyChanged(); } }
    }
}
