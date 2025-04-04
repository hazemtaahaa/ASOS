namespace ASOS.DAL.Models
{
    public class Cart
    {
        public Guid Id { get; set; }

        public string  UserId { get; set; }

        public User? User { get; set; }

        public ICollection<CartItem> CartItems { get; set; } = new HashSet<CartItem>();
    }
}
