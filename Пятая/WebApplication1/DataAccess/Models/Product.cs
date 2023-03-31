using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Product
    {
        public Product()
        {
            Carts = new HashSet<Cart>();
        }

        public int Id { get; set; }
        public int? Count { get; set; }
        public int? CategoryId { get; set; }
        public decimal? Price { get; set; }
        public bool? Deleted { get; set; }

        public virtual Category? Category { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
    }
}
