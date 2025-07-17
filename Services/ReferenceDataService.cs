using BlazorPBM.Models;

namespace BlazorPBM.Services
{
    public class ReferenceDataService
    {
        public async Task<List<Company>> GetLifeCompany()
        {
            await Task.Delay(0);
            return new List<Company>()
            {
                new Company(){
                    CompanyId = 1, Code="CIN",  Name = "CINCINNATI"
                }
            };
        }

        public async Task<List<Company>> GetPropertyCasualtyCompany()
        {
            await Task.Delay(0);
            return new List<Company>()
            {
                new Company { CompanyId = 1, Code = "AMGUARD", Name = "AmGUARD" },
                new Company { CompanyId = 2, Code = "AMTRUST", Name = "AmTRUST" },
                new Company { CompanyId = 3, Code = "ARI", Name = "ARI" },
                new Company { CompanyId = 4, Code = "ATLANTIC", Name = "ATLANTIC" },
                new Company { CompanyId = 5, Code = "BERKLEY", Name = "BERKLEY" },
                new Company { CompanyId = 6, Code = "CHUBB", Name = "CHUBB" },
                new Company { CompanyId = 7, Code = "CITIZENS", Name = "CITIZENS" },
                new Company { CompanyId = 8, Code = "CNA", Name = "CNA" },
                new Company { CompanyId = 9, Code = "EVANSTON", Name = "EVANSTON" },
                new Company { CompanyId = 10, Code = "GENERAL", Name = "GENERAL" },
                new Company { CompanyId = 11, Code = "HARTFORD", Name = "HARTFORD" },
                new Company { CompanyId = 12, Code = "HYUNDAI", Name = "HYUNDAI" },
                new Company { CompanyId = 13, Code = "INTERGUARD", Name = "InterGUARD" },
                new Company { CompanyId = 14, Code = "LIBERTY", Name = "LIBERTY" },
                new Company { CompanyId = 15, Code = "NATIONWIDEGENERAL", Name = "NationwideGENERAL" },
                new Company { CompanyId = 16, Code = "NATIONWIDEMUTUAL", Name = "NationwideMUTUAL" },
                new Company { CompanyId = 17, Code = "OHIO", Name = "OHIO" },
                new Company { CompanyId = 18, Code = "PHILADELPHIA", Name = "PHILADELPHIA" },
                new Company { CompanyId = 19, Code = "PREFERRED", Name = "PREFERRED" },
                new Company { CompanyId = 20, Code = "PROGRESSIVE", Name = "PROGRESSIVE" },
                new Company { CompanyId = 21, Code = "RLI", Name = "RLI" },
                new Company { CompanyId = 22, Code = "SAFECO", Name = "SAFECO" },
                new Company { CompanyId = 23, Code = "SKYLANDS", Name = "SKYLANDS" },
                new Company { CompanyId = 24, Code = "STATEFARM", Name = "STATEFARM" },
                new Company { CompanyId = 25, Code = "TRAVELERS", Name = "TRAVELERS" },
                new Company { CompanyId = 26, Code = "UTICA", Name = "UTICA" },
                new Company { CompanyId = 27, Code = "WESCO", Name = "WESCO" },
                new Company { CompanyId = 28, Code = "WORLDWIDE", Name = "WORLDWIDE" }
            };
        }

        public async Task<List<string>> GetStatus()
        {
            await Task.Delay(0);
            return new List<string>()
            {
                "ACTIVE",
                "INACTIVE",
                "LAPSED"
            };
        }

        public async Task<List<string>> GetLifeCaseOfferType()
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

        public async Task<List<PropertyCasualtyType>> GetPropertyCasualtyType()
        {
            await Task.Delay(0);
            return new List<PropertyCasualtyType>
            {
                new PropertyCasualtyType { PropertyCasualtyTypeId = 1, Business = true, Code = "BD", Name = "BOND" },
                new PropertyCasualtyType { PropertyCasualtyTypeId = 2, Business = true, Code = "BOP", Name = "SMALL GL" },
                new PropertyCasualtyType { PropertyCasualtyTypeId = 3, Business = true, Code = "CA", Name = "COMMERCIAL AUTO" },
                new PropertyCasualtyType { PropertyCasualtyTypeId = 4, Business = true, Code = "CP", Name = "COMMERCIAL PROPERTY" },
                new PropertyCasualtyType { PropertyCasualtyTypeId = 5, Business = true, Code = "CPK", Name = "COMMERCIAL PACKAGE" },
                new PropertyCasualtyType { PropertyCasualtyTypeId = 6, Business = true, Code = "GKL", Name = "GARAGE KEEPERS" },
                new PropertyCasualtyType { PropertyCasualtyTypeId = 7, Business = true, Code = "GL", Name = "GENERAL LIABILITY" },
                new PropertyCasualtyType { PropertyCasualtyTypeId = 8, Business = true, Code = "UM", Name = "UMBRELLA" },
                new PropertyCasualtyType { PropertyCasualtyTypeId = 9, Business = true, Code = "WC", Name = "WORKERS COMPENSATION" },
                new PropertyCasualtyType { PropertyCasualtyTypeId = 10, Business = true, Code = "IM", Name = "INLAND MARINE" },
                new PropertyCasualtyType { PropertyCasualtyTypeId = 11, Business = false, Code = "AU", Name = "AUTO" },
                new PropertyCasualtyType { PropertyCasualtyTypeId = 12, Business = false, Code = "FL", Name = "FLOODS" },
                new PropertyCasualtyType { PropertyCasualtyTypeId = 13, Business = false, Code = "GL", Name = "GENERAL LIABILITY" },
                new PropertyCasualtyType { PropertyCasualtyTypeId = 14, Business = false, Code = "HO", Name = "HOME OWNERS" },
                new PropertyCasualtyType { PropertyCasualtyTypeId = 15, Business = false, Code = "UM", Name = "UMBRELLA" }
            };
        }

        public async Task<List<string>> GetPropertyCasualtyBroker()
        {
            await Task.Delay(0);
            return new List<string>()
            {
                "PBM",
                "SMART CHOICE",
                "MORSTAN",
                "RPS"
            };
        }
    }
}
