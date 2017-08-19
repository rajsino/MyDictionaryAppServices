using MyDictionaryServices.Core.Commands;
using MyDictionaryServices.Data.Profiles;
using System.Linq;

namespace MyDictionaryServices.Commands.PrepareTest
{
    public class DeleteTestResultsCommandHandler : ICommandHandler<DeleteTestResultsCommand>
    {
        private readonly ProfilesDbContext _db;

        public DeleteTestResultsCommandHandler(ProfilesDbContext db)
        {
            _db = db;
        }
        public CommandHandlerResult Handle(DeleteTestResultsCommand command)
        {
            var existing = _db.TestResults.SingleOrDefault(p => p.Id == command.TestId);
            if (existing != null)
            {
                _db.TestResults.Remove(existing);
            }
            return CommandHandlerResult.Ok;
        }
    }
}
