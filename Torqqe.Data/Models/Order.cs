using System;
using System.Collections.Generic;

namespace Torqqe.Data.Models
{
    public class Order
    {
        public Order()
        {
            Jobs = new HashSet<Job>();
            Tags = new HashSet<Tag>();
        }

        public string ShopmonkeyId { get; set; }
        public int? Number { get; set; }
        public string PublicId { get; set; }
        public int? MileageIn { get; set; }
        public int? MileageOut { get; set; }
        public bool? IsAuthorized { get; set; }
        public bool? IsInvoice { get; set; }
        public bool? IsPaid { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? PaidAmount { get; set; }
        public bool? IsArchived { get; set; }
        public string Complaint { get; set; }
        public string TechRecommendation { get; set; }
        public bool? IsLaborTaxable { get; set; }
        public bool? IsPartShopSupplies { get; set; }
        public bool? IsLaborShopSupplies { get; set; }
        public DateTime? AuthorizedDate { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? InvoicedDate { get; set; }
        public string Name { get; set; }
        public string Workflow { get; set; }
        public string CustomerShopmonkeyId { get; set; }
        public string VehicleShopmonkeyId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
