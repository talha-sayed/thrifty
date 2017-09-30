using System;
using System.Collections.Generic;
using System.Linq;
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
        public IActionResult Create(string accountName, string accountKey)
        {
            _accountService.Create(accountName, accountKey);

            return View("Index");
        }
    }
}