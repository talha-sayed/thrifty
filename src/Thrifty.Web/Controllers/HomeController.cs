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
            var transaction = new Transaction("Sample transaction");

            transaction.Legs.Add(TransactionLeg.CreateCredit(10.5M));
            transaction.Legs.Add(TransactionLeg.CreateDebit(4.5M));
            transaction.Legs.Add(TransactionLeg.CreateDebit(6.0M));

            await _transactionService.CreateTransaction(transaction);

            return View();
        }
    }
}
