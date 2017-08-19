using System;
using System.Linq;
using MyDictionaryServices.Models.Profiles;
using MyDictionaryServices.Data.Profiles;
using Microsoft.EntityFrameworkCore;

namespace MyDictionaryServices.Queries.Profiles
{
    public class ProfileQueries : IProfileQueries
    {
        private readonly ProfilesDbContext _ctx;
        public ProfileQueries(ProfilesDbContext ctx)
        {
            _ctx = ctx;
        }

        public UserProfile GetByUserId(int userid)
        {
            return _ctx.Profiles.SingleOrDefault(p => p.UserId == userid);
        }
        
        public UserProfile GetByEmail(string value)
        {
            return _ctx.Profiles.FirstOrDefault(p => p.Email == value);
        }

        public UserProfile GetByMobile(string value)
        {
            return _ctx.Profiles.FirstOrDefault(p => p.Mobile == value);
        }
    }
}
