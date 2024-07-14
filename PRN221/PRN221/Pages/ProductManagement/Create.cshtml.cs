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
        public List<string> Brands { get; set; } = default!;

        [BindProperty]
        public ProductModel Product { get; set; } = default!;

        [BindProperty]
        public IFormFile img { get; set; }
        public async Task OnGetAsync()
        {
            ProductTypes = await _productTypeService.GetAll();
            Brands = await _productService.GetAllBrand();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    OnGetAsync();
            //    return Page();
            //}
            // Xử lý chuyển đổi ảnh sang base64 trong Razor Page Model
            string imageBase64 = null;
            if (img != null && img.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await img.CopyToAsync(memoryStream);
                        byte[] imageBytes = memoryStream.ToArray();
                        imageBase64 = Convert.ToBase64String(imageBytes);
                    }
                }
            }

            Product.Image = imageBase64;
            Product.IsDeleted = false;
            Product.CreatedDate = DateTime.Now;
            Product.LastUpdatedDate = DateTime.Now;

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
