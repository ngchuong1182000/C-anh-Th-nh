using LibraryManagementPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LibraryManagementPortal.IRepositories
{
    public interface IGenericService<T> where T : class
    {
        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] include);
        IEnumerable<T> GetOne(string id, params Expression<Func<T, object>>[] include);
        void Insert(T e);
        void Update(T e);
        void Remove(IEnumerable<T> e);
    }
}
