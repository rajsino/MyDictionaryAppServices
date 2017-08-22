using Microsoft.AspNetCore.Mvc;
using MyDictionaryServices.Commands.Profiles;
using MyDictionaryServices.Core.Commands;
using MyDictionaryServices.Core.Controllers;
using MyDictionaryServices.Models;

namespace MyDictionaryServices.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : BaseApiController
    {
        public LoginController(ICommandBus commandBus) : base(commandBus) { }

        [HttpPost]
        public IActionResult PostLogin([FromBody] LoginModel data)
        {
            var command = new GrantAccessCommand(data);
            return ProcessCommand(command);

        }
    }
}

