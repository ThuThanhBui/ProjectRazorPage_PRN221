using System.Linq;
using System.Threading.Tasks;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Repository.Interface;

namespace Repository.Repository
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly PRNDbContext _context;

        public StatisticsRepository(PRNDbContext context)
        {
            _context = context;
        }

        public async Task<int> GetTotalProducts()
        {
            return await _context.Products.CountAsync();
        }

        public async Task<decimal> GetTotalRevenue()
        {
            return await _context.Orders.SumAsync(order => order.totalPrice);
        }
    }
}