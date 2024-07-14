using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service;
using Service.Interface;
using Service.Model;
using System.Threading.Tasks;

namespace PRN221.Pages.UserManagement
{
    public class CreateModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public CreateModel(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        public List<RoleModel> Roles { get; set; } = default!;

        [BindProperty]
        public UserModel User { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Roles = await _roleService.GetAll();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            User.IsDeleted = false;
            User.CreatedDate = DateTime.Now;
            User.UpdatedDate = DateTime.Now;

            var addSuccess = await _userService.AddUser(User);
            if (addSuccess)
            {
                OnGetAsync();
                return RedirectToPage("/UserManagementPages/Index");
            }
            else
            {
                OnGetAsync();
                return Page();
            }
        }

    }
}
