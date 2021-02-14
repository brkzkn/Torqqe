namespace Torqqe.Data.Models
{
    public class VehicleOwner
    {
        public string VehicleShopmonkeyId { get; set; }
        public string CustomerShopmonkeyId { get; set; }

        public virtual Customer CustomerShopmonkey { get; set; }
        public virtual Vehicle VehicleShopmonkey { get; set; }
    }
}
