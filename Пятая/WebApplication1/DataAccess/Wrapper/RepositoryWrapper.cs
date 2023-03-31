using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using DataAccess.Models;
using DataAccess.Repositories;

namespace DataAccess.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ShopsContext _context;
        private IUserRepository _user;
        public IUserRepository User
        {
            get 
            {
                if(_user == null) 
                {
                    _user = new UserRepository(_context);
                }
                return _user; 
            }
        }
        public RepositoryWrapper(ShopsContext repositoryContext)
        {
            _context = repositoryContext;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
