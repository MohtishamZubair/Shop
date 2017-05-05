using Microsoft.AspNet.Identity.EntityFramework;
using Shop.Data.Context;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Shop
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            SeedApplicationWithAdmin();
            AutoMapperHelper.LoadMapping();
        }

        
        private async void SeedApplicationWithAdmin()
        {
            var context = ApplicationDbContext.Create();          

            if (!context.Users.Any(u => u.UserName == "shopadmin@shop.com"))
            {
                
                var manager = new ApplicationUserManager(new ApplicationUserStore(context));
                var adminUser = new ApplicationUser { UserName = "shopadmin@shop.com", Email = "shopadmin@shop.com" };
                await manager.CreateAsync(adminUser, "password123");

                var roleManager = new ApplicationRoleManager(new ApplicationRoleStore(context));
                foreach (string ro in Enum.GetNames(typeof(UserTypeEnum)))
                {
                    if (!context.Roles.Any(r => r.Name == ro))
                    {
                        await roleManager.CreateAsync(new IdentityRole { Name = ro });
                    }
                }
                await manager.AddToRoleAsync(adminUser.Id, "admin");
            }

        }
    }
}
