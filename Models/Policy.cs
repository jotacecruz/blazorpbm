namespace BlazorPBM.Models
{
    public class Policy
    {
        public int PolicyId { get; set; }

        public int PolicyTypeId { get; set; }

        public int AgentId { get; set; }

        public int CompanyId { get; set; }

        public int CustomerId { get; set; }

        public string? Number { get; set; }

        public string? InsuredName { get; set; }

        public DateOnly? EffectiveDate { get; set; }

        public DateOnly? ExpirationDate { get; set; }

        public decimal? Premium { get; set; }

        public decimal? PoliciesInForce { get; set; }

        public decimal? CoverageAmount { get; set; }

        public bool Renewal { get; set; }

        public int PolicyStatusId { get; set; }

        public DateTime Modified { get; set; }

        public string? ModifiedBy { get; set; }

        //public virtual Agent Agent { get; set; }

        //public virtual Company Company { get; set; }

        //public virtual Customer Customer { get; set; }

        //public virtual PolicyStatus PolicyStatus { get; set; }

        //public virtual PolicyType PolicyType { get; set; }
    }
}
