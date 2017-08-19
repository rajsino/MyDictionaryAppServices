using MyDictionaryServices.Core.Commands;
using MyDictionaryServices.Data.Profiles;
using System.Linq;

namespace MyDictionaryServices.Commands.PrepareTest
{
    public class CreateTestResultsCommandHandler : ICommandHandler<CreateTestResultsCommand>
    {
        private readonly ProfilesDbContext _db;
        public CreateTestResultsCommandHandler(ProfilesDbContext db)
        {
            _db = db;
        }

        public CommandHandlerResult Handle(CreateTestResultsCommand command)
        {
            _db.TestResults.Add(command.TestResult);
            return CommandHandlerResult.Ok;
        }
    }
}
