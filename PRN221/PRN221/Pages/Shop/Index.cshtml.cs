using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using Service.Interface;
using Service.Model;

namespace PRN221.Pages.Shop
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IProductTypeService _productTypeService;

        public IndexModel(IProductService productService, IProductTypeService productTypeService)
        {
            _productService = productService;
            _productTypeService = productTypeService;
        }

        public List<ProductModel> Products { get; set; } = default!;
        public List<ProductTypeModel> ProductTypes { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string keyword { get; set; }


        public async Task OnGetAsync(Guid? id)
        {
            ProductTypes = await _productTypeService.GetAll();
            if (id == null)
            {
                Products = await _productService.GetAll();
            }
            else
            {
                Products = await _productService.GetByTypeId((Guid)id);
            }
        }
    }
}
