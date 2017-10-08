using Microsoft.AspNetCore.Mvc;

namespace Thrifty.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/[controller]")]
    public class DatabaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}