using LibraryManagementPortal.Data;
using LibraryManagementPortal.IRepositories;
using LibraryManagementPortal.Models;

namespace LibraryManagementPortal.Repositories
{
  public class AuthorRepository : GenericRepository<Author>, IAuthorService
    {
        public AuthorRepository(LibraryManagementPortalContext context) : base (context)
        {
        }
    }
}
