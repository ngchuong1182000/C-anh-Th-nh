using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementPortal.Models
{
    public class OrderDetail 
    {
        public string OrderId { get; set; }
        public virtual Order Order { get; set; }
        public string BookId { get; set; }
        public virtual Book Book{ get; set; }
    }
}
