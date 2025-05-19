namespace BlazorPBM.Models
{
    public class Insured : Audit
    {
        public int InsuredId { get; set; }
        public string? FirstName { get; set; }
        //public string MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? FullName { get; set; }
        //public string PersonOfContact { get; set; }
        //public string MailAddress { get; set; }
        //public string MailCity { get; set; }
        //public string MailState { get; set; }
        //public string MailZip { get; set; }
        public string? ResidenceAddress { get; set; }
        public string? ResidenceCity { get; set; }
        public string? ResidenceState { get; set; }
        public string? ResidenceZip { get; set; }
        //public string ResidencePhone { get; set; }
        public string? Email { get; set; }
        public string? Contact { get; set; }
        //public string AlternativeContact { get; set; }
        //public string HomeContact { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        //public string Nationality { get; set; }
        //public string USEntry { get; set; }
        //public string Passport { get; set; }
        public string? DriversLicense { get; set; }
        public string? DriversLicenseName { get; set; }
        public string? SocialSecurity { get; set; }
        public string? TaxIdNumber { get; set; }
        //public string CitizenVisa { get; set; }
        //public string CertificateOfFormation { get; set; }
        //public bool Business { get; set; }
        //public string Occupation { get; set; }
        //public string Employer { get; set; }
        //public string EmployerAddress { get; set; }
        //public string YearsInBusiness { get; set; }
        //public decimal? YearlyIncome { get; set; }
        //public bool HomeOwner { get; set; }
        //public string YearsInResidenceAddress { get; set; }
        //public decimal? Assets { get; set; }
        //public decimal? Liabilities { get; set; }
        //public decimal? Networth { get; set; }
        //public string DropboxFolderURL { get; set; }
        //public string Remarks { get; set; }
        //public bool Life { get; set; }
        //public bool PC { get; set; }
        public decimal? Height { get; set; }
        public decimal? Weight { get; set; }
        public int? RelativeId { get; set; }
        public string? RelativeName { get; set; }
        public string? RelativeDateOfBirth { get; set; }
        public string? RelativeSocialSecurity { get; set; }

        //public virtual ICollection<CustomerRemark> CustomerRemark { get; set; } = new List<CustomerRemark>();

        //public virtual ICollection<Policy> Policy { get; set; } = new List<Policy>();
    }
}
