using MyDictionaryServices.Core.Commands;
using MyDictionaryServices.Models;
using System.Collections.Generic;

namespace MyDictionaryServices.Commands.Profiles
{
    public class GrantAccessCommand : CommandBase
    {

        public LoginModel Data { get; }
        public GrantAccessCommand(LoginModel data)
        {
            Data = data;
        }

        protected override IEnumerable<string> OnValidation()
        {
            if (Data.GrantType != LoginModel.PasswordGrantType)
            {
                yield return $"Invalid grantType: {Data.GrantType}";
            }
        }
    }
}
