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

        public async Task<IList<ProductRevenueViewModel>> GetProductStatisticsAsync()
        {
            return await _context.Products
                .Include(p => p.OrderXProducts)
                .ThenInclude(op => op.Order)
                .Where(p => !p.isDeleted)
                .Select(p => new ProductRevenueViewModel
                {
                    ProductName = p.name,
                    TotalRevenue = p.OrderXProducts.Sum(op => op.Order.totalPrice),
                    StockQuantity = p.stockQuantity
                })
                .ToListAsync();
        }
    }

    public class ProductRevenueViewModel
    {
        public string ProductName { get; set; }
        public decimal TotalRevenue { get; set; }
        public int StockQuantity { get; set; }
    }
}
