using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Data.Entities;
using Service.Interface;
using Service.Model;

namespace PRN221.Pages.ProductManagement
{
    public class CreateModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IProductTypeService _productTypeService;

        public CreateModel(IProductTypeService productTypeService, IProductService productService)
        {
            _productTypeService = productTypeService;
            _productService = productService;
        }

        public List<ProductTypeModel> ProductTypes { get; set; } = default!;

        [BindProperty]
        public ProductModel Product { get; set; } = default!;

        public async Task OnGetAsync()
        {
            ProductTypes = await _productTypeService.GetAll();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    OnGetAsync();
            //    return Page();
            //}

            Product.isDeleted = false;
            Product.createdDate = DateTime.Now;
            Product.updatedDate = DateTime.Now;

            var addSuccess = await _productService.Add(Product);
            if (addSuccess)
            {
                OnGetAsync();
                return RedirectToPage("/ProductManagement/Index");
            }
            else
            {
                OnGetAsync();
                return Page();
            }
        }
    }
}
