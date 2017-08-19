using MyDictionaryServices.Core.Commands;
using System.Collections.Generic;

namespace MyDictionaryServices.Commands.PrepareTest
{
    public class DeleteTestResultsCommand : CommandBase
    {
        public int TestId { get; }

        public DeleteTestResultsCommand(int testId)
        {
            TestId = testId;
        }

        protected override IEnumerable<string> OnValidation()
        {
            if (TestId <= 0)
            {
                yield return "Missing or invalid test id";
            }
        }

    }
}
