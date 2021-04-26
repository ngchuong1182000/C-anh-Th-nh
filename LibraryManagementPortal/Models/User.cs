using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace LibraryManagementPortal.Models
{
    public class User : BaseEntity
    {
        public string email { get; set; }
        public string Password { get; set; }
        public string RoleId { get; set; }
        public string SecurityStamp { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }
}
