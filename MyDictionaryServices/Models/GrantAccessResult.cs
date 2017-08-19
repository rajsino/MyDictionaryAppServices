namespace MyDictionaryServices.Models
{
    public class GrantAccessResult
    {
        public int UserId { get; set; }
        public int ProfileId { get; set; }

        public string AccessToken { get; set; }
        public int TenantId { get; set; }
        public string TenantName { get; set; }
    }
}