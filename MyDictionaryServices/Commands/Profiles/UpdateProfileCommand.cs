﻿using MyDictionaryServices.Core.Commands;
using MyDictionaryServices.Models.Profiles;
using System.Collections.Generic;

namespace MyDictionaryServices.Commands.Profiles
{
    public class UpdateProfileCommand : CommandBase
    {
        public bool IsPatch { get; }
        public UserProfile Profile { get; }
        public UpdateProfileCommand(UserProfile profile, bool isPatch)
        {
            Profile = profile;
            IsPatch = isPatch;
        }


        protected override IEnumerable<string> OnValidation()
        {
            if (Profile.UserId == 0)
            {
                yield return "userId is missing";
            }

            if (Profile.Id > 0)
            {
                yield return "id can't be set on the payload";
            }

            if (!IsPatch)
            {
                foreach (var msg in FullValidation())
                {
                    yield return msg;
                }
            }
        }

        private IEnumerable<string> FullValidation()
        {
            if (string.IsNullOrEmpty(Profile.FirstName))
            {
                yield return "firstName is missing";
            }
            if (string.IsNullOrEmpty(Profile.LastName))
            {
                yield return "lastName is missing";
            }

            if (Profile.BirthDate == null)
            {
                yield return "birthDate is missing";
            }

            if (string.IsNullOrEmpty(Profile.Email))
            {
                yield return "email is missing";
            }
        }
    }
}
