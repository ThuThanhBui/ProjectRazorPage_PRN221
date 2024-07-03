using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Data.Entities;

namespace PRN221.Pages.OrderPages
{
    public class CreateModel : PageModel
    {
        private readonly Data.Entities.PRNDbContext _context;

        public CreateModel(Data.Entities.PRNDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["userId"] = new SelectList(_context.Users, "id", "address");
        ViewData["voucherId"] = new SelectList(_context.Vouchers, "id", "content");
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Orders == null || Order == null)
            {
                return Page();
            }

            _context.Orders.Add(Order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
