namespace ASOS.DAL.Models
{
    public class ProductImages
    {
        public Guid Id { get; set; }

        public string? ImageUrl { get; set; }

        public Guid ProductID { get; set; }

        public Product Product { get; set; }
    }
}
