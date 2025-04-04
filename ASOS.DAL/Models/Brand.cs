using System.ComponentModel.DataAnnotations;

namespace ASOS.DAL.Models
{
    public class Brand
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage  = "Name is Required")]
        public string Name { get; set; }
        //comment

        //Hazem Taha + Mahmoud Adel
        public string? BrandImage { get; set; }

        public ICollection<Product> Products { get; set; } = new HashSet<Product>();

    }
}
