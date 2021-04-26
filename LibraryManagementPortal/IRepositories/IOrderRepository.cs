using LibraryManagementPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LibraryManagementPortal.IRepositories
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        IEnumerable<Order> GetAllOrderByUser(string id, params Expression<Func<Order, object>>[] include);
    }
}
