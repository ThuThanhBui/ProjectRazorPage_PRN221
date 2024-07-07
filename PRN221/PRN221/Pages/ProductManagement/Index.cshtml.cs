using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Data.Entities;
using Service.Interface;
using Microsoft.IdentityModel.Tokens;
using Service;
using static NuGet.Packaging.PackagingConstants;
using Service.Model;

namespace PRN221.Pages.ProductManagement
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

        public List<ProductModel> Products { get;set; } = default!;
        public List<ProductTypeModel> ProductTypes { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string typeFilter { get; set; }

        public async Task OnGetAsync()
        {
            ProductTypes = await _productTypeService.GetAll();
            if (!typeFilter.IsNullOrEmpty())
            {
                Products = await _productService.GetByTypeId(Guid.Parse(typeFilter));
            }
            else
            {
                Products = await _productService.GetAll();
            }

        }
    }
}
