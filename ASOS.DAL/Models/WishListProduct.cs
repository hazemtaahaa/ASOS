namespace ASOS.DAL.Models
{
    public class WishListProduct
    {
        public Guid ProductId { get; set; }

        public Product? Product { get; set; }

        public Guid WishListId { get; set; }

        public WishList? WishList { get; set; }

    }
}
