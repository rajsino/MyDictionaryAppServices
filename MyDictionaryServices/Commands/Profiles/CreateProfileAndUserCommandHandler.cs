using MyDictionaryServices.Core.Commands;
using MyDictionaryServices.Data.Profiles;
using System.Linq;

namespace MyDictionaryServices.Commands.Profiles
{
    public class CreateProfileAndUserCommandHandler : ICommandHandler<CreateProfileAndUserCommand>
    {
        private readonly ProfilesDbContext _db;
        private CreateProfileAndUserCommand _command;
        public CreateProfileAndUserCommandHandler(ProfilesDbContext db)
        {
            _db = db;
        }

        public CommandHandlerResult Handle(CreateProfileAndUserCommand command)
        {
            _command = command;
            var existing = _db.Users.Any(x => x.UserName == command.User.UserName);
            if (existing)
            {
                return CommandHandlerResult.Error($"Invalid username ({command.User.UserName})");
            }

            _db.Users.Add(command.User);
            return CommandHandlerResult.OkDelayed(this,
                x => new
                {
                    UserId = _command.User.Id,
                    ProfileId = _command.Profile.Id
                });
        }
    }
}
