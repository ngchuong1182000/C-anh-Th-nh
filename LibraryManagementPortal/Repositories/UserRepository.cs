using LibraryManagementPortal.Data;
using LibraryManagementPortal.IRepositories;
using LibraryManagementPortal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LibraryManagementPortal.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(LibraryManagementPortalContext context) : base (context)
        {
        }
        public IEnumerable<User> GetOneOther(string id, params Expression<Func<User, object>>[] include)
        {
            var query = Entities.AsQueryable();
            return include.Aggregate(query, (current, include) => current.Include(include)).Where(s => s.Id == id);
        }

        public User GetUserByEmail(string email)
        {
            return Entities.SingleOrDefault(s => s.email == email);
        }
    }
}
