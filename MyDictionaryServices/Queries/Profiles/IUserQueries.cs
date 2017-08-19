using System.Collections.Generic;
using MyDictionaryServices.Models.Profiles;

namespace MyDictionaryServices.Queries.Profiles
{
    public interface IUserQueries
    {
        User GetUserById(int userid);
        IEnumerable<User> GetUsersById(IEnumerable<int> userid);
    }
}
