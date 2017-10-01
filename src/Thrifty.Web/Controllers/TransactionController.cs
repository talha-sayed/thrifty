using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Thrifty.Abstractions;
using Thrifty.Abstractions.Services;
using Thrifty.Web.Models.Transaction;

namespace Thrifty.Web.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ITransactionService _transactionService;
        private readonly IAccountService _accountService;


        public TransactionController(ITransactionService transactionService, IAccountService accountService)
        {
            _transactionService = transactionService;
            _accountService = accountService;
        }

        public async Task<IActionResult> Add()
        {
            var vm = new AddTransactionVM();

            vm.Accounts = await _accountService.GetAllAccounts();

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddTransactionVM vm)
        {
            //await _transactionService.CreateTransaction(new Transaction());

            return View();
        }
    }
}