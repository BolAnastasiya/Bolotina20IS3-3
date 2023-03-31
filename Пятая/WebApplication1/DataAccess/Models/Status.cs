using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Status
    {
        public Status()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public bool? Status1 { get; set; }
        public bool? Deleted { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
