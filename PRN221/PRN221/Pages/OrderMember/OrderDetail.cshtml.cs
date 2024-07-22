using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace PRN221.Pages.OrderMember
{
    public class OrderDetailModel : PageModel
    {
        private readonly Data.Entities.PRNDbContext _context;

        public OrderDetailModel(Data.Entities.PRNDbContext context)
        {
            _context = context;
        }
        public List<OrderXProduct> Products { get; set; }
        public void OnGet(Guid ? id)
        {
            Products = _context.OrderXProducts.Include(x => x.Product).Where(x => x.OrderId == id).ToList();
        }
    }
}
