using Autofac;
using MyDictionaryServices.Data.Profiles;
using MyDictionaryServices.Core.Commands;

namespace MyDictionaryServices.Commands.Profiles
{
    public class ProfilesCommandBus : CommandBus<ProfilesDbContext>
    {
        public ProfilesCommandBus(ILifetimeScope scope) : base(scope)
        {
        }
    }
}
