using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Data.Entities;

namespace PRN221.Pages.BlogPages
{
    public class IndexModel : PageModel
    {
        private readonly Data.Entities.PRNDbContext _context;

        public IndexModel(Data.Entities.PRNDbContext context)
        {
            _context = context;
        }

        public IList<Blog> Blog { get; set; } = default!;
        [BindProperty]
        public string txtSearch { get; set; }
        public async Task OnGetAsync()
        {
            if (_context.Blogs != null)
            {
                Blog = await _context.Blogs
                .Include(b => b.User).ToListAsync();
            }
        }
        public async Task<IActionResult> OnPostAsync(string txtSearch)
        {
            if (string.IsNullOrEmpty(txtSearch))
            {
                await OnGetAsync();
                return Page();
            }

            Blog = _context.Blogs.Where(x => x.title.StartsWith(txtSearch)).ToList();
            return Page();


        }
    }
}
