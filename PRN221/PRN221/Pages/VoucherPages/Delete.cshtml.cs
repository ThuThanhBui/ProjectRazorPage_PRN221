using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Data.Entities;

namespace PRN221.Pages.VoucherPages
{
    public class DeleteModel : PageModel
    {
        private readonly Data.Entities.PRNDbContext _context;

        public DeleteModel(Data.Entities.PRNDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Voucher Voucher { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Vouchers == null)
            {
                return NotFound();
            }

            var voucher = await _context.Vouchers.FirstOrDefaultAsync(m => m.id == id);

            if (voucher == null)
            {
                return NotFound();
            }
            else 
            {
                Voucher = voucher;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || _context.Vouchers == null)
            {
                return NotFound();
            }
            var voucher = await _context.Vouchers.FindAsync(id);

            if (voucher != null)
            {
                Voucher = voucher;
                _context.Vouchers.Remove(Voucher);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
