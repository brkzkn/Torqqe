﻿namespace Torqqe.Data.Models
{
    public class Part
    {
        public string ShopmonkeyId { get; set; }
        public string JobShopmonkeyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Number { get; set; }
        public decimal? WholesaleCost { get; set; }
        public decimal? RetailCost { get; set; }
        public double? Quantity { get; set; }
        public string DiscountValueType { get; set; }
        public decimal? Discount { get; set; }
        public bool? IsTaxable { get; set; }
        public long? Position { get; set; }

        public virtual Job Job { get; set; }
    }
}
