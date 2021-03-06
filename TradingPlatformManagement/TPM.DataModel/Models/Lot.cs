//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TPM.DataModel.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Lot
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lot()
        {
            this.Biddings = new HashSet<Bidding>();
        }
    
        public int LotId { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public Nullable<System.DateTime> DateOfEndRegistration { get; set; }
        public Nullable<System.DateTime> DateOfStartRegistration { get; set; }
        public Nullable<System.DateTime> DateOfPub { get; set; }
        public Nullable<System.DateTime> DateOfSummarizing { get; set; }
        public Nullable<System.DateTime> DateOfBidding { get; set; }
        public string DeliveryAddress { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bidding> Biddings { get; set; }
    }
}
