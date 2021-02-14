namespace Torqqe.Data.Models
{
    public class Email
    {
        public int Id { get; set; }
        public string CustomerShopmonkeyId { get; set; }
        public string EmailAddress { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
