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
        public int Id_Bill { get; set; }
        public int CountTicket { get; set; }
        public int SumMoney { get; set; }
        public Booked Booked { get; set; }
        public Booked Booked1 { get; set; }
    }
}
