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
    public class DeleteModel : PageModel
    {
        private readonly Data.Entities.PRNDbContext _context;
        private readonly IVoucherService _service;

        public DeleteModel(Data.Entities.PRNDbContext context, IVoucherService service)
        {
            _context = context;
            _service = service;
        }

        [BindProperty]
        public VoucherModel Voucher { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            if (id == Guid.Empty || _context.Vouchers == null)
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

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            if (id == Guid.Empty || _context.Vouchers == null)
            {
                return NotFound();
            }
            var voucher = await _service.DeleteById(id);

            if (voucher)
            {
            
                return RedirectToPage("./Index");

            }
            ModelState.AddModelError("", "Error while delete voucher");
            return Page();
         
        }
    }
}
