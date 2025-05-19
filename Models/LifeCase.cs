using System.ComponentModel;
using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace BlazorPBM.Models
{
    public class LifeCase : Audit
    {
        public int LifeCaseId { get; set; }
        public int OwnerId { get; set; }
        public string? Status { get; set; }
        public int InsuredId { get; set; }
        public bool WorkingNow { get; set; }
        public int? PolicyId { get; set; }
        public string? PolicyNumber { get; set; }
        public int CompanyId { get; set; }
        public DateTime PolicyIssued { get; set; }
        public DateTime ParamedDate { get; set; }
        public string? ParamedName { get; set; }
        public DateTime ApplicationDate { get; set; }
        public decimal? FaceAmount { get; set; }
        public int? Years { get; set; }
        public string? Class { get; set; }
        public decimal? Premium { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ResidenceAddress { get; set; }
        public string? ResidenceCity { get; set; }
        public string? ResidenceState { get; set; }
        public string? ResidenceZip { get; set; }
        public string? Email { get; set; }
        public string? Contact { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string? DriversLicense { get; set; }
        public string? DriversLicenseName { get; set; }
        public string? SocialSecurity { get; set; }
        public string? TaxIdNumber { get; set; }
        public decimal? Height { get; set; }
        public decimal? Weight { get; set; }

        public int? RelativeId { get; set; }
        public string? RelativeName { get; set; }
        public DateTime RelativeDateOfBirth { get; set; }
        public string? RelativeSocialSecurity { get; set; }

        public virtual Company? Company { get; set; }
        public virtual User? Owner { get; set; }
        public virtual List<LifeCaseOffer> Offers { get; set; } = new List<LifeCaseOffer>() {
            new LifeCaseOffer() { Type = "ACTIVE BEFORE" },
            new LifeCaseOffer() { Type = "APPLYING FOR" },
            new LifeCaseOffer() { Type = "COMPANY OFFER" },
            new LifeCaseOffer() { Type = "COUNTER OFFER" },
            new LifeCaseOffer() { Type = "ACCEPTANCE" }
        };
        public virtual Insured? Insured { get; set; }
        public virtual Insured? Relative { get; set; }

        public virtual int? OfferABCompanyId
        {
            get => Offers?.FirstOrDefault(x => x.Type == "ACTIVE BEFORE")?.CompanyId;
            set
            {
                LifeCaseOffer? offer = Offers?.FirstOrDefault(x => x.Type == "ACTIVE BEFORE");
                if (offer is not null)
                    offer.CompanyId = value;
            }
        }
        public string? OfferABPolicyNumber
        {
            get => Offers?.FirstOrDefault(x => x.Type == "ACTIVE BEFORE")?.PolicyNumber;
            set
            {
                LifeCaseOffer? offer = Offers?.FirstOrDefault(x => x.Type == "ACTIVE BEFORE");
                if (offer is not null)
                    offer.PolicyNumber = value;
            }
        }
        public DateTime? OfferABPolicyExpiry
        {
            get => Offers?.FirstOrDefault(x => x.Type == "ACTIVE BEFORE")?.PolicyExpiry;
            set
            {
                LifeCaseOffer? offer = Offers?.FirstOrDefault(x => x.Type == "ACTIVE BEFORE");
                if (offer is not null)
                    offer.PolicyExpiry = value;
            }
        }

        public virtual decimal? OfferABFaceAmount
        {
            get => Offers?.FirstOrDefault(x => x.Type == "ACTIVE BEFORE")?.FaceAmount;
            set
            {
                LifeCaseOffer? offer = Offers?.FirstOrDefault(x => x.Type == "ACTIVE BEFORE");
                if (offer is not null)
                    offer.FaceAmount = value ?? 0M;
            }
        }
        
        public virtual int? OfferABYears
        {
            get => Offers?.FirstOrDefault(x => x.Type == "ACTIVE BEFORE")?.Years;
            set
            {
                LifeCaseOffer? offer = Offers?.FirstOrDefault(x => x.Type == "ACTIVE BEFORE");
                if (offer is not null)
                    offer.Years = value;
            }
        }
        
        public virtual string? OfferABClass
        {
            get => Offers?.FirstOrDefault(x => x.Type == "ACTIVE BEFORE")?.Class;
            set
            {
                LifeCaseOffer? offer = Offers?.FirstOrDefault(x => x.Type == "ACTIVE BEFORE");
                if (offer is not null)
                    offer.Class = value;
            }
        }
        
        public virtual string? OfferABRiders
        {
            get => Offers?.FirstOrDefault(x => x.Type == "ACTIVE BEFORE")?.Riders;
            set
            {
                LifeCaseOffer? offer = Offers?.FirstOrDefault(x => x.Type == "ACTIVE BEFORE");
                if (offer is not null)
                    offer.Riders = value;
            }
        }
        
        public virtual decimal? OfferABPremium
        {
            get => Offers?.FirstOrDefault(x => x.Type == "ACTIVE BEFORE")?.Premium;
            set
            {
                LifeCaseOffer? offer = Offers?.FirstOrDefault(x => x.Type == "ACTIVE BEFORE");
                if (offer is not null)
                    offer.Premium = value;
            }
        }
        
        public virtual string? OfferABPaymentMode
        {
            get => Offers?.FirstOrDefault(x => x.Type == "ACTIVE BEFORE")?.PaymentMode;
            set
            {
                LifeCaseOffer? offer = Offers?.FirstOrDefault(x => x.Type == "ACTIVE BEFORE");
                if (offer is not null)
                    offer.PaymentMode = value;
            }
        }

        
        public virtual decimal? OfferAFFaceAmount
        {
            get => Offers?.FirstOrDefault(x => x.Type == "APPLYING FOR")?.FaceAmount;
            set
            {
                LifeCaseOffer? offer = Offers?.FirstOrDefault(x => x.Type == "APPLYING FOR");
                if (offer is not null)
                    offer.FaceAmount = value ?? 0M;
            }
        }
        
        public virtual int? OfferAFYears
        {
            get => Offers?.FirstOrDefault(x => x.Type == "APPLYING FOR")?.Years;
            set
            {
                LifeCaseOffer? offer = Offers?.FirstOrDefault(x => x.Type == "APPLYING FOR");
                if (offer is not null)
                    offer.Years = value;
            }
        }
        
        public virtual string? OfferAFClass
        {
            get => Offers?.FirstOrDefault(x => x.Type == "APPLYING FOR")?.Class;
            set
            {
                LifeCaseOffer? offer = Offers?.FirstOrDefault(x => x.Type == "APPLYING FOR");
                if (offer is not null)
                    offer.Class = value;
            }
        }
        
        public virtual string? OfferAFRiders
        {
            get => Offers?.FirstOrDefault(x => x.Type == "APPLYING FOR")?.Riders;
            set
            {
                LifeCaseOffer? offer = Offers?.FirstOrDefault(x => x.Type == "APPLYING FOR");
                if (offer is not null)
                    offer.Riders = value;
            }
        }
        
        public virtual decimal? OfferAFPremium
        {
            get => Offers?.FirstOrDefault(x => x.Type == "APPLYING FOR")?.Premium;
            set
            {
                LifeCaseOffer? offer = Offers?.FirstOrDefault(x => x.Type == "APPLYING FOR");
                if (offer is not null)
                    offer.Premium = value;
            }
        }
        
        public virtual string? OfferAFPaymentMode
        {
            get => Offers?.FirstOrDefault(x => x.Type == "APPLYING FOR")?.PaymentMode;
            set
            {
                LifeCaseOffer? offer = Offers?.FirstOrDefault(x => x.Type == "APPLYING FOR");
                if (offer is not null)
                    offer.PaymentMode = value;
            }
        }

        
        public virtual decimal? OfferCOFaceAmount
        {
            get => Offers?.FirstOrDefault(x => x.Type == "COMPANY OFFER")?.FaceAmount;
            set
            {
                LifeCaseOffer? offer = Offers?.FirstOrDefault(x => x.Type == "COMPANY OFFER");
                if (offer is not null)
                    offer.FaceAmount = value ?? 0M;
            }
        }
        
        public virtual int? OfferCOYears
        {
            get => Offers?.FirstOrDefault(x => x.Type == "COMPANY OFFER")?.Years;
            set
            {
                LifeCaseOffer? offer = Offers?.FirstOrDefault(x => x.Type == "COMPANY OFFER");
                if (offer is not null)
                    offer.Years = value;
            }
        }
        
        public virtual string? OfferCOClass
        {
            get => Offers?.FirstOrDefault(x => x.Type == "COMPANY OFFER")?.Class;
            set
            {
                LifeCaseOffer? offer = Offers?.FirstOrDefault(x => x.Type == "COMPANY OFFER");
                if (offer is not null)
                    offer.Class = value;
            }
        }
        
        public virtual string? OfferCORiders
        {
            get => Offers?.FirstOrDefault(x => x.Type == "COMPANY OFFER")?.Riders;
            set
            {
                LifeCaseOffer? offer = Offers?.FirstOrDefault(x => x.Type == "COMPANY OFFER");
                if (offer is not null)
                    offer.Riders = value;
            }
        }
        
        public virtual decimal? OfferCOPremium
        {
            get => Offers?.FirstOrDefault(x => x.Type == "COMPANY OFFER")?.Premium;
            set
            {
                LifeCaseOffer? offer = Offers?.FirstOrDefault(x => x.Type == "COMPANY OFFER");
                if (offer is not null)
                    offer.Premium = value;
            }
        }
        
        public virtual string? OfferCOPaymentMode
        {
            get => Offers?.FirstOrDefault(x => x.Type == "COMPANY OFFER")?.PaymentMode;
            set
            {
                LifeCaseOffer? offer = Offers?.FirstOrDefault(x => x.Type == "COMPANY OFFER");
                if (offer is not null)
                    offer.PaymentMode = value;
            }
        }

        
        public virtual decimal? OfferROFaceAmount
        {
            get => Offers?.FirstOrDefault(x => x.Type == "COUNTER OFFER")?.FaceAmount;
            set
            {
                LifeCaseOffer? offer = Offers?.FirstOrDefault(x => x.Type == "COUNTER OFFER");
                if (offer is not null)
                    offer.FaceAmount = value ?? 0M;
            }
        }
        
        public virtual int? OfferROYears
        {
            get => Offers?.FirstOrDefault(x => x.Type == "COUNTER OFFER")?.Years;
            set
            {
                LifeCaseOffer? offer = Offers?.FirstOrDefault(x => x.Type == "COUNTER OFFER");
                if (offer is not null)
                    offer.Years = value;
            }
        }
        
        public virtual string? OfferROClass
        {
            get => Offers?.FirstOrDefault(x => x.Type == "COUNTER OFFER")?.Class;
            set
            {
                LifeCaseOffer? offer = Offers?.FirstOrDefault(x => x.Type == "COUNTER OFFER");
                if (offer is not null)
                    offer.Class = value;
            }
        }
        
        public virtual string? OfferRORiders
        {
            get => Offers?.FirstOrDefault(x => x.Type == "COUNTER OFFER")?.Riders;
            set
            {
                LifeCaseOffer? offer = Offers?.FirstOrDefault(x => x.Type == "COUNTER OFFER");
                if (offer is not null)
                    offer.Riders = value;
            }
        }
        
        public virtual decimal? OfferROPremium
        {
            get => Offers?.FirstOrDefault(x => x.Type == "COUNTER OFFER")?.Premium;
            set
            {
                LifeCaseOffer? offer = Offers?.FirstOrDefault(x => x.Type == "COUNTER OFFER");
                if (offer is not null)
                    offer.Premium = value;
            }
        }
        
        public virtual string? OfferROPaymentMode
        {
            get => Offers?.FirstOrDefault(x => x.Type == "COUNTER OFFER")?.PaymentMode;
            set
            {
                LifeCaseOffer? offer = Offers?.FirstOrDefault(x => x.Type == "COUNTER OFFER");
                if (offer is not null)
                    offer.PaymentMode = value;
            }
        }


        public virtual decimal? OfferACFaceAmount
        {
            get => Offers?.FirstOrDefault(x => x.Type == "ACCEPTANCE")?.FaceAmount;
            set
            {
                LifeCaseOffer? offer = Offers?.FirstOrDefault(x => x.Type == "ACCEPTANCE");
                if (offer is not null)
                    offer.FaceAmount = value ?? 0M;
            }
        }
        
        public virtual int? OfferACYears
        {
            get => Offers?.FirstOrDefault(x => x.Type == "ACCEPTANCE")?.Years;
            set
            {
                LifeCaseOffer? offer = Offers?.FirstOrDefault(x => x.Type == "ACCEPTANCE");
                if (offer is not null)
                    offer.Years = value;
            }
        }
        
        public virtual string? OfferACClass
        {
            get => Offers?.FirstOrDefault(x => x.Type == "ACCEPTANCE")?.Class;
            set
            {
                LifeCaseOffer? offer = Offers?.FirstOrDefault(x => x.Type == "ACCEPTANCE");
                if (offer is not null)
                    offer.Class = value;
            }
        }
        
        public virtual string? OfferACRiders
        {
            get => Offers?.FirstOrDefault(x => x.Type == "ACCEPTANCE")?.Riders;
            set
            {
                LifeCaseOffer? offer = Offers?.FirstOrDefault(x => x.Type == "ACCEPTANCE");
                if (offer is not null)
                    offer.Riders = value;
            }
        }
        
        public virtual decimal? OfferACPremium
        {
            get => Offers?.FirstOrDefault(x => x.Type == "ACCEPTANCE")?.Premium;
            set
            {
                LifeCaseOffer? offer = Offers?.FirstOrDefault(x => x.Type == "ACCEPTANCE");
                if (offer is not null)
                    offer.Premium = value;
            }
        }
        
        public virtual string? OfferACPaymentMode
        {
            get => Offers?.FirstOrDefault(x => x.Type == "ACCEPTANCE")?.PaymentMode;
            set
            {
                LifeCaseOffer? offer = Offers?.FirstOrDefault(x => x.Type == "ACCEPTANCE");
                if (offer is not null)
                    offer.PaymentMode = value;
            }
        }
    }
}
