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
    
    public partial class Person
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Person()
        {
            this.Biddings = new HashSet<Bidding>();
            this.CustomerBiddings = new HashSet<CustomerBidding>();
            this.ProviderBiddings = new HashSet<ProviderBidding>();
        }
    
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string SurnamName { get; set; }
        public string Patron { get; set; }
        public int PersonTypeId { get; set; }
        public Nullable<int> CompanyId { get; set; }
        public Nullable<int> CountryId { get; set; }
        public string UserId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bidding> Biddings { get; set; }
        public virtual Company Company { get; set; }
        public virtual Country Country { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerBidding> CustomerBiddings { get; set; }
        public virtual PersonType PersonType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProviderBidding> ProviderBiddings { get; set; }
    }
}
