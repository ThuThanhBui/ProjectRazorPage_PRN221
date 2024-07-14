using System.Collections.Generic;
using System.Threading.Tasks;
using Repository.Repository;

namespace Service.Interface
{
    public interface IStatisticsService
    {
        Task<IList<ProductRevenueViewModel>> GetProductStatisticsAsync();
    }
}
