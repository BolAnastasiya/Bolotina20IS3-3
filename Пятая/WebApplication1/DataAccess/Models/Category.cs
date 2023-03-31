using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
            Specifications = new HashSet<Specification>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public bool? Deleted { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Specification> Specifications { get; set; }
    }
}
