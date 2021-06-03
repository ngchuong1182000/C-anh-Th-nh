using LibraryManagementPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementPortal.IRepositories
{
    public interface IBookService : IGenericService<Book>
    {
        IEnumerable<Book> GetAlInclude();
        IEnumerable<Book> GetAllByAuthorId(string authorId);
    }
}
