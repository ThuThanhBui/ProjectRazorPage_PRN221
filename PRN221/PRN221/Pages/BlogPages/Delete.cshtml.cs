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

namespace PRN221.Pages.BlogPages
{
    public class DeleteModel : PageModel
    {
        private readonly IBlogService _service;

        public DeleteModel(IBlogService service)
        {
            _service = service;
        }

        [BindProperty]
      public BlogModel Blog { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _service.GetBlogById(id);

            if (blog == null)
            {
                return NotFound();
            }
            else 
            {
                Blog = blog;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            if (id == Guid.Empty)  // Check for empty Guid instead of null
            {
                return NotFound();
            }

            var blog = await _service.GetBlogById(id);
            if (blog == null)
            {
                return NotFound();
            }

            bool result = await _service.DeleteBlog(id);
            if (!result)
            {
                ModelState.AddModelError("", "Error while delete blog");
                return Page();
            }

            return RedirectToPage("./Index");

        }
    }
}
