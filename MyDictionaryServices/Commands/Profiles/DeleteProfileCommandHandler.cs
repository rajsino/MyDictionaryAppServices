using MyDictionaryServices.Core.Commands;
using MyDictionaryServices.Data.Profiles;
using System.Linq;

namespace MyDictionaryServices.Commands.Profiles
{
    public class DeleteProfileCommandHandler : ICommandHandler<DeleteProfileCommand>
    {
        private readonly ProfilesDbContext _db;
        public DeleteProfileCommandHandler(ProfilesDbContext db)
        {
            _db = db;
        }
        public CommandHandlerResult Handle(DeleteProfileCommand command)
        {
            var existing = _db.Profiles.SingleOrDefault(p => p.UserId == command.UserId);
            if (existing != null)
            {
                _db.Profiles.Remove(existing);
            }

            return CommandHandlerResult.Ok;
        }
    }
}
