namespace Torqqe.Data.Models
{
    public class Labor
    {
        public string ShopmonkeyId { get; set; }
        public string JobShopmonkeyId { get; set; }
        public string Name { get; set; }
        public double? Hours { get; set; }
        public string DiscountValueType { get; set; }
        public decimal? Discount { get; set; }
        public bool? IsShowHours { get; set; }
        public long? Position { get; set; }

        public virtual Job Job { get; set; }
    }
}
