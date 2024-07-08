using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Data.Entities;
using Service.Model;
using Service.Interface;

namespace PRN221.Pages.VoucherPages
{
    public class DetailsModel : PageModel
    {
        private readonly Data.Entities.PRNDbContext _context;
        private readonly IVoucherService _service;

        public DetailsModel(Data.Entities.PRNDbContext context, IVoucherService service)
        {
            _context = context;
            _service = service;
        }

      public VoucherModel Voucher { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            var voucher = await _service.GetById(id);
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
    }
}
