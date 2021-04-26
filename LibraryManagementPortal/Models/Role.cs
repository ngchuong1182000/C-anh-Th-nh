using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementPortal.Models
{
    public class Role : BaseEntity
    {
        public virtual List<User> Users { get; set; }

    }
}
