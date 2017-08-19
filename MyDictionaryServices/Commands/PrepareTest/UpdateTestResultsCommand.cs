using MyDictionaryServices.Core.Commands;
using MyDictionaryServices.Models.PrepareTest;
using System.Collections.Generic;

namespace MyDictionaryServices.Commands.PrepareTest
{
    public class UpdateTestResultsCommand : CommandBase
    {
        public bool IsPatch { get; }
        public TestResults TestResult { get; }
        public UpdateTestResultsCommand(TestResults testResult, bool isPatch)
        {
            TestResult = testResult;
            IsPatch = isPatch;
        }


        protected override IEnumerable<string> OnValidation()
        {
            if (TestResult.UserId == 0)
            {
                yield return "userId is missing";
            }

            if (TestResult.Id > 0)
            {
                yield return "id can't be set on the payload";
            }

            if (!IsPatch)
            {
                foreach (var msg in FullValidation())
                {
                    yield return msg;
                }
            }
        }

        private IEnumerable<string> FullValidation()
        {
            if (TestResult.AttemtedDate == null)
            {
                yield return "Attended date is missing";
            }
        }
    }
}
