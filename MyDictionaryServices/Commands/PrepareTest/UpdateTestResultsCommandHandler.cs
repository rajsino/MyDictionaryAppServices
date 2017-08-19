using MyDictionaryServices.Core.Commands;
using MyDictionaryServices.Data.Profiles;
using MyDictionaryServices.Models.PrepareTest;
using System.Linq;

namespace MyDictionaryServices.Commands.PrepareTest
{
    public class UpdateTestResultsCommandHandler : ICommandHandler<UpdateTestResultsCommand>
    {
        private readonly ProfilesDbContext _db;
        public UpdateTestResultsCommandHandler(ProfilesDbContext db)
        {
            _db = db;
        }
        public CommandHandlerResult Handle(UpdateTestResultsCommand command)
        {
            var testResult = command.TestResult;
            var patching = command.IsPatch;
            var existing = _db.TestResults.SingleOrDefault(p => p.UserId == testResult.UserId);
            if (existing == null)
            {
                return CommandHandlerResult.Error("no profile found");
            }

            if (!patching)
            {
                existing.AttemtedDate = testResult.AttemtedDate;
                existing.AvailableQuestionsInDictionary = testResult.AvailableQuestionsInDictionary;
                existing.CorrectAnwers = testResult.CorrectAnwers;
                existing.PrimaryLanguage = testResult.PrimaryLanguage;
                existing.QuestionsAttempted = testResult.QuestionsAttempted;
                existing.QuestionsTaken = testResult.QuestionsTaken;
                existing.SecondaryLanguage = testResult.SecondaryLanguage;
                existing.UserId = testResult.UserId;
                return CommandHandlerResult.Ok;
            }
            else return PatchProfile(existing, testResult);
        }

        private CommandHandlerResult PatchProfile(TestResults existing, TestResults profile)
        {

            if (profile.AttemtedDate.HasValue)
            {
                existing.AttemtedDate = profile.AttemtedDate;
            }
            if (profile.AvailableQuestionsInDictionary > 0)
            {
                existing.AvailableQuestionsInDictionary = profile.AvailableQuestionsInDictionary;
            }
            if (profile.CorrectAnwers > 0)
            {
                existing.CorrectAnwers = profile.CorrectAnwers;
            }
            if (!string.IsNullOrEmpty(profile.PrimaryLanguage))
            {
                existing.PrimaryLanguage = profile.PrimaryLanguage;
            }

            if (!string.IsNullOrEmpty(profile.SecondaryLanguage))
            {
                existing.SecondaryLanguage = profile.SecondaryLanguage;
            }

            if (profile.QuestionsTaken > 0)
            {
                existing.QuestionsTaken = profile.QuestionsTaken;
            }

            return CommandHandlerResult.Ok;
        }
    }
}
