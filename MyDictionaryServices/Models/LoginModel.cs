namespace MyDictionaryServices.Models
{
    public class LoginModel
    {
        public string UserName { get; set; }
        public string Credentials { get; set; }

        public string GrantType { get; set; }
        public const string PasswordGrantType = "password";
    }
}
