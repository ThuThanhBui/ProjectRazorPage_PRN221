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
            User.LastUpdatedDate = DateTime.Now;

            try
            {
                var existingUserWithSameEmail = await _userService.GetByEmail(User.Email);
                if (existingUserWithSameEmail != null && existingUserWithSameEmail.Id != User.Id)
                {
                    ModelState.AddModelError(string.Empty, "Email is already in use by another user.");
                    Roles = await _roleService.GetAll(); 
                    return Page();
                }

                var updateSuccess = await _userService.Update(User);
                if (updateSuccess)
                {
                    TempData["Message"] = "Edit successful.";
                    return RedirectToPage("/UserManagementPages/Index");
                }
                else
                {
                    Roles = await _roleService.GetAll();
                    return Page();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
                Roles = await _roleService.GetAll(); 
                return Page();
            }
        }


    }
}
