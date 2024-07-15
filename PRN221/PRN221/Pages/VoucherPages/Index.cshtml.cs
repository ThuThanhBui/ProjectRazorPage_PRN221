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
    public class IndexModel : PageModel
    {
        private readonly Data.Entities.PRNDbContext _context;

        public IndexModel(Data.Entities.PRNDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public string txtSearch { get; set; }
        public IList<Voucher> Voucher { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Vouchers != null)
            {
                Voucher = await _context.Vouchers
                .Include(v => v.VoucherType).ToListAsync();
            }
        }
        public async Task<IActionResult> OnPostAsync(string txtSearch)
        {
            if (string.IsNullOrEmpty(txtSearch))
            {
                await OnGetAsync();
                return Page();
            }

            Voucher = await _context.Vouchers.Where(x => x.VoucherName.StartsWith(txtSearch)).ToListAsync();
            return Page();
        }
    }
}
