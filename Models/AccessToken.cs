namespace BlazorPBM.Models
{
    public class AccessToken
    {
        public string? Access_token { get; set; }
        public int Expires_in { get; set; }
        public string? Refresh_token { get; set; }
        public string? Scope { get; set; }
        public string? Token_type { get; set; }
    }

    public class GoogleUserInfo
    {
        public string? Id { get; set; }
        public string? Email { get; set; }
        public bool Verified_Email { get; set; }
        public string? Name { get; set; }
        public string? Given_Name { get; set; }
        public string? Family_Name { get; set; }
        public string? Picture { get; set; }
        public string? Locale { get; set; }
        public int UserId { get; set; }
    }
}
