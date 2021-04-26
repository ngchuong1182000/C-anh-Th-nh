using LibraryManagementPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LibraryManagementPortal.IRepositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User GetUserByEmail(string email);
        IEnumerable<User> GetOneOther(string id, params Expression<Func<User, object>>[] include);
    }
}
