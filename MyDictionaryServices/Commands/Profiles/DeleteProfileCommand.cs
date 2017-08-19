using MyDictionaryServices.Core.Commands;
using System.Collections.Generic;

namespace MyDictionaryServices.Commands.Profiles
{
    public class DeleteProfileCommand : CommandBase
    {
        public int UserId { get; }

        public DeleteProfileCommand(int userid)
        {
            UserId = userid;
        }

        protected override IEnumerable<string> OnValidation()
        {
            if (UserId <= 0)
            {
                yield return "Missing or invalid userId";
            }
        }

    }
}
