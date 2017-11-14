using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Thrifty.Abstractions.Services;
using Thrifty.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Thrifty.Web.Controllers
{
    [Route("api/[controller]")]
    public class LedgerController : Controller
    {
        private IAccountService _accountService;

        public LedgerController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        // GET: api/values
        [HttpGet]
        public async Task<List<Account>> Get()
        {
            return await _accountService.GetAllAccounts();
        }

        public class Ledger
        {
            public string name;
            public string key;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/ledger
        [HttpPost]
        public async Task Post([FromBody] LedgerCreateInput input)
        {
            await _accountService.Create(input.name, input.key);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{key}")]
        public async Task Delete(string key)
        {
            await _accountService.Delete(key);
        }
    }

    public class LedgerCreateInput
    {
        public string name;
        public string key;
    }
}
