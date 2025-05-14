namespace BlazorPBM.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? NAIC { get; set; }

        public virtual ICollection<Policy> Policy { get; set; } = new List<Policy>();
    }
}
