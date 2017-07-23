using Microsoft.AspNetCore.Mvc;

namespace Thrifty.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
