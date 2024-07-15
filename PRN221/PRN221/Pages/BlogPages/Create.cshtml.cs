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
using PRN221.Pages.UserManagementPages;
using Microsoft.EntityFrameworkCore;


namespace PRN221.Pages.BlogPages
{
    public class CreateModel : PageModel
    {

        private readonly IBlogService _service;
        private readonly PRNDbContext _context;
        private readonly IUserService _user;

        public CreateModel(IBlogService service, PRNDbContext context)
        {
            _service = service;
            _context = context;
        }

        [BindProperty]
        public BlogModel Blog { get; set; } = default!;

        [BindProperty]
        public IFormFile img { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {

            string imageBase64 = null;
            if (img != null && img.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await img.CopyToAsync(memoryStream);
                        byte[] imageBytes = memoryStream.ToArray();
                        imageBase64 = Convert.ToBase64String(imageBytes);
                    }
                }
            }

            Blog.Image = imageBase64;
            User u = await _context.Users.Where(t => t.Email == Session.email).FirstOrDefaultAsync();
            Blog.UserId = u.Id;
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
