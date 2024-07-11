using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Interface;
using Service.Model;
using System;
using System.Threading.Tasks;

namespace PRN221.Pages.UserManagement
{
    public class EditModel : PageModel
    {
        private readonly IUserService _userService;

        [BindProperty]
        public UserModel User { get; set; }

        public EditModel(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }

            User = await _userService.GetUserById(id);

            if (User == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var isUpdated = await _userService.Update(User);

                if (!isUpdated)
                {
                    ModelState.AddModelError(string.Empty, "Unable to update user.");
                    return Page();
                }

                return RedirectToPage("./Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error: {ex.Message}");
                return Page();
            }
        }
    }
}
