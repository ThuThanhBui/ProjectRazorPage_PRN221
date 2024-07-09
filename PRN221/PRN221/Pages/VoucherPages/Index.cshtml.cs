﻿using System;
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

        public IList<Voucher> Voucher { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Vouchers != null)
            {
                Voucher = await _context.Vouchers
                .Include(v => v.voucherType).ToListAsync();
            }
        }
    }
}
