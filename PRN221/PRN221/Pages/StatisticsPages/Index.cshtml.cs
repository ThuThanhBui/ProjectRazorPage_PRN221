using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Interface;
using System.Threading.Tasks;

namespace PRN221.Pages.StatisticsPages
{
    public class IndexModel : PageModel
    {
        private readonly IStatisticsService _statisticsService;

        public IndexModel(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        public int TotalProducts { get; set; }
        public decimal TotalRevenue { get; set; }

        public async Task OnGetAsync()
        {
            TotalProducts = await _statisticsService.GetTotalProducts();
            TotalRevenue = await _statisticsService.GetTotalRevenue();
        }
    }
}