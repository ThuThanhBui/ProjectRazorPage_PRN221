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

        public PaginatedList<ProductModel> Products { get;set; } = default!;
        public List<ProductTypeModel> ProductTypes { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string typeFilter { get; set; }

        [BindProperty(SupportsGet = true)]
        public string keyword {  get; set; }

        public async Task OnGetAsync(int? pageIndex)
        {
            ProductTypes = await _productTypeService.GetAll();
            var list = new List<ProductModel>();
            if (!typeFilter.IsNullOrEmpty())
            {
                list = await _productService.GetByTypeId(Guid.Parse(typeFilter));
                Products = PaginatedList<ProductModel>.Create(list, pageIndex ?? 1, 5);
            }
            else if(!keyword.IsNullOrEmpty())
            {
                list = await _productService.Search(keyword);
                Products = PaginatedList<ProductModel>.Create(list, pageIndex ?? 1, 5);
            }
            else
            {
                list = await _productService.GetAll();
                Products = PaginatedList<ProductModel>.Create(list, pageIndex ?? 1, 5);
            }
        }

        //public async Task<IActionResult> OnPostAsync()
        //{
        //}
    }
}
