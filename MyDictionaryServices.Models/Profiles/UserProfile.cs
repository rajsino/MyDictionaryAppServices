using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyDictionaryServices.Models.Profiles
{
    public class UserProfile
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
        public Gender Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        
        public string Mobile { get; set; }

        public UserProfile()
        {
            Gender = Gender.NotSpecified;
        }
    }
}