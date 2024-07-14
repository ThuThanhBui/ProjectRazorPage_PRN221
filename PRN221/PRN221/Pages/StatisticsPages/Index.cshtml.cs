using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository.Repository;
using Service.Interface;
using System.Collections.Generic;
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

        public IList<ProductRevenueViewModel> ProductRevenues { get; set; }

        public async Task OnGetAsync()
        {
            ProductRevenues = await _statisticsService.GetProductStatisticsAsync();
        }
    }
}
