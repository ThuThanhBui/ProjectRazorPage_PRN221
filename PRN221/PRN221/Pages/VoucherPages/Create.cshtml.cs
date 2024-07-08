using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Data.Entities;

namespace PRN221.Pages.VoucherPages
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
        ViewData["voucherTypeId"] = new SelectList(_context.VoucherTypes, "id", "typeName");
            return Page();
        }

        [BindProperty]
        public Voucher Voucher { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Vouchers == null || Voucher == null)
            {
                return Page();
            }

            _context.Vouchers.Add(Voucher);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
