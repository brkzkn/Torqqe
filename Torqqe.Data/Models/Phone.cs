namespace Torqqe.Data.Models
{
    public class Phone
    {
        public int Id { get; set; }
        public string CustomerShopmonkeyId { get; set; }
        public string Phones { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
