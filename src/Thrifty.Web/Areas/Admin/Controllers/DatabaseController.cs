using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using DbUp;
using DbUp.Engine;
using DbUp.Engine.Output;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Thrifty.Data;
using Thrifty.Web.Areas.Admin.Models.Database;

namespace Thrifty.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/[controller]")]
    public class DatabaseController : Controller
    {
        private ThriftyDbContext _context;

        private UpgradeEngine _upgrader;

        public DatabaseController(ThriftyDbContext context)
        {
            _context = context;

            var connectionString = _context.Database.GetDbConnection().ConnectionString;

            _upgrader = DeployChanges.To
                .SqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(typeof(Thrifty.Database.Program).Assembly)
                .LogToConsole()
                .Build();
        }

        public ActionResult Index()
        {
            var vm = new DatabaseIndexVM();

            vm.ScriptsExecuted = _upgrader.GetExecutedScripts();
            vm.ScriptsToExecute = _upgrader.GetScriptsToExecute().Select(x=>x.Name).ToList();

            return View(vm);
        }

        [HttpPost]
        public ActionResult Migrate()
        {
            _upgrader.PerformUpgrade();

            var vm = new DatabaseIndexVM();

            vm.ScriptsExecuted = _upgrader.GetExecutedScripts();
            vm.ScriptsToExecute = _upgrader.GetScriptsToExecute().Select(x => x.Name).ToList();

            return View("Index", vm);
        }
    }
}