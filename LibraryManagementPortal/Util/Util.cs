using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementPortal.Utility
{
    public class Util
    {
        public static string generateID()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
