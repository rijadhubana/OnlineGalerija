using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using OnlineGalerija.ViewModels;
using OnlineGalerija.PostgresModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGalerija.Helper
{
    public class AuthorizationAttribute : TypeFilterAttribute
    {
        public AuthorizationAttribute(bool mongoUser, bool postgreUser)
            : base(typeof(MyAuthorizeImpl))
        {
            Arguments = new object[] { mongoUser, postgreUser };
        }
    }


    public class MyAuthorizeImpl : IAsyncActionFilter
    {
        public MyAuthorizeImpl(bool mongoUser, bool postgreUser)
        {
            _mongoUser = mongoUser; _postgreUser = postgreUser;
        }
        private readonly bool _mongoUser;
        private readonly bool _postgreUser;



        public async Task OnActionExecutionAsync(ActionExecutingContext filterContext, ActionExecutionDelegate next)
        {
            LoggedUser l = filterContext.HttpContext.GetLogiraniKorisnik();
            if (l == null)
            {
                filterContext.Result = new RedirectToActionResult("Nonauthorized", "Home", new { area = "" });
                return;
            }
            bool isMongoUser;
            if (l.IsMongoUser==true)
                isMongoUser = true;
            else isMongoUser = false;
            if (_postgreUser && isMongoUser == false)
            {
                await next();
                return;
            }
            if (_mongoUser && isMongoUser == true)
            {
                await next();
                return;
            }
            filterContext.Result = new RedirectToActionResult("Nonauthorized", "Home", new { area = "" });
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // throw new NotImplementedException();
        }
    }
}
