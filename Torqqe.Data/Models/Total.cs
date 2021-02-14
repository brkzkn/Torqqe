namespace Torqqe.Data.Models
{
    public class Total
    {
        public string JobShopmonkeyId { get; set; }
        public decimal? PartsSubtotal { get; set; }
        public decimal? PartsSubtotalWithoutDiscount { get; set; }
        public decimal? PartsWholesaleSubtotal { get; set; }
        public decimal? TiresSubtotal { get; set; }
        public decimal? TiresSubtotalWithoutDiscount { get; set; }
        public decimal? TiresTotalTaxable { get; set; }
        public decimal? TiresWholesaleSubtotal { get; set; }
        public decimal? LaborsSubtotal { get; set; }
        public decimal? LaborsTotalTaxable { get; set; }
        public decimal? LaborsSubtotalWithoutDiscount { get; set; }
        public decimal? SubcontractsSubtotal { get; set; }
        public decimal? SubcontractsSubtotalWithoutDiscount { get; set; }
        public decimal? SubcontractsTotalTaxable { get; set; }
        public decimal? SubcontractsWholesaleSubtotal { get; set; }
        public decimal? FeesSubtotal { get; set; }
        public decimal? FeesSubtotalWithoutDiscount { get; set; }
        public decimal? EpaTotal { get; set; }
        public decimal? ShopSuppliesTotal { get; set; }
        public decimal? TaxesTotal { get; set; }
        public decimal? GstTotal { get; set; }
        public decimal? PstTotal { get; set; }
        public decimal? HstTotal { get; set; }
        public decimal? DiscountTotal { get; set; }
        public decimal? DiscountTotalPercent { get; set; }
        public decimal? JobDiscountTotal { get; set; }
        public decimal? Subtotal { get; set; }
        public decimal? TotalPrice { get; set; }

        public virtual Job Job { get; set; }
    }
}
