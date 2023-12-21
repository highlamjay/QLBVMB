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
    public class PlaneViewModel : BaseViewModel
    {
        private ObservableCollection<Plane> _PlaneList;
        public ObservableCollection<Plane> PlaneList { get { return _PlaneList; } set { _PlaneList = value; OnPropertyChanged(); } }
        public PlaneViewModel()
        {
            PlaneList = new ObservableCollection<Plane>(DataProvider.Ins.DB.Planes);
            var displayListPlane = DataProvider.Ins.DB.Planes.Where(x => x.Id_Plane == Id_Plane);

            AddPlaneCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(Id_Plane))
                    return false;

                if (displayListPlane == null || displayListPlane.Count() != 0)
                { return false; }
                return true;
            }, (p) =>
            {
                var Plane = new Plane() { Id_Plane = Id_Plane,Type_Plane = Type_Plane };

                DataProvider.Ins.DB.Planes.Add(Plane);
                DataProvider.Ins.DB.SaveChanges();

                PlaneList.Add(Plane);
            });

            EditPlaneCommand = new RelayCommand<object>((p) =>
            {
                if (PlaneSelectedItem == null)
                    return false;
                return true;
                //var displayListPlane1 = DataProvider.Ins.DB.Planes.Where(x => x.Id_Plane == PlaneSelectedItem.Id_Plane);
                //if (displayListPlane1 != null && displayListPlane.Count() != 0)
                //    return true;

                //return false;
            }, (p) =>
            {
                var Plane = DataProvider.Ins.DB.Planes.Where(x => x.Id_Plane == PlaneSelectedItem.Id_Plane).SingleOrDefault();
                Plane.Id_Plane = Id_Plane;
               
                DataProvider.Ins.DB.SaveChanges();
                //PlaneSelectedItem.DisplayName = DisplayName;
            });
        }
        private Plane _PlaneSelectedItem;
        public Plane PlaneSelectedItem
        {
            get => _PlaneSelectedItem;
            set
            {
                _PlaneSelectedItem = value;
                OnPropertyChanged();
                if (PlaneSelectedItem != null)
                {
                    Id_Plane = PlaneSelectedItem.Id_Plane;
                    
                }
            }
        }
        private string _Id_Plane;
        public string Id_Plane { get => _Id_Plane; set { _Id_Plane = value; OnPropertyChanged(); } }

        private string _Username;
        public string Username { get => _Username; set { _Username = value; OnPropertyChanged(); } }

        private string _Password;
        public string Password { get => _Password; set { _Password = value; OnPropertyChanged(); } }

        private string _Position;
        public string Position { get => _Position; set { _Position = value; OnPropertyChanged(); } }

        private string _DisplayName;
        public string DisplayName { get => _DisplayName; set { _DisplayName = value; OnPropertyChanged(); } }

        public ICommand AddPlaneCommand { get; set; }
        public ICommand EditPlaneCommand { get; set; }
    }
}
