namespace BlazorPBM.Models
{
    public class LifeCase : Audit
    {
        public int LifeCaseId { get; set; }
        public int OwnerId { get; set; }
        public string? Status { get; set; }
        public int InsuredId { get; set; }
        public string? PolicyNumber { get; set; }
        public DateTime PolicyIssued { get; set; }
        public int CompanyId { get; set; }
        public DateTime ParamedDate { get; set; }
        public string? ParamedName { get; set; }
        public DateTime ApplicationDate { get; set; }
        public decimal? FaceAmount { get; set; }
        public int? Years { get; set; }
        public string? Class { get; set; }
        public decimal? Premium { get; set; }
        public int Age { get; set; }
        public decimal? Height { get; set; }
        public decimal? Weight { get; set; }
        public bool WorkingNow { get; set; }
        public int? PolicyId { get; set; }
        public int? RelativeId { get; set; }
        public string? RelativeName { get; set; }
        public DateTime RelativeDateOfBirth { get; set; }
        public string? RelativeSocialSecurity { get; set; }

        public virtual Company? Company { get; set; }
        public virtual User? Owner { get; set; }
        public virtual List<LifeCaseOffer>? Offers { get; set; }
        public virtual Insured? Insured { get; set; }
        public virtual Insured? Relative { get; set; }
    }
}
