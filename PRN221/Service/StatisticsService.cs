using System.Threading.Tasks;
using Service.Interface;
using Repository.Repository.Interface;

namespace Service
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public StatisticsService(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        public async Task<int> GetTotalProducts()
        {
            return await _statisticsRepository.GetTotalProducts();
        }

        public async Task<decimal> GetTotalRevenue()
        {
            return await _statisticsRepository.GetTotalRevenue();
        }
    }
}