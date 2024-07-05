using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Data.Entities;

namespace PRN221.Pages.BlogPages
{
    public class CreateModel : PageModel
    {
        private readonly Data.Entities.PRNDbContext _context;

        public CreateModel(Data.Entities.PRNDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["userId"] = new SelectList(_context.Users, "id", "address");
            return Page();
        }

        [BindProperty]
        public Blog Blog { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Blogs == null || Blog == null)
            {
                return Page();
            }

            _context.Blogs.Add(Blog);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
