namespace BlazorPBM.Models
{
    public class LifeCaseOffer : Audit
    {
        public int LifeCaseOfferId { get; set; }
        public int LifeCaseId { get; set; }
        public string? Type { get; set; }
        public int? CompanyId { get; set; }
        public string? PolicyNumber { get; set; }
        public DateTime? PolicyExpiry { get; set; }
        public decimal? FaceAmount { get; set; }
        public int? Years { get; set; }
        public string? Class { get; set; }
        public string? Riders { get; set; }
        public decimal? Premium { get; set; }
        public string? PaymentMode { get; set; }        
        public int? PolicyId { get; set; }
    }
}