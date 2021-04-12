using System;
using System.Collections.Generic;
using System.Linq;
using ManagerStudent.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace ManagerStudent.Fillter
{
    public class AuthorizeActionFilter : IAuthorizationFilter
    {
        public static List<Student> list = new List<Student>(){
            new Student("1", "chunguyenchuong2014bg@gmail.com", "123", true),
            new Student("2", "chuongcnbhaf180208@gmail.com", "123", false)
        };
        readonly Boolean isAdmin;
        public AuthorizeActionFilter(Boolean isAdmin)
        {
            this.isAdmin = isAdmin;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var ss1 = context.HttpContext.Session.GetString("ss1");
            if (String.IsNullOrEmpty(ss1))
            {
                ss1 = "-1";
            }
            Student getStudent = list.SingleOrDefault(p => p.UserName == ss1);
            if (getStudent == null)
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary { { "controller", "Home" }, { "action", "Login" } }
                    );
            }
            else if (isAdmin != getStudent.isAdmin)
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary { { "controller", "Home" }, { "action", "Index" } }
                    );
            }
        }
    }
}