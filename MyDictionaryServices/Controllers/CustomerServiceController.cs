using Microsoft.AspNetCore.Mvc;
using MyDictionaryServices.Core.Commands;
using MyDictionaryServices.Core.Controllers;

namespace MyDictionaryServices.Controllers
{
    [Route("api/[controller]")]
    public class CustomerServiceController : BaseApiController
    {
        public CustomerServiceController(ICommandBus bus) : base(bus)
        {
        }
    }
}