using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Thrifty.Abstractions;

namespace Thrifty.Web.Controllers
{
    public class HomeController : Controller
    {
        private ITransactionService _transactionService;

        public HomeController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public async Task<ActionResult> Index()
        {
            await _transactionService.CreateSampleTransaction();

            return View();
        }
    }
}
