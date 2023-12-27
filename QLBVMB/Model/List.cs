using QLBVMB.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBVMB.Model
{
    public class List : BaseViewModel
    {
        private string _Id_Flight;
        public string Id_Flight { get => _Id_Flight; set { _Id_Flight = value; OnPropertyChanged(); } }

        private string _Type_Ticket;
        public string Type_Ticket { get => _Type_Ticket; set { _Type_Ticket = value; OnPropertyChanged(); } }

        private string _Id_Seat;
        public string Id_Seat { get => _Id_Seat; set { _Id_Seat = value; OnPropertyChanged(); } }

        private int _Price;
        public int Price { get => _Price; set { _Price = value; OnPropertyChanged(); } }

        private string _Id_Ticket;
        public string Id_Ticket { get => _Id_Ticket; set { _Id_Ticket = value; OnPropertyChanged(); } }

        private string _Id_Customer;
        public string Id_Customer { get => _Id_Customer; set { _Id_Customer = value; OnPropertyChanged(); } }

        private string _Name;
        public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }

        private string _Status;
        public string Status { get => _Status; set { _Status = value; OnPropertyChanged(); } }

    }
}
