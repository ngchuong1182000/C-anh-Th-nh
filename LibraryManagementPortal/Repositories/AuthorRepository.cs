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
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(LibraryManagementPortalContext context) : base (context)
        {
        }
    }
}
