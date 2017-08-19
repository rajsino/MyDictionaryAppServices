using MyDictionaryServices.Core.Commands;
using MyDictionaryServices.Models;
using MyDictionaryServices.Models.PrepareTest;
using System.Collections.Generic;

namespace MyDictionaryServices.Commands.PrepareTest
{
    public class CreateTestResultsCommand : CommandBase
    {
        public TestResults TestResult { get; }

        private readonly TestResultModel _model;


        public CreateTestResultsCommand(TestResultModel model)
        {
            _model = model;
            TestResult = CreateProfileFromModel(model);
        }

        private TestResults CreateProfileFromModel(TestResultModel model)
        {
            var TestResult = new TestResults()
            {
                UserId = model.UserId,
                AttemtedDate = model.AttemtedDate,
                PrimaryLanguage = model.PrimaryLanguage,
                SecondaryLanguage = model.SecondaryLanguage,
                AvailableQuestionsInDictionary = model.AvailableQuestionsInDictionary,
                QuestionsTaken = model.QuestionsTaken,
                QuestionsAttempted = model.QuestionsAttempted,
                CorrectAnwers = model.CorrectAnwers,
            };

            return TestResult;
        }

        protected override IEnumerable<string> OnValidation()
        {
            if (_model == null)
            {
                yield return "invalid test results..";
            }
        }
    }
}
