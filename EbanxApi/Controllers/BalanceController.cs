using EbanxApi.Services.AccountManager;
using Microsoft.AspNetCore.Mvc;

namespace EbanxApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BalanceController : ControllerBase
    {
        private readonly IAccountManager _accountManager;

        public BalanceController(IAccountManager accountManager)
        {
            _accountManager = accountManager;
        }

        [HttpGet]
        public IActionResult GetBalance(string account_id)
        {
            var account = _accountManager.GetAccount(account_id);

            if (account == null)
            {
                return NotFound(0);
            }

            return Ok(account.Balance);
        }
    }
}

