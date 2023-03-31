using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.Interfaces;

namespace DataAccess.Interfaces
{
    public interface IUserRepository : IRepositoryBase<User>
    {
    }
}
