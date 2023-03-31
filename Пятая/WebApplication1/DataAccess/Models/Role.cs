using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string? Role1 { get; set; }
        public bool? Deleted { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
