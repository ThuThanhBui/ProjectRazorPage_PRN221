using System.Collections.Generic;
using System.Threading.Tasks;
using Service.Interface;
using Repository.Repository.Interface;
using Repository.Repository;

namespace Service
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public StatisticsService(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        public Task<IList<ProductRevenueViewModel>> GetProductStatisticsAsync()
        {
            return _statisticsRepository.GetProductStatisticsAsync();
        }
    }
}
