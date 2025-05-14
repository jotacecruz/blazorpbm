using BlazorPBM.Models;

namespace BlazorPBM.Services
{
    public class LifeCaseService
    {
        private readonly DatabaseService<LifeCase> _databaseService;
        private readonly UserService _userService;
        private readonly InsuredService _insuredService;

        public LifeCaseService(DatabaseService<LifeCase> databaseService, UserService userService, InsuredService insuredService)
        {
            _databaseService = databaseService;
            _userService = userService;
            _insuredService = insuredService;
        }

        public async Task<List<LifeCase>> GetAllLifeCase()
        {
            List<LifeCase> result = await _databaseService.LoadFromSheet("lifecase");
            foreach (LifeCase lifeCase in result)
            {
                lifeCase.Owner = await _userService.GetUser(lifeCase.OwnerId);
                lifeCase.Offers = new List<LifeCaseOffer>();
                lifeCase.Relative = new Insured();
                lifeCase.Insured = (await _insuredService.GetAllInsured()).First(x => x.InsuredId == lifeCase.InsuredId);
            }
            return result;
        }

        public async Task SaveLifeCase(LifeCase lifeCase)
        {
            await _databaseService.SaveToSheet("lifecase", lifeCase);
        }
    }

    public class LifeCaseOfferService
    {
        private readonly DatabaseService<LifeCaseOffer> _databaseService;

        public LifeCaseOfferService(DatabaseService<LifeCaseOffer> databaseService)
        {
            _databaseService = databaseService;
        }

        public async Task<List<LifeCaseOffer>> GetAllLifeCaseOffer(int lifeCaseId)
        {
            return (await _databaseService.LoadFromSheet("lifecaseoffer")).Where(x => x.LifeCaseId == lifeCaseId).ToList();
        }

        public async Task SaveLifeCaseOffer(LifeCaseOffer lifeCaseOffer)
        {
            await _databaseService.SaveToSheet("lifecaseoffer", lifeCaseOffer);
        }
    }

    public class LifeCaseRemarkService
    {
        private readonly DatabaseService<LifeCaseRemark> _databaseService;
        private readonly UserService _userService;

        public LifeCaseRemarkService(DatabaseService<LifeCaseRemark> databaseService, UserService userService)
        {
            _databaseService = databaseService;
            _userService = userService;
        }

        public async Task<List<LifeCaseRemark>> GetAllLifeCaseRemark(int lifeCaseId)
        {
            List<LifeCaseRemark> result = (await _databaseService.LoadFromSheet("lifecaseremark")).Where(x => x.LifeCaseId == lifeCaseId).ToList();
            foreach (LifeCaseRemark lifeCaseRemark in result)
            {
                lifeCaseRemark.Modifier = await _userService.GetUser(lifeCaseRemark.ModifiedId);
            }
            return result;
        }

        public async Task SaveLifeCaseRemark(LifeCaseRemark lifeCaseRemark)
        {
            
            if (lifeCaseRemark.LifeCaseRemarkId == 0)
            {
                lifeCaseRemark.LifeCaseRemarkId = (await _databaseService.LoadFromSheet("lifecaseremark")).Count + 1;
                lifeCaseRemark.DatabaseRow = lifeCaseRemark.LifeCaseRemarkId + 1;
                await _databaseService.SaveToSheet("lifecaseremark", lifeCaseRemark, true);
            }else
                await _databaseService.SaveToSheet("lifecaseremark", lifeCaseRemark);
        }
    }
}
