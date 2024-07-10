using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Interface;
using Service.Model;
using System.Threading.Tasks;

namespace PRN221.Pages.UserManagement
{
    public class EditModel : PageModel
    {
        private readonly IUserService _userService;

        public EditModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public UserModel User { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
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

            await _userService.UpdateUser(User);
            return RedirectToPage("Index");
        }
    }
}
