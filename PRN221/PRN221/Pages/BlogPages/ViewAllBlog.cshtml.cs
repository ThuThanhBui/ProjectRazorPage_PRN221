using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Service.Interface;
using Service.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PRN221.Pages.BlogPages
{
    public class ViewAllBlogModel : PageModel
    {
        private readonly IBlogService _service;
        private readonly PRNDbContext _context;

        public ViewAllBlogModel(IBlogService service, Data.Entities.PRNDbContext context)
        {
            _service = service;
            _context = context;
        }

        public IList<BlogModel> Blog { get; set; } = new List<BlogModel>();
        [BindProperty]
        public string txtSearch { get; set; }
        public async Task OnGetAsync()
        {
            Blog = await _service.GetAllBlogs();
        }

        public async Task<IActionResult> OnPostAsync(string txtSearch)
        {
            if (string.IsNullOrEmpty(txtSearch))
            {
                await OnGetAsync();
                return Page();
            }

            Blog = await _service.Search(txtSearch);
            return Page();
        }
    }
}
