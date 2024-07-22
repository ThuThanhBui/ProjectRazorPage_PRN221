using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Interface;
using Service.Model;

namespace PRN221.Pages
{
    public class HomeModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IBlogService _blogService;

        public HomeModel(IProductService productService, IBlogService blogService)
        {
            _productService = productService;
            _blogService = blogService;
        }

        [BindProperty(SupportsGet = true)]
        public string? chosenBrand { get; set; } = null;

        public List<ProductModel> Products { get; set; }
        public List<BlogModel> Blogs { get; set; }
        public List<string> brands { get; set; }
        public async Task OnGetAsync()
        {
            brands = (await _productService.GetAllBrand()).Take(6).ToList();
            Blogs = (await _blogService.GetAllBlogs()).Take(4).ToList();
            if (chosenBrand != null)
            {
                Products = await _productService.GetByBrand(chosenBrand);
            }
            else
            {
                Products = await _productService.GetAll();
                chosenBrand = null;
            }
        }
        



    }
}
