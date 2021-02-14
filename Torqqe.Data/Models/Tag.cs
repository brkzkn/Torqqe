namespace Torqqe.Data.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string OrderShopmonkeyId { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }

        public virtual Order Order { get; set; }
    }
}
