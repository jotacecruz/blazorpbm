using BlazorPBM.Models;

namespace BlazorPBM.Services
{
    public class ReferenceDataService
    {
        public async Task<List<Company>> GetAllCompany()
        {
            await Task.Delay(0);
            return new List<Company>()
            {
                new Company(){ CompanyId = 1, Code="CIN",  Name = "CINCINNATI" }
            };
        }

        public async Task<List<string>> GetAllStatus()
        {
            await Task.Delay(0);
            return new List<string>()
            {
                "ACTIVE",
                "INACTIVE",
                "LAPSED"
            };
        }

        public async Task<List<string>> GetAllOfferType()
        {
            await Task.Delay(0);
            return new List<string>()
            {
                "ACTIVE BEFORE",
                "APPLYING FOR",
                "COMPANY OFFER",
                "COUNTER OFFER",
                "ACCEPTANCE"
            };
        }
    }
}
