using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Interface;
using Service.Model;
using System.Threading.Tasks;

namespace PRN221.Pages.UserManagement
{
    public class DeleteModel : PageModel
    {
        private readonly IUserService _userService;

        public DeleteModel(IUserService userService)
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

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            await _userService.DeleteUser(id);
            return RedirectToPage("Index");
        }
    }
}
