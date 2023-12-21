using QLBVMB.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QLBVMB.ViewModel
{
    public class AirportViewModel : BaseViewModel
    {
        private ObservableCollection<Airport> _AirportList;
        public ObservableCollection<Airport> AirportList { get { return _AirportList; } set { _AirportList = value; OnPropertyChanged(); } }

        private ObservableCollection<Locate> _LocateList;
        public ObservableCollection<Locate> LocateList { get { return _LocateList; } set { _LocateList = value; OnPropertyChanged(); } }
        public AirportViewModel()
        {
            AirportList = new ObservableCollection<Airport>(DataProvider.Ins.DB.Airports);
            LocateList = new ObservableCollection<Locate>(DataProvider.Ins.DB.Locates);

            var displayListAirport = DataProvider.Ins.DB.Airports.Where(x => x.Id_Airport == Id_Airport);
            var displayListLocate = DataProvider.Ins.DB.Airports.Where(x => x.Id_Locate == SelectedLocate.Id_Locate);

            AddAirportCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(Id_Airport) && string.IsNullOrEmpty(Name_Airport))
                    return false;

                if ((displayListAirport != null && displayListAirport.Count() != 0))
                    return false;
                return true;
            }, (p) =>
            {
                var airport = new Airport() { Id_Airport = Id_Airport, Name_Airport = Name_Airport, Id_Locate = SelectedLocate.Id_Locate};

                DataProvider.Ins.DB.Airports.Add(airport);
                DataProvider.Ins.DB.SaveChanges();

                AirportList.Add(airport);
            });

            EditAirportCommand = new RelayCommand<object>((p) =>
            {
                if (AirportSelectedItem == null)
                    return false;
               
                if ( AirportSelectedItem.Locate.Id_Locate == SelectedLocate.Id_Locate)
                    return true;                   
                return false;
            }, (p) =>
            {
                var Airport = DataProvider.Ins.DB.Airports.Where(x => x.Id_Airport == AirportSelectedItem.Id_Airport).SingleOrDefault();
                Airport.Id_Airport = Id_Airport;
                Airport.Name_Airport = Name_Airport;
                Airport.Id_Locate = SelectedLocate.Id_Locate;
                DataProvider.Ins.DB.SaveChanges();

            });
            DeleteAirportCommand = new RelayCommand<object>((p) =>
            {
                if (AirportSelectedItem != null)
                    return true;
                return false;
            }, (p) =>
            {
                var airport = new Airport() { Id_Airport = Id_Airport, Name_Airport = Name_Airport, Id_Locate = SelectedLocate.Id_Locate };
                
                DataProvider.Ins.DB.Airports.Remove(AirportSelectedItem);
                DataProvider.Ins.DB.SaveChanges();

                AirportList.Remove(AirportSelectedItem);
            });
        }
        private Airport _AirportSelectedItem;
        public Airport AirportSelectedItem
        {
            get => _AirportSelectedItem;
            set
            {
                _AirportSelectedItem = value;
                OnPropertyChanged();
                if (AirportSelectedItem != null)
                {
                    Id_Airport = AirportSelectedItem.Id_Airport;
                    Name_Airport = AirportSelectedItem.Name_Airport;
                    SelectedLocate = AirportSelectedItem.Locate;
                }
            }
        }
        private Locate _SelectedLocate;
        public Locate SelectedLocate
        {
            get => _SelectedLocate;
            set
            {
                _SelectedLocate = value;
                OnPropertyChanged();          
            }
        }
        private string _Id_Airport;
        public string Id_Airport { get => _Id_Airport; set { _Id_Airport = value; OnPropertyChanged(); } }

        private string _Name_Airport;
        public string Name_Airport { get => _Name_Airport; set { _Name_Airport = value; OnPropertyChanged(); } }

        private string _Id_Locate;
        public string Id_Locate { get => _Id_Locate; set { _Id_Locate = value; OnPropertyChanged(); } }
        public ICommand AddAirportCommand { get; set; }
        public ICommand EditAirportCommand { get; set; }
        public ICommand DeleteAirportCommand { get; set; }
    }
}
