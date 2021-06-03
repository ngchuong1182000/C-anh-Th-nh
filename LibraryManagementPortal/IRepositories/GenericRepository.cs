using LibraryManagementPortal.Data;
using LibraryManagementPortal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LibraryManagementPortal.IRepositories
{
    public class GenericRepository<T> : IGenericService<T> where T : BaseEntity
    {
        protected readonly LibraryManagementPortalContext Context;
        protected readonly DbSet<T> Entities;
        public GenericRepository(LibraryManagementPortalContext context)
        {
            this.Context = context;
            Entities = context.Set<T>();
        }
        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] include)
        {
            var query = Entities.AsQueryable();
            return include.Aggregate(query, (current, include) => current.Include(include));
        }
        public IEnumerable<T> GetOne(string id, params Expression<Func<T, object>>[] include)
        {
            var query = Entities.AsQueryable();
            return include.Aggregate(query, (current, include) => current.Include(include)).Where(s => s.Id == id);
        }
        public void Insert(T e)
        {
            if (e == null)
            {
                throw new ArgumentNullException("entity");
            }
            Entities.Add(e);
            Context.SaveChanges();
        }
        public void Update(T e)
        {
            if (e == null)
            {
                throw new ArgumentNullException("entity");
            }
            Context.Entry(e).State = EntityState.Modified;
            Context.SaveChanges();
        }
        public void Remove(IEnumerable<T> e)
        {
            if (e == null)
            {
                throw new ArgumentNullException("entity");
            }
            Entities.Remove(e.ToArray()[0]);
            Context.SaveChanges();
        }

    }
}
