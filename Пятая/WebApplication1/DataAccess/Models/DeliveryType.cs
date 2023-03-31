using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class DeliveryType
    {
        public DeliveryType()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string? DeliveryType1 { get; set; }
        public bool? Deleted { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
