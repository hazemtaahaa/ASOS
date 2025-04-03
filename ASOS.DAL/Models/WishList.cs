namespace ASOS.DAL.Models
{
    public class WishList
    {
        public Guid Id { get; set; }

        public ICollection<Product> Products { get; set; } = new HashSet<Product>();

        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}
