using System.ComponentModel.DataAnnotations;

namespace ASOS.BL.DTOs
{
    public class UserDTO
    {
        public string Id { get; set; }
        
        public string Email { get; set; }
        
        public string Address { get; set; }
        
        public string City { get; set; }
        
        public string Country { get; set; }
    }

    public class UserCreateDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
        
        [Required]
        public string Address { get; set; }
        
        [Required]
        public string City { get; set; }
        
        [Required]
        public string Country { get; set; }
    }

    public class UserUpdateDTO
    {
        public string Address { get; set; }
        
        public string City { get; set; }
        
        public string Country { get; set; }
    }
} 