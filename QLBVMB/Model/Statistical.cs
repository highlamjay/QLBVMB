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
        public string Id_Flight { get; set; }
        public int SumSeat { get; set; }
        public int SumSeatBooked { get; set; }
        public int  Revenue { get; set; }
    }
}
