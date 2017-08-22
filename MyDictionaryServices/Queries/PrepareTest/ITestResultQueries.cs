using MyDictionaryServices.Models.PrepareTest;
using System.Collections.Generic;

namespace MyDictionaryServices.Queries.PrepareTest
{
    public interface ITestResultQueries
    {
        IEnumerable<TestResults> GetAllAsync(bool isRecent, int userId);
        int CountAsync();
    }
}