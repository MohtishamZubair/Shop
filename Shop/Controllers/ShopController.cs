using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class ShopController : Controller
    {
        private string _userId;

        public string UserId
        {
            get
            {
                if (User.Identity.IsAuthenticated)
                {
                    _userId = User.Identity.GetUserId();
                }
                else
                {
                    throw new System.Security.SecurityException("User is not authorized");
                }
                return _userId;
            }
            set { _userId = value; }
        }
    }
}