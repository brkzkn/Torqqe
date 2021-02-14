using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Torqqe.ShopmonkeyApi.Model
{
    public class Tag
    {
        [JsonProperty(PropertyName = "Name")]
        [StringLength(50)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "Color")]
        [StringLength(50)]
        public string Color { get; set; }
    }

    public class Orders
    {
        [JsonProperty(PropertyName = "shopmonkeyId")]
        [StringLength(50)]
        public string ShopmonkeyId { get; set; }

        [JsonProperty(PropertyName = "number")]
        public int Number { get; set; }

        [JsonProperty(PropertyName = "publicId")]
        [StringLength(50)]
        public string PublicId { get; set; }

        [JsonProperty(PropertyName = "mileageIn")]
        public int? MileageIn { get; set; }

        [JsonProperty(PropertyName = "mileageOut")]
        public int? MileageOut { get; set; }

        [JsonProperty("tags")]
        public List<Tag> Tags { get; set; }

        [JsonProperty("isAuthorized")]
        public bool IsAuthorized { get; set; }

        [JsonProperty("isInvoice")]
        public bool IsInvoice { get; set; }

        [JsonProperty("isPaid")]
        public bool IsPaid { get; set; }

        [JsonProperty("totalAmount")]
        public decimal? TotalAmount { get; set; }

        [JsonProperty("paidAmount")]
        public decimal? PaidAmount { get; set; }

        [JsonProperty("isArchived")]
        public bool IsArchived { get; set; }

        [JsonProperty("complaint")]
        [StringLength(50)]
        public string Complaint { get; set; }

        [JsonProperty("techRecommendation")]
        [StringLength(50)]
        public string TechRecommendation { get; set; }

        [JsonProperty("isLaborTaxable")]
        public bool IsLaborTaxable { get; set; }

        [JsonProperty("isPartShopSupplies")]
        public bool IsPartShopSupplies { get; set; }

        [JsonProperty("isLaborShopSupplies")]
        public bool IsLaborShopSupplies { get; set; }

        [JsonProperty("authorizedDate")]
        public DateTime? AuthorizedDate { get; set; }

        [JsonProperty("creationDate")]
        public DateTime? CreationDate { get; set; }

        [JsonProperty("invoicedDate")]
        public DateTime? InvoicedDate { get; set; }

        [JsonProperty("name")]
        [StringLength(50)]
        public string Name { get; set; }

        [JsonProperty("workflow")]
        [StringLength(50)]
        public string Workflow { get; set; }

        [JsonProperty("customer")]
        public Customer Customer { get; set; }

        [JsonProperty("vehicle")]
        public Vehicle Vehicle { get; set; }
    }
}
