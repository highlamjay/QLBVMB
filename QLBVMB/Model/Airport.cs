//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLBVMB.Model
{
    using QLBVMB.ViewModel;
    using System;
    using System.Collections.Generic;
    
    public partial class Airport : BaseViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Airport()
        {
            this.Flights = new HashSet<Flight>();
            this.Flights1 = new HashSet<Flight>();
        }

        private string _Id_Airport;
        public string Id_Airport { get => _Id_Airport; set { _Id_Airport = value; OnPropertyChanged(); } }

        private string _Name_Airport;
        public string Name_Airport { get => _Name_Airport; set { _Name_Airport = value; OnPropertyChanged(); } }

        private string _Id_Locate;
        public string Id_Locate { get => _Id_Locate; set { _Id_Locate = value; OnPropertyChanged(); } }

        public virtual Locate Locate { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Flight> Flights { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Flight> Flights1 { get; set; }
    }
}
