using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Cart
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? Count { get; set; }
        public int? UserId { get; set; }
        public DateTime? DateCart { get; set; }
        public bool? Deleted { get; set; }

        public virtual Product? Product { get; set; }
        public virtual User? User { get; set; }
    }
}
