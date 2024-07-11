using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service;
using Service.Interface;
using Service.Model;
using System;
using System.Threading.Tasks;

namespace PRN221.Pages.UserManagement
{
    public class EditModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public EditModel(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        [BindProperty]
        public UserModel User { get; set; } = default!;
        public List<RoleModel> Roles { get; set; } = default!;

        public async Task OnGetAsync(Guid id)
        {
            User = await _userService.GetById(id);
            Roles = await _roleService.GetAll();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            User.UpdatedDate = DateTime.Now;

            var addSuccess = await _userService.Update(User);
            if (addSuccess)
            {
                return RedirectToPage("/UserManagementPages/Index");
            }
            else
            {
                await OnGetAsync(User.Id);
                return Page();
            }
        }

    }
}
