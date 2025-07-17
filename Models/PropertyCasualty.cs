namespace BlazorPBM.Models
{
    public class PropertyCasualty : Audit
    {
        public int PropertyCasualtyId { get; set; }
        public int PropertyCasualtyTypeId { get; set; }
        public int CompanyId { get; set; }
        public string? Broker { get; set; }
        public int OwnerId { get; set; }
        public string? Status { get; set; }
        public int InsuredId { get; set; }
        public bool WorkingNow { get; set; }
        public string? PolicyNumber { get; set; }
        public DateTime PolicyEffective { get; set; }
        public int Months { get; set; }
        public DateTime PolicyExpire { get; set; }
        public decimal? Premium { get; set; }
        public decimal? CommissionPercentage { get; set; }
        public decimal? Commission { get; set; }

        public virtual PropertyCasualtyType? PropertyCasualtyType { get; set; }
        public virtual Company? Company { get; set; }
        public virtual User? Owner { get; set; }
        public virtual Insured? Insured { get; set; }
    }
}
