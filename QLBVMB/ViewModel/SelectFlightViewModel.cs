using QLBVMB.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;

namespace QLBVMB.ViewModel
{
    public class SelectFlightViewModel : BaseViewModel
    {
        public bool Isloaded = false;
        public bool IsLSelectFlight { get; set; }
        public ICommand LoadedSelectCommand { get; set; }
        public ICommand SelectFlightCommand { get; set; }
        public ICommand ExitCommand { get; set; }

        private ObservableCollection<Flight> _FlightList;
        public ObservableCollection<Flight> FlightList { get { return _FlightList; } set { _FlightList = value; OnPropertyChanged(); } }

        public SelectFlightViewModel()
        {
            LoadedSelectCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                FlightList = new ObservableCollection<Flight>(DataProvider.Ins.DB.Flights);
            }
            );
        }

    }

}
