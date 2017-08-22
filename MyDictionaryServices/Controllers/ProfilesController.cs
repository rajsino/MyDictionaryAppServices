using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyDictionaryServices.Commands.Profiles;
using MyDictionaryServices.Core.Commands;
using MyDictionaryServices.Core.Controllers;
using MyDictionaryServices.Models;
using MyDictionaryServices.Models.Profiles;
using MyDictionaryServices.Queries.Profiles;

namespace MyDictionaryServices.Controllers
{
    [Route("api/[controller]")]
    public class ProfilesController : BaseApiController
    {
        private readonly IProfileQueries _queries;

        public ProfilesController(IProfileQueries queries, IConfiguration cfg, ICommandBus bus)
            : base(bus)
        {
            _queries = queries;
        }

        [HttpPost]
        public IActionResult CreateProfile([FromBody] UserAndProfileModel profile)
        {
            var command = new CreateProfileAndUserCommand(profile);

            return ProcessCommand(command);

        }

        [HttpPut]
        public IActionResult UpdateProfile([FromBody] UserProfile profile)
        {

            var command = new UpdateProfileCommand(profile, isPatch: false);
            return ProcessCommand(command);
        }

        [HttpPatch]
        public IActionResult PatchUpdateProfile([FromBody] UserProfile profile)
        {

            var command = new UpdateProfileCommand(profile, isPatch: true);
            return ProcessCommand(command);
        }

        [Route("{userid:int}")]
        [HttpDelete]
        public IActionResult DeleteProfile(int userid)
        {
            var command = new DeleteProfileCommand(userid);
            return ProcessCommand(command);
        }
    }
}
