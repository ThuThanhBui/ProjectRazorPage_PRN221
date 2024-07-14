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

namespace PRN221.Pages.OrderPages
{
    public class CreateModel : PageModel
    {
        
        
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (!ModelState.IsValid || _context.Orders == null || Order == null)
        //    {
        //        return Page();
        //    }

        //    _context.Orders.Add(Order);
        //    await _context.SaveChangesAsync();

        //    return RedirectToPage("./Index");
        //}
    }
}
