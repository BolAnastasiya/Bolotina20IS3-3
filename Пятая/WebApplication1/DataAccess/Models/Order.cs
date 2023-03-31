using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public int? StatusId { get; set; }
        public int? UserId { get; set; }
        public DateTime? DateOrder { get; set; }
        public int? DeliveryTypeId { get; set; }
        public bool? Deleted { get; set; }

        public virtual DeliveryType? DeliveryType { get; set; }
        public virtual Status? Status { get; set; }
        public virtual User? User { get; set; }
    }
}
