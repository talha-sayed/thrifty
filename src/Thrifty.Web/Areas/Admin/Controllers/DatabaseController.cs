using Microsoft.AspNetCore.Mvc;
using Thrifty.Application.Database;
using Thrifty.Data;
using Thrifty.Web.Areas.Admin.Models.Database;

namespace Thrifty.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/[controller]")]
    public class DatabaseController : Controller
    {
        private DatabaseMigrator _migrator;

        public DatabaseController(ThriftyDbContext context)
        {
            _migrator = new DatabaseMigrator(context);
        }

        public ActionResult Index()
        {
            var vm = new DatabaseIndexVM();

            vm.ScriptsExecuted = _migrator.ExecutedScripts;
            vm.ScriptsToExecute = _migrator.ScriptsToExecute;

            return View(vm);
        }

        [HttpPost]
        public ActionResult Migrate()
        {
            _migrator.Migrate();

            var vm = new DatabaseIndexVM();

            vm.ScriptsExecuted = _migrator.ExecutedScripts;
            vm.ScriptsToExecute = _migrator.ScriptsToExecute;

            return View("Index", vm);
        }
    }
}