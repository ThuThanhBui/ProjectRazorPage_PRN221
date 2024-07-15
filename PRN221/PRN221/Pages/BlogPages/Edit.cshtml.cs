using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data.Entities;
using Service.Model;
using Service.Interface;

namespace PRN221.Pages.BlogPages
{
    public class EditModel : PageModel
    {
        private readonly Data.Entities.PRNDbContext _context;
        private readonly IBlogService _service;

        public EditModel(Data.Entities.PRNDbContext context , IBlogService service)
        {
            _context = context;
            _service = service;
        }

        [BindProperty]
        public BlogModel Blog { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            if (id == Guid.Empty || _context.Blogs == null)
            {
                return NotFound();
            }

            var blog = await _service.GetBlogById(id);
            if (blog == null)
            {
                return NotFound();
            }
            Blog = blog;
          //  ViewData["userId"] = new SelectList(_context.Users, "id", "address");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

           if(Blog != null)
            {
                Blog.LastUpdatedDate = DateTime.UtcNow;
             var up =   await _service.UpdateBlog(Blog);
                if (up)
                {
                    TempData["Message"] = "Added Successfully.";
                    return RedirectToPage("./Index");
                }
            }

            ModelState.AddModelError("", "Error while adding blog");
            return Page();
        }

        //private bool BlogExists(Guid id)
        //{
        //  return (_context.Blogs?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
