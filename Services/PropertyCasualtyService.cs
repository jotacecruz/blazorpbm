using BlazorPBM.Models;

namespace BlazorPBM.Services
{
    public class PropertyCasualtyService
    {
        private readonly DatabaseService<PropertyCasualty> _databaseService;
        private readonly UserService _userService;
        private readonly InsuredService _insuredService;

        public PropertyCasualtyService(DatabaseService<PropertyCasualty> databaseService, UserService userService, InsuredService insuredService)
        {
            _databaseService = databaseService;
            _userService = userService;
            _insuredService = insuredService;
        }

        public async Task<List<PropertyCasualty>> GetAllPropertyCasualty()
        {
            List<PropertyCasualty> result = await _databaseService.LoadFromSheet("propertycasualty");
            foreach (PropertyCasualty propertyCasualty in result)
            {
                propertyCasualty.Owner = await _userService.GetUser(propertyCasualty.OwnerId);
                propertyCasualty.Insured = (await _insuredService.GetAllInsured()).First(x => x.InsuredId == propertyCasualty.InsuredId);
            }
            return result;
        }

        public async Task SavePropertyCasualty(PropertyCasualty propertyCasualty)
        {
            if (propertyCasualty.PropertyCasualtyId == 0)
            {
                propertyCasualty.PropertyCasualtyId = (await _databaseService.LoadFromSheet("propertycasualty")).Count + 1;
                propertyCasualty.DatabaseRow = propertyCasualty.PropertyCasualtyId + 1;
                await _databaseService.SaveToSheet("propertycasualty", propertyCasualty, true);
            }
            else
                await _databaseService.SaveToSheet("propertycasualty", propertyCasualty);
        }
    }
}
