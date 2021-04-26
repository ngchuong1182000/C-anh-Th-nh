using System.Collections.Generic;

namespace LibraryManagementPortal.Models
{
    public class Author : BaseEntity
    {
        public string Description { get; set; }
        public virtual List<Book> Books { get; set; }
    }
}
