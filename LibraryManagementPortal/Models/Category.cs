using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementPortal.Models
{
    public class Category : BaseEntity
    {
        public string Description { get; set; }
        public virtual List<Book> Books { get; set; }
    }
}
