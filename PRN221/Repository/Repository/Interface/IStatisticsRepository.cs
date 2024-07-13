using System.Collections.Generic;
using System.Threading.Tasks;
using Repository.Repository;

namespace Repository.Repository.Interface
{
    public interface IStatisticsRepository
    {
        Task<IList<ProductRevenueViewModel>> GetProductStatisticsAsync();
    }
}
