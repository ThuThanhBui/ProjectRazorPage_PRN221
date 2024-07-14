using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data.Entities;
using Service.Interface;
using Service.Model;

namespace PRN221.Pages.VoucherPages
{
    public class EditModel : PageModel
    {
    
        private readonly IVoucherService _service;

        public EditModel( IVoucherService service)
        {
   
            _service = service;
        }
        public List<VoucherTypeModel> VoucherTypes { get; set; } = new List<VoucherTypeModel>();
        [BindProperty]
        public VoucherModel Voucher { get; set; } = default!;

        public async Task OnGetAsync(Guid id)
        {
            var voucher =  await _service.GetById(id);
            Voucher = voucher;
            VoucherTypes = await _service.GetAllVoucherType();
            if(VoucherTypes == null || VoucherTypes.Count == 0) { Console.WriteLine("No voucher types"); }
          
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Voucher.updatedDate = DateTime.Now;

          var v = await _service.Update(Voucher);
            if (v)
            {
                return RedirectToPage("./Index");
            }
            return Page();
            
            }

         
        }

     
    
}
