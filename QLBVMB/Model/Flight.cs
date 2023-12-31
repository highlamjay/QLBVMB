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
    using System;
    using System.Collections.Generic;
    
    public partial class Flight
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Flight()
        {
            this.Bookeds = new HashSet<Booked>();
            this.Tickets = new HashSet<Ticket>();
        }
    
        public string Id_Flight { get; set; }
        public Nullable<System.DateTime> Time_Start { get; set; }
        public Nullable<System.DateTime> Time_End { get; set; }
        public string Id_Plane { get; set; }
        public string Airport_Take_Off { get; set; }
        public string Airport_Landing { get; set; }
        public Nullable<byte> Total_Seat { get; set; }
    
        public virtual Airport Airport { get; set; }
        public virtual Airport Airport1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booked> Bookeds { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual Plane Plane { get; set; }
    }
}
