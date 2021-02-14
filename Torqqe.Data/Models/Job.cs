using System.Collections.Generic;

namespace Torqqe.Data.Models
{
    public class Job
    {
        public Job()
        {
            Labors = new HashSet<Labor>();
            Parts = new HashSet<Part>();
            Subcontracts = new HashSet<Subcontract>();
        }

        public string ShopmonkeyId { get; set; }
        public string Name { get; set; }
        public int? Rate { get; set; }
        public int? Epa { get; set; }
        public string EpaValueType { get; set; }
        public decimal? Discount { get; set; }
        public decimal? Taxes { get; set; }
        public string TaxesValueType { get; set; }
        public double? ShopSupplies { get; set; }
        public string ShopSuppliesValueType { get; set; }
        public bool? IncludeInInvoice { get; set; }
        public bool? IsLaborTaxable { get; set; }
        public bool? IsPartShopSupplies { get; set; }
        public bool? IsLaborShopSupplies { get; set; }
        public bool? UseGstPstHst { get; set; }
        public string OrderShopmonkeyId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Total Total { get; set; }
        public virtual ICollection<Labor> Labors { get; set; }
        public virtual ICollection<Part> Parts { get; set; }
        public virtual ICollection<Subcontract> Subcontracts { get; set; }
    }
}
