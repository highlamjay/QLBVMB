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
    
    public partial class Ticket
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ticket()
        {
            this.Bookeds = new HashSet<Booked>();
        }
    
        public string Id_Ticket { get; set; }
        public string Type_Ticket { get; set; }
        public string Id_Seat { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string Status { get; set; }
        public string Id_Flight { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booked> Bookeds { get; set; }
        public virtual Flight Flight { get; set; }
    }
}
