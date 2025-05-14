namespace BlazorPBM.Models
{
    public class User : Audit
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public DateTime LastAccess { get; set; }
        public bool Active { get; set; }
    }
}
