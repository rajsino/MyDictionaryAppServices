using MyDictionaryServices.Data.Profiles;
using MyDictionaryServices.Models.PrepareTest;
using System.Collections.Generic;
using System.Linq;

namespace MyDictionaryServices.Queries.PrepareTest
{
    public class TestResultQueries : ITestResultQueries
    {
        private readonly ProfilesDbContext _ctx;

        public TestResultQueries(ProfilesDbContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<TestResults> GetAllAsync(bool isRecent, int userId)
        {
            var data = _ctx.TestResults.Where(e => e.Id == userId).OrderByDescending(e => e.Id).ToList<TestResults>();
            return data;
        }

        public int CountAsync()
        {
            return _ctx.TestResults.Count();
        }
    }
}
