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
        public int countfeedback { get; set; }
        public List<ProductFeedback> Feedbacks { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public async Task<IActionResult> OnGetAsync(Guid? id, int pagenumber = 1)
        {
            CurrentPage = pagenumber;
            int pagesize = 2;
            countfeedback = _context.ProductFeedbacks.Where(x=> x.ProductId == id).Count();
            Feedbacks = _context.ProductFeedbacks.Include(x=> x.User).Where(x=> x.ProductId == id).ToList();
            if (Feedbacks == null)
            {
                TotalPages = 1;
            }
            else
            {
                TotalPages = (int)Math.Ceiling(Feedbacks.Count() / (double)pagesize);
                Feedbacks = Feedbacks.Skip((CurrentPage - 1) * pagesize).Take(pagesize).ToList();
            }
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
