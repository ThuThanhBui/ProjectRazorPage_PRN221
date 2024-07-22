using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace PRN221.Pages.Shop
{
    public class ViewProductDetailModel : PageModel
    {
        private readonly PRNDbContext _context;

        public ViewProductDetailModel(PRNDbContext context)
        {
            _context = context;
        }

        public Product Products { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.Include(x=> x.ProductType).FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                Products = product;
            }
            return Page();
        }
    }
}
