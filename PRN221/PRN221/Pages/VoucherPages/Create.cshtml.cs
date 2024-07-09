using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Data.Entities;
using Service.Interface;
using Service.Model;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;

namespace PRN221.Pages.VoucherPages
{
    public class CreateModel : PageModel
    {
        private readonly Data.Entities.PRNDbContext _context;
        private readonly IVoucherService _service;

        public CreateModel(Data.Entities.PRNDbContext context, IVoucherService service)
        {
            _context = context;
            _service = service;
        }
        public List<VoucherType> VoucherTypes { get; set; } = default;
        public async Task OnGetAsync()
        {
            VoucherTypes = await _context.VoucherTypes.ToListAsync();   
       
        }

        [BindProperty]
        public VoucherModel Voucher { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || Voucher == null)
            {
                return Page();
            }
         
        var v =  await _service.Add(Voucher);
            if (v)
            {
                TempData["Message"] = "Added Successfully.";
                return RedirectToPage("./Index");
            }
            ModelState.AddModelError("", "Error while adding voucher");
            return Page();

        }
    }
}
