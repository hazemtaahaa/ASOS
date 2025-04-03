namespace ASOS.DAL.Models
{
    public class Cart
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public ICollection<CartItems> CartItems { get; set; } = new HashSet<CartItems>();
    }
}
