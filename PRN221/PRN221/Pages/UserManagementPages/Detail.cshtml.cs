using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Interface;
using Service.Model;
using System;
using System.Threading.Tasks;

namespace PRN221.Pages.UserManagement
{
    public class DetailModel : PageModel
    {
        private readonly IUserService _userService;

        public DetailModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public UserModel User { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            User = await _userService.GetById(id);
            if (User == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}