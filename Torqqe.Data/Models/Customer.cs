using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Torqqe.Data.Models
{
    public partial class Customer : IEquatable<Customer>
    {
        public Customer()
        {
            Emails = new HashSet<Email>();
            Orders = new HashSet<Order>();
            Phones = new HashSet<Phone>();
            VehicleOwners = new HashSet<VehicleOwner>();
        }

        public string ShopmonkeyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public DateTime? CreationDate { get; set; }

        public virtual ICollection<Email> Emails { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Phone> Phones { get; set; }
        public virtual ICollection<VehicleOwner> VehicleOwners { get; set; }

        public bool Equals(Customer other)
        {
            return ShopmonkeyId.Equals(other.ShopmonkeyId);
        }
    }
}
