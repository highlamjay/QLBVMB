using QLBVMB.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

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
                if (string.IsNullOrEmpty(Id_Plane) || string.IsNullOrEmpty(Type_Plane) || string.IsNullOrEmpty(Brand))
                    return false;
                if (displayListPlane == null || displayListPlane.Count() != 0)
                    return false;
                return true;
            }, (p) =>
            {
                var Plane = new Plane() { Id_Plane = Id_Plane, Type_Plane = Type_Plane, Brand = Brand };
                DataProvider.Ins.DB.Planes.Add(Plane);
                DataProvider.Ins.DB.SaveChanges();
                PlaneList.Add(Plane);
            });

            EditPlaneCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(Id_Plane) || string.IsNullOrEmpty(Type_Plane) || string.IsNullOrEmpty(Brand))
                    return false;
                if (PlaneSelectedItem == null)
                    return false;           
                if (displayListPlane != null && displayListPlane.Count() != 0)
                    return true;
                return false;
            }, (p) =>
            {

                var Plane = DataProvider.Ins.DB.Planes.Where(x => x.Id_Plane == Id_Plane).SingleOrDefault();
                Plane.Id_Plane = Id_Plane;
                Plane.Type_Plane = Type_Plane;
                Plane.Brand = Brand;
                
                DataProvider.Ins.DB.SaveChanges();

                
            });

            DeletePlaneCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(Id_Plane) || string.IsNullOrEmpty(Type_Plane) || string.IsNullOrEmpty(Brand))
                    return false;
                if (PlaneSelectedItem == null)
                    return false;
                if (displayListPlane != null && displayListPlane.Count() != 0)
                    return true;
                foreach(var item in PlaneList)
                {
                    if (Type_Plane == item.Type_Plane && Brand == item.Brand)
                        return true;
                }
                return false;
            }, (p) =>
            {
                DataProvider.Ins.DB.Planes.Remove(PlaneSelectedItem);
                DataProvider.Ins.DB.SaveChanges();

                PlaneList.Remove(PlaneSelectedItem);
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
                    Type_Plane = PlaneSelectedItem.Type_Plane;
                    Brand = PlaneSelectedItem.Brand;
                   
                }
            }
        }

        private string _Id_Plane;
        public string Id_Plane { get => _Id_Plane; set { _Id_Plane = value; OnPropertyChanged(); } }

        private string _Type_Plane;
        public string Type_Plane { get => _Type_Plane; set { _Type_Plane = value; OnPropertyChanged(); } }

        private string _Brand;
        public string Brand { get => _Brand; set { _Brand = value; OnPropertyChanged(); } }

        public ICommand AddPlaneCommand { get; set; }
        public ICommand EditPlaneCommand { get; set; }
        public ICommand DeletePlaneCommand { get; set; }
    }
}
