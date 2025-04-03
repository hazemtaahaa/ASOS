using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASOS.DAL.Models
{
    public class CartItems
    {
        public Guid Id { get; set; }
        
        public Guid ProductId { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }

        public Guid CartId { get; set; }

        public Cart Cart { get; set; }
    }
}
