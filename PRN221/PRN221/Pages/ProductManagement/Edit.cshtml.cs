using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data.Entities;
using Service.Interface;
using Service.Model;

namespace PRN221.Pages.ProductManagement
{
    public class EditModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IProductTypeService _productTypeService;

        public EditModel(IProductTypeService productTypeService, IProductService productService)
        {
            _productTypeService = productTypeService;
            _productService = productService;
        }

        public List<ProductTypeModel> ProductTypes { get; set; } = default!;

        [BindProperty]
        public ProductModel Product { get; set; } = default!;

        public async Task OnGetAsync(Guid id)
        {
            Product = await _productService.GetById(id);
            ProductTypes = await _productTypeService.GetAll();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            Product.updatedDate = DateTime.Now;

            var addSuccess = await _productService.Update(Product);
            if (addSuccess)
            {
                return RedirectToPage("/ProductManagement/Index");
            }
            else
            {
                await OnGetAsync(Product.id);
                return Page();
            }
        }

    }
}
