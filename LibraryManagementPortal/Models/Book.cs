using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementPortal.Models
{
    public class Book : BaseEntity
    {
        public int CountBook { get; set; }
        public string AuthorId { get; set; }
        public virtual Author Auth { get; set; }
        public string CategoryId { get; set; }
        public virtual Category Cate { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
