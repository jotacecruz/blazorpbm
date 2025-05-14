using BlazorPBM.Models;

namespace BlazorPBM.Services
{
    public class InsuredService
    {
        private readonly DatabaseService<Insured> _databaseService;

        public InsuredService(DatabaseService<Insured> databaseService)
        {
            _databaseService = databaseService;
        }

        private List<Insured>? insuredList;
        public async Task<List<Insured>> GetAllInsured()
        {
            if (insuredList is null)
                insuredList = await _databaseService.LoadFromSheet("insured");
            return insuredList;
        }
    }
}
