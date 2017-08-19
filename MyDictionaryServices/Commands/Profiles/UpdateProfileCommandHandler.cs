using MyDictionaryServices.Core.Commands;
using MyDictionaryServices.Data.Profiles;
using MyDictionaryServices.Models.Profiles;
using System.Linq;

namespace MyDictionaryServices.Commands.Profiles
{
    public class UpdateProfileCommandHandler : ICommandHandler<UpdateProfileCommand>
    {
        private readonly ProfilesDbContext _db;
        public UpdateProfileCommandHandler(ProfilesDbContext db)
        {
            _db = db;
        }
        public CommandHandlerResult Handle(UpdateProfileCommand command)
        {
            var profile = command.Profile;
            var patching = command.IsPatch;
            var existing = _db.Profiles.SingleOrDefault(p => p.UserId == profile.UserId);
            if (existing == null)
            {
                return CommandHandlerResult.Error("no profile found");
            }

            if (!patching)
            {
                existing.BirthDate = profile.BirthDate;
                existing.FirstName = profile.FirstName;
                existing.Gender = profile.Gender;
                existing.LastName = profile.LastName;
                existing.Email = profile.Email;
                if (profile.Mobile != null)
                {
                    existing.Mobile = profile.Mobile;
                }

                return CommandHandlerResult.Ok;
            }
            else return PatchProfile(existing, profile);
        }

        private CommandHandlerResult PatchProfile(UserProfile existing, UserProfile profile)
        {

            if (profile.BirthDate.HasValue)
            {
                existing.BirthDate = profile.BirthDate;
            }
            if (!string.IsNullOrEmpty(profile.FirstName))
            {
                existing.FirstName = profile.FirstName;
            }
            if (!string.IsNullOrEmpty(profile.LastName))
            {
                existing.LastName = profile.LastName;
            }
            if (profile.Gender != Gender.NotSpecified)
            {
                existing.Gender = profile.Gender;
            }

            if (!string.IsNullOrEmpty(profile.Email))
            {
                existing.Email = profile.Email;
            }

            if (profile.Mobile != null)
            {
                existing.Mobile = profile.Mobile;
            }

            return CommandHandlerResult.Ok;
        }
    }
}
