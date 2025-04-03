using Microsoft.AspNetCore.Identity;

namespace ASOS.DAL.Models
{
    public class User :IdentityUser
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }


        public ICollection<UserOrderPayment> UserOrderPayments { get; set; } = new HashSet<UserOrderPayment>();

        public Cart Cart { get; set; }

        public WishList WishList { get; set; }
        

    }
}
