using System.Web.Mvc;
using System.Linq;

namespace Shop.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public string test()
        {

            return "Allah";
        }

        public string ReverseTheString(string input, string input2, int age)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return "string is empty";
            }
            //char[] arr = input.ToCharArray()
            //System.Array.Reverse(arr);

            return new string((input+input2+age).ToCharArray().Reverse().ToArray());
        }
    }
}