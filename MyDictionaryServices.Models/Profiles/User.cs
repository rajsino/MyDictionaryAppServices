using MyDictionaryServices.Models.PrepareTest;
using System;
using System.Collections.Generic;

namespace MyDictionaryServices.Models.Profiles
{
    public class User
    {
        public int Id { get; set; }

        public string UserName { get; set; }
        public DateTime LastLogin { get; set; }

        public UserProfile Profile { get; set; }

        public string Password { get; set; }

        public int TenantId { get; set; }
        public Tenant Tenant { get; set; }
    }
}
