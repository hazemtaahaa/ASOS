namespace ASOS.DAL.Models
{
    public class WishList
    {
        public Guid Id { get; set; }

        public ICollection<WishListProduct> WishListProducts { get; set; } = new HashSet<WishListProduct>();

        public string UserId { get; set; }

        public User? User { get; set; }
    }
}
