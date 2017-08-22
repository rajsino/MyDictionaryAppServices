using Microsoft.AspNetCore.Mvc;
using MyDictionaryServices.Core.Commands;
using MyDictionaryServices.Core.Controllers;
using MyDictionaryServices.Models;
using MyDictionaryServices.Models.Profiles;
using MyDictionaryServices.Queries.Profiles;
using System.Linq;

namespace MyDictionaryServices.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : BaseApiController
    {
        private readonly IUserQueries _queries;
        private readonly ITenantQueries _tenantQueries;
        public UsersController(IUserQueries queries, ITenantQueries tenantQueries, ICommandBus bus) : base(bus)
        {
            _queries = queries;
            _tenantQueries = tenantQueries;
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var user = _queries.GetUserById(id);
            if (user == null)
            {
                return NotFound($"User with {id} not found");
            }

            user.Password = null;

            return Ok(user);
        }

        [HttpGet("{id:int}/tenant")]
        public IActionResult GetTenantByUser(int id)
        {
            var tenant = _tenantQueries.GetByUserId(id);
            if (tenant == null)
            {
                return NotFound();
            }
            return Ok(new
            {
                Id = tenant.Id,
                Name = tenant.Name
            });
        }

        [HttpGet()]
        public IActionResult GetById(int[] id)
        {
            var users = _queries.GetUsersById(id).Select(MapUser);
            if (!users.Any())
            {
                return NotFound($"Users were not found");
            }

            return Ok(users);
        }

        private QueryUserModel MapUser(User user)
        {
            return new QueryUserModel
            {
                UserId = user.Id,
                Email = user.Profile.Email,
                FirstName = user.Profile.FirstName,
                LastName = user.Profile.LastName
            };
        }
    }
}
