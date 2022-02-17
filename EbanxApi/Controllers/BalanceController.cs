using EbanxApi.Database;
using EbanxApi.Services.AccountManager;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EbanxApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BalanceController : ControllerBase
    {
        private readonly IAccountManager _accountManager;
        private readonly Context _context;

        public BalanceController(IAccountManager accountManager, Context context)
        {
            _accountManager = accountManager;
            _context = context;
        }

        [HttpGet]
        public IActionResult GetBalance(string account_id)
        {
            var account = _accountManager.GetAccount(account_id);

            var newContact = new Contact
            {
                Name = "John",
                Surname = "Lincon"
            };

            _context.Add(newContact);

            _context.SaveChanges();

            var contacts = _context.Contacts.AsEnumerable();

            foreach (var contact in contacts)
            {
                Console.WriteLine(contact.Name);
            }

            if (account == null)
            {
                return NotFound(0);
            }

            return Ok(account.Balance);
        }
    }
}

