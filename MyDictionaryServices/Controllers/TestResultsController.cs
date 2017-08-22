using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyDictionaryServices.Commands.PrepareTest;
using MyDictionaryServices.Core.Commands;
using MyDictionaryServices.Core.Controllers;
using MyDictionaryServices.Models;
using MyDictionaryServices.Models.PrepareTest;
using MyDictionaryServices.Queries.PrepareTest;
using System.Linq;

namespace MyDictionaryServices.Controllers
{
    [Route("api/[controller]")]
    public class TestResultsController : BaseApiController
    {
        private readonly ITestResultQueries _queries;

        public TestResultsController(ITestResultQueries queries, IConfiguration cfg, ICommandBus bus)
            : base(bus)
        {
            _queries = queries;
        }

        [HttpPost]
        public IActionResult CreateTestResult([FromBody] TestResultModel testResult)
        {
            var command = new CreateTestResultsCommand(testResult);

            return ProcessCommand(command);
        }

        [HttpPut]
        public IActionResult UpdateTestResult([FromBody] TestResults testResult)
        {

            var command = new UpdateTestResultsCommand(testResult, isPatch: false);
            return ProcessCommand(command);
        }

        [HttpPatch]
        public IActionResult PatchUpdateTestResult([FromBody] TestResults profile)
        {

            var command = new UpdateTestResultsCommand(profile, isPatch: true);
            return ProcessCommand(command);
        }

        [Route("{userid:int}")]
        [HttpDelete]
        public IActionResult DeleteTestReult(int userid)
        {
            var command = new DeleteTestResultsCommand(userid);
            return ProcessCommand(command);
        }

        [HttpGet()]
        public IActionResult GetAll(bool isRecent, int userid)
        {
            var count = _queries.CountAsync();
            var testResults = _queries.GetAllAsync(true, userid);
                
            var model = testResults.Select(MapModel);
            return Ok(model);
        }

        private static TestResultModel MapModel(TestResults testResult)
        {
            var model = new TestResultModel
            {
                AttemtedDate = testResult.AttemtedDate,
                CorrectAnwers = testResult.CorrectAnwers,
                AvailableQuestionsInDictionary = testResult.AvailableQuestionsInDictionary,
                PrimaryLanguage = testResult.PrimaryLanguage,
                QuestionsAttempted = testResult.QuestionsAttempted,
                QuestionsTaken = testResult.QuestionsTaken,
                SecondaryLanguage = testResult.SecondaryLanguage,
                UserId = testResult.UserId
            };
            return model;
        }
    }
}
