using EbanxApi.Models.Events;
using EbanxApi.Services.AccountManager;
using Microsoft.AspNetCore.Mvc;

namespace EbanxApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IAccountManager _accountManager;

        public EventController(IAccountManager accountManager)
        {
            _accountManager = accountManager;
        }

        [HttpPost]
        public IActionResult MakeTransaction([FromBody] OperationModel model)
        {
            var result = _accountManager.MakeTransaction(model.Type, model);

            if(result == null)
            {
                return NotFound(0);
            }

            return new ObjectResult(result) { StatusCode = StatusCodes.Status201Created };
        }  
    }
}
