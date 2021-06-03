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
    public class OrderRepository : GenericRepository<Order>, IOrderService
    {
        public OrderRepository(LibraryManagementPortalContext context) : base(context)
        {

        }
        public IEnumerable<Order> GetAllOrderByUser(string id, params Expression<Func<Order, object>>[] include)
        {
            return Entities.Include(b => b.User).Include(b => b.OrderDetail).Where(b => b.UserId == id).AsEnumerable();
        }
    }
}
