using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Interface;
using Service.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PRN221.Pages.BlogPages
{
    public class ViewAllBlogModel : PageModel
    {
        private readonly IBlogService _service;

        public ViewAllBlogModel(IBlogService service)
        {
            _service = service;
        }

        public IList<BlogModel> Blog { get; set; } = new List<BlogModel>();

        public async Task OnGetAsync()
        {
            Blog = await _service.GetAllBlogs();
        }
    }
}
