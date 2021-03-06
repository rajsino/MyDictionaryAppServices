﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyDictionaryServices.Models.Profiles;
using MyDictionaryServices.Data.Profiles;
using Microsoft.EntityFrameworkCore;


namespace MyDictionaryServices.Queries.Profiles
{
    public class TenantQueries : ITenantQueries
    {

        private readonly ProfilesDbContext _db;
        public TenantQueries(ProfilesDbContext ctx)
        {
            _db = ctx;
        }

        public async Task<IEnumerable<Tenant>> GetAllAsync()
        {
            var data = await _db.Tenants.ToListAsync();

            return data;
        }

        public Tenant GetById(int id)
        {
            return _db.Tenants.SingleOrDefault(x => x.Id == id);
        }

        public Tenant GetByUserId(int userid)
        {
            return _db.Tenants.SingleOrDefault(t => t.Users.Any(u => u.Id == userid));
        }
    }
}
