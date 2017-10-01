using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Thrifty.Abstractions.Services;

namespace Thrifty.Web.Controllers
{
    public class AccountsController : Controller
    {
        private IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string accountName, string accountKey)
        {
            await _accountService.Create(accountName, accountKey);

            return View("Index");
        }
    }
}