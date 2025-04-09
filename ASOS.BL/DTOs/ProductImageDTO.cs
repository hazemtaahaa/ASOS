using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ASOS.BL.DTOs
{
    public class ProductImageDTO
    {
        public Guid Id { get; set; }
        
        public Guid ProductId { get; set; }
        
        public string ImageUrl { get; set; }
        
    }

    public class ProductImageCreateDTO
    {
        [Required]
        public Guid ProductId { get; set; }
        
        [Required]
        public IFormFile ImageFile { get; set; }
        
    }

    public class ProductImageUpdateDTO
    {
        public IFormFile ImageFile { get; set; }
        
    }
} 