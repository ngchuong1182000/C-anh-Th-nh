using LibraryManagementPortal.Data;
using LibraryManagementPortal.IRepositories;
using LibraryManagementPortal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementPortal.Repositories
{
    public class CateRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CateRepository(LibraryManagementPortalContext context) : base (context)
        {
        }
    }
}
