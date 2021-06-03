using LibraryManagementPortal.Data;
using LibraryManagementPortal.IRepositories;
using LibraryManagementPortal.Models;

namespace LibraryManagementPortal.Repositories
{
    public class CateRepository : GenericRepository<Category>, ICategoryService
    {
        public CateRepository(LibraryManagementPortalContext context) : base (context)
        {
        }
    }
}
