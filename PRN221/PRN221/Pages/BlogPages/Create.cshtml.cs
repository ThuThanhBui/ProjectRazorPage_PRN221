using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221.Service.Model;
using Service.Interface;
using Service.Model;

namespace PRN221.Pages.BlogPages
{
    public class CreateModel : PageModel
    {
        private readonly IBlogService _service;
        private readonly PRNDbContext _context;

        public CreateModel(IBlogService service, PRNDbContext context)
        {
            _service = service;
            _context = context;
        }

        [BindProperty]
        public BlogModel Blog { get; set; } = default!;

        [BindProperty]
        public IFormFile Img { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            string imageBase64 = null;
            if (Img != null && Img.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await Img.CopyToAsync(memoryStream);
                    byte[] imageBytes = memoryStream.ToArray();
                    imageBase64 = Convert.ToBase64String(imageBytes);
                }
            }

            Blog.Image = imageBase64;

            var user = await _context.Users.Where(t => t.Email == Session.email).FirstOrDefaultAsync();
            if (user == null)
            {
                ModelState.AddModelError("", "User not found.");
                return Page();
            }

            Blog.UserId = user.Id;
            Blog.CreatedDate = DateTime.Now;
            Blog.LastUpdatedDate = DateTime.Now;
            Blog.IsDeleted = false;

            var add = await _service.AddBlog(Blog);
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
