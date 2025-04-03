namespace ASOS.DAL.Models
{
    public class Brand
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        //hamada
        public string BrandImage { get; set; }

        public ICollection<Product> Products { get; set; } = new HashSet<Product>();

    }
}
