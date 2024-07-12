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
            User = await _userService.GetById(id);
            if (User == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            var deleted = await _userService.DeleteUser(id);
            if (!deleted)
            {
                return NotFound();
            }
            TempData["Message"] = "Deletion successful.";
            return RedirectToPage("Index");
        }
    }
}
