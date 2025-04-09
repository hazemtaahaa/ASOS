namespace ASOS.DAL.Models
{
	public class CartItem
    {   
        public Guid ProductId { get; set; }

        public Product? Product { get; set; }

        public int Quantity { get; set; } = 1;

        public Guid CartId { get; set; }

        public Cart? Cart { get; set; }
    }
}
