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
    
    public partial class Checked_Baggage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Checked_Baggage()
        {
            this.Bookeds = new HashSet<Booked>();
        }
    
        public string Id_CB { get; set; }
        public string Type_CB { get; set; }
        public Nullable<decimal> Extra_Price { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booked> Bookeds { get; set; }
    }
}
