using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Interface;
using Service.Model;

namespace PRN221.Pages.ProfilePages
{
    public class IndexModel : PageModel
    {
        private readonly IUserService _userService;

        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public UserModel User { get; set; }

        [BindProperty]
        public IFormFile img {  get; set; }

        public async Task OnGetAsync()
        {
            User = await _userService.GetById(Guid.Parse(HttpContext.Session.GetString("userId")));
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Xử lý chuyển đổi ảnh sang base64 trong Razor Page Model
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

            User.Image = imageBase64;
            User.LastUpdatedDate = DateTime.Now;

            var updateSuccess = await _userService.UpdateProfile(User);
            if (updateSuccess)
            {
                TempData["Message"] = "Edit successful.";
                await OnGetAsync();
                return Page();
            }
            else
            {
                await OnGetAsync();
                return Page();
            }
        }
    }
}
