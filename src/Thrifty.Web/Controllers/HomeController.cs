using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Thrifty.Abstractions;
using Thrifty.Models;

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
            await _transactionService.CreateSampleTransaction(new Transaction()
            {
                Description = "Sample transaction"
            });

            return View();
        }
    }
}
