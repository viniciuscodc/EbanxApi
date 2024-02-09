using EbanxApi.Services.AccountManager;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EbanxApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ResetController : ControllerBase
    {
        private readonly IAccountManager _accountManager;

        public ResetController(IAccountManager accountManager)
        {
            _accountManager = accountManager;
        }

        [HttpPost]
        public IActionResult ResetAccounts()
        {
            _accountManager.Accounts.Clear();

            return Content("OK");
        }
    }
}
