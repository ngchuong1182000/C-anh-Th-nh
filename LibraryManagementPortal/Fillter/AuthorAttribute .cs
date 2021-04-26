using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ManagerStudent.Fillter
{
    public class AuthorAttribute : TypeFilterAttribute
    {
        public AuthorAttribute(string role) : base(typeof(AuthorizeActionFilter))
        {
            Arguments = new object[] { role };
        }
    }
}