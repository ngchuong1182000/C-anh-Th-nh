using R5.Data;
using R5.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace R5.Repositories
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        IEnumerable<Book> GetAllInclude();
        IEnumerable<Book> GetAllByAuthorId(int authorId);
    }

    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(F5DbContext context) : base(context)
        {
        }

        public IEnumerable<Book> GetAllInclude()
        {
            return Entities
                .Include(b => b.Author)
                .Include(b => b.Category)
                .AsEnumerable();
        }

        public IEnumerable<Book> GetAllByAuthorId(int authorId)
        {
            return Entities.Where(b => b.AuthorId == authorId).AsEnumerable();
        }
    }
}
