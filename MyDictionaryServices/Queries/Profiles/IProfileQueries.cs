using MyDictionaryServices.Models.Profiles;
using System;

namespace MyDictionaryServices.Queries.Profiles
{
    public interface IProfileQueries
    {
        UserProfile GetByUserId(int userid);
        UserProfile GetByMobile(string value);
        UserProfile GetByEmail(string value);
    }
}
