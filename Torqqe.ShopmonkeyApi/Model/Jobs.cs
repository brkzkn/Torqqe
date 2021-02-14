using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Torqqe.ShopmonkeyApi.Model
{
    public class Labor
    {
        [JsonProperty("shopmonkeyId")]
        [StringLength(50)]
        public string ShopmonkeyId { get; set; }

        [JsonProperty("name")]
        [StringLength(50)]
        public string Name { get; set; }

        [JsonProperty("hours")]
        public float? Hours { get; set; }

        [JsonProperty("discountValueType")]
        [StringLength(50)]
        public string DiscountValueType { get; set; }

        [JsonProperty("discount")]
        public decimal? Discount { get; set; }

        [JsonProperty("isShowHours")]
        public bool IsShowHours { get; set; }

        [JsonProperty("position")]
        public long? Position { get; set; }
    }

    public class Part
    {
        [JsonProperty("shopmonkeyId")]
        [StringLength(50)]
        public string ShopmonkeyId { get; set; }

        [JsonProperty("name")]
        [StringLength(50)]
        public string Name { get; set; }

        [JsonProperty("description")]
        [StringLength(50)]
        public string Description { get; set; }

        [JsonProperty("number")]
        [StringLength(50)]
        public string Number { get; set; }

        [JsonProperty("wholesaleCost")]
        public decimal? WholesaleCost { get; set; }

        [JsonProperty("retailCost")]
        public decimal? RetailCost { get; set; }

        [JsonProperty("quantity")]
        public float? Quantity { get; set; }

        [JsonProperty("discountValueType")]
        [StringLength(50)]
        public string DiscountValueType { get; set; }

        [JsonProperty("discount")]
        public decimal? Discount { get; set; }

        [JsonProperty("isTaxable")]
        public bool IsTaxable { get; set; }

        [JsonProperty("position")]
        public long? Position { get; set; }
    }

    public class Subcontract
    {
        [JsonProperty("shopmonkeyId")]
        [StringLength(50)]
        public string ShopmonkeyId { get; set; }

        [JsonProperty("name")]
        [StringLength(50)]
        public string Name { get; set; }

        [JsonProperty("description")]
        [StringLength(50)]
        public string Description { get; set; }

        [JsonProperty("wholesaleCost")]
        public decimal? WholesaleCost { get; set; }

        [JsonProperty("retailCost")]
        public decimal? RetailCost { get; set; }

        [JsonProperty("discountValueType")]
        [StringLength(50)]
        public string DiscountValueType { get; set; }

        [JsonProperty("discount")]
        public decimal? Discount { get; set; }

        [JsonProperty("isTaxable")]
        public bool IsTaxable { get; set; }

        [JsonProperty("position")]
        public long? Position { get; set; }
    }

    public class Totals
    {
        [JsonProperty("partsSubtotal")]
        public decimal? PartsSubtotal { get; set; }

        [JsonProperty("partsSubtotalWithoutDiscount")]
        public decimal? PartsSubtotalWithoutDiscount { get; set; }

        [JsonProperty("partsTotalTaxable")]
        public decimal? PartsTotalTaxable { get; set; }

        [JsonProperty("partsWholesaleSubtotal")]
        public decimal? PartsWholesaleSubtotal { get; set; }

        [JsonProperty("tiresSubtotal")]
        public decimal? TiresSubtotal { get; set; }

        [JsonProperty("tiresSubtotalWithoutDiscount")]
        public decimal? TiresSubtotalWithoutDiscount { get; set; }

        [JsonProperty("tiresTotalTaxable")]
        public decimal? TiresTotalTaxable { get; set; }

        [JsonProperty("tiresWholesaleSubtotal")]
        public decimal? TiresWholesaleSubtotal { get; set; }

        [JsonProperty("laborsSubtotal")]
        public decimal? LaborsSubtotal { get; set; }

        [JsonProperty("laborsTotalTaxable")]
        public decimal? LaborsTotalTaxable { get; set; }

        [JsonProperty("laborsSubtotalWithoutDiscount")]
        public decimal? LaborsSubtotalWithoutDiscount { get; set; }

        [JsonProperty("subcontractsSubtotal")]
        public decimal? SubcontractsSubtotal { get; set; }

        [JsonProperty("subcontractsSubtotalWithoutDiscount")]
        public decimal? SubcontractsSubtotalWithoutDiscount { get; set; }

        [JsonProperty("subcontractsTotalTaxable")]
        public decimal? SubcontractsTotalTaxable { get; set; }

        [JsonProperty("subcontractsWholesaleSubtotal")]
        public decimal? SubcontractsWholesaleSubtotal { get; set; }

        [JsonProperty("feesSubtotal")]
        public decimal? FeesSubtotal { get; set; }

        [JsonProperty("feesSubtotalWithoutDiscount")]
        public decimal? FeesSubtotalWithoutDiscount { get; set; }

        [JsonProperty("epaTotal")]
        public decimal? EpaTotal { get; set; }

        [JsonProperty("shopSuppliesTotal")]
        public decimal? ShopSuppliesTotal { get; set; }

        [JsonProperty("taxesTotal")]
        public decimal? TaxesTotal { get; set; }

        [JsonProperty("gstTotal")]
        public decimal? GstTotal { get; set; }

        [JsonProperty("pstTotal")]
        public decimal? PstTotal { get; set; }

        [JsonProperty("hstTotal")]
        public decimal? HstTotal { get; set; }

        [JsonProperty("discountTotal")]
        public decimal? DiscountTotal { get; set; }

        [JsonProperty("discountTotalPercent")]
        public decimal? DiscountTotalPercent { get; set; }

        [JsonProperty("jobDiscountTotal")]
        public decimal? JobDiscountTotal { get; set; }

        [JsonProperty("subtotal")]
        public decimal? Subtotal { get; set; }

        [JsonProperty("total")]
        public decimal? Total { get; set; }
    }

    public class Jobs
    {
        [JsonProperty("shopmonkeyId")]
        [StringLength(50)]
        public string ShopmonkeyId { get; set; }

        [JsonProperty("name")]
        [StringLength(50)]
        public string Name { get; set; }

        [JsonProperty("rate")]
        public int? Rate { get; set; }

        [JsonProperty("epa")]
        public int? Epa { get; set; }

        [JsonProperty("epaValueType")]
        [StringLength(50)]
        public string EpaValueType { get; set; }

        [JsonProperty("discount")]
        public decimal? Discount { get; set; }

        [JsonProperty("discountValueType")]
        [StringLength(50)]
        public string DiscountValueType { get; set; }

        [JsonProperty("taxes")]
        public decimal? Taxes { get; set; }

        [JsonProperty("taxesValueType")]
        [StringLength(50)]
        public string TaxesValueType { get; set; }

        [JsonProperty("shopSupplies")]
        public double? ShopSupplies { get; set; }

        [JsonProperty("shopSuppliesValueType")]
        [StringLength(50)]
        public string ShopSuppliesValueType { get; set; }

        [JsonProperty("includeInInvoice")]
        public bool IncludeInInvoice { get; set; }

        [JsonProperty("isLaborTaxable")]
        public bool IsLaborTaxable { get; set; }

        [JsonProperty("isPartShopSupplies")]
        public bool IsPartShopSupplies { get; set; }

        [JsonProperty("isLaborShopSupplies")]
        public bool IsLaborShopSupplies { get; set; }

        [JsonProperty("useGstPstHst")]
        public bool UseGstPstHst { get; set; }

        //[JsonProperty("technician")]
        //public Technician Technician { get; set; }

        [JsonProperty("labors")]
        public List<Labor> Labors { get; set; }

        [JsonProperty("parts")]
        public List<Part> Parts { get; set; }

        [JsonProperty("subcontracts")]
        public List<Subcontract> Subcontracts { get; set; }

        [JsonProperty("totals")]
        public Totals Totals { get; set; }
    }
}
