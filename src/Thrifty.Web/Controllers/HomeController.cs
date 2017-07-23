using Microsoft.AspNetCore.Mvc;

namespace Thrifty.Web.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Hello World!";
        }
    }
}
