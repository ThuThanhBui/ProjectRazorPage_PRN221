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
using System.Runtime.InteropServices;
using PRN221.Service.Model;


namespace PRN221.Pages.BlogPages
{
    public class CreateModel : PageModel
    {

        private readonly IBlogService _service;

        public CreateModel(IBlogService service)
        {
            _service = service;
        }

        [BindProperty]
        public BlogModel Blog { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || Blog == null)
            {
                return Page();
            }
            //     HttpContent.Session.GetString("userId");
          
                Blog.userId = Session.userid;
                Blog.createdDate = DateTime.Now;
                Blog.updatedDate = DateTime.Now;
                Blog.isDeleted = false;
            var add =await _service.AddBlog(Blog);
            if (add)
            {
                TempData["Message"] = "Added Successfully.";
                return RedirectToPage("./Index");
            }
            ModelState.AddModelError("", "Error while adding blog");
            return Page();

        }
    }
}
