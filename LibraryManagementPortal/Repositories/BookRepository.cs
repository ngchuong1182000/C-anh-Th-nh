using LibraryManagementPortal.Data;
using LibraryManagementPortal.IRepositories;
using LibraryManagementPortal.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementPortal.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookService
    {
        public BookRepository(LibraryManagementPortalContext context) : base (context)
        {

        }
        public IEnumerable<Book> GetAlInclude()
        {
            return Entities.Include(b => b.Auth).Include(b => b.Cate).AsEnumerable();
        }

        public IEnumerable<Book> GetAllByAuthorId(string authorId)
        {
            return Entities.Include(b => b.Auth).Include(b => b.Cate).Where(b => b.AuthorId == authorId).AsEnumerable();
        }
    }
}
