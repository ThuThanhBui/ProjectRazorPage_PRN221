using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Interface;
using Service.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRN221.Pages.StatisticsPages
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;

        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }

        public List<ProductModel> TopProductsByStock { get; set; } = new List<ProductModel>();
        public List<ProductModel> BottomProductsByStock { get; set; } = new List<ProductModel>();
        public List<ProductModel> TopProductsByHighestPrice { get; set; } = new List<ProductModel>();
        public List<ProductModel> TopProductsByLowestPrice { get; set; } = new List<ProductModel>();
        public List<ProductModel> TopProductsByHighestRating { get; set; } = new List<ProductModel>();
        public List<ProductModel> TopProductsByLowestRating { get; set; } = new List<ProductModel>();

        public async Task OnGetAsync()
        {
            // Fetch all products
            var allProducts = await _productService.GetAll();

            // Top 5 products by stock quantity
            TopProductsByStock = allProducts
                .OrderByDescending(p => p.StockQuantity)
                .Take(5)
                .ToList();

            // Bottom 5 products by stock quantity
            BottomProductsByStock = allProducts
                .OrderBy(p => p.StockQuantity)
                .Take(5)
                .ToList();

            // Top 5 products with highest prices
            TopProductsByHighestPrice = allProducts
                .OrderByDescending(p => p.Price)
                .Take(5)
                .ToList();

            // Top 5 products with lowest prices
            TopProductsByLowestPrice = allProducts
                .OrderBy(p => p.Price)
                .Take(5)
                .ToList();

            // Top 5 products with highest ratings
            TopProductsByHighestRating = allProducts
                .OrderByDescending(p => p.AverageRating)
                .Take(5)
                .ToList();

            // Top 5 products with lowest ratings
            TopProductsByLowestRating = allProducts
                .OrderBy(p => p.AverageRating)
                .Take(5)
                .ToList();
        }
    }
}