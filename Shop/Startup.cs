using IdentityManager.Configuration;
using IdentityManager.AspNetIdentity;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Shop.Models;
using IdentityManager;
using Shop.Data.Context;

//[assembly: OwinStartupAttribute(typeof(Shop.Startup))]
namespace Shop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.Map("/idm", idm =>
            {
                var factory = new IdentityManagerServiceFactory();
                factory.IdentityManagerService = new Registration<IIdentityManagerService, ApplicationIdentityManagerService>();
                factory.Register(new Registration<ApplicationUserManager>());
                factory.Register(new Registration<ApplicationUserStore>());
                factory.Register(new Registration<ApplicationRoleManager>());
                factory.Register(new Registration<ApplicationRoleStore>());
                factory.Register(new Registration<ApplicationDbContext>());


                idm.UseIdentityManager(new IdentityManagerOptions
                {
                    Factory = factory
                });

            });                        
            
        }
    }

    public class ApplicationRoleManager : RoleManager<IdentityRole>
    {
        public ApplicationRoleManager(ApplicationRoleStore roleStore):base(roleStore)
        {

        }

    }
    public class ApplicationUserStore:UserStore<ApplicationUser>
    {
        public ApplicationUserStore(ApplicationDbContext ctx):base(ctx)
        {

        }
    }

    public class ApplicationRoleStore:RoleStore<IdentityRole>
    {
        public ApplicationRoleStore(ApplicationDbContext ctx) :base(ctx)
        {

        }
    }

    public class ApplicationIdentityManagerService:AspNetIdentityManagerService<ApplicationUser,string,IdentityRole,string>
    {
        public ApplicationIdentityManagerService(ApplicationUserManager userMgr, ApplicationRoleManager roleMgr) :base(userMgr,roleMgr)
        {
                
        }
    }
}
