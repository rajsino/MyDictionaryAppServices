using Jose;
using System.Collections.Generic;

namespace MyDictionaryServices.Security
{
    public class TokenGenerator
    {
        public string CreateJwtToken(int userid, int profileid, string email)
        {
            var payload = new Dictionary<string, object>()
                {
                    { JwtNames.Subject, userid},
                    { JwtNames.ProfileId, profileid },
                    { JwtNames.Email, email }

                };
            string token = JWT.Encode(payload, null, JwsAlgorithm.none);

            return token;
        }


        public string DecodeToken(string token)
        {
            var decoded = JWT.Decode(token);
            return decoded;
        }
    }
}