using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Data.Entities;
using Repository.Repository.Interface;
using Service.Model;
using Service.Interface;
using PRN221.Service.Model;

namespace PRN221.Pages.AuthsPages
{
    public class LoginModel : PageModel
    {
        private readonly IUserService userService;

        public LoginModel(IUserService _userService)
        {
            userService = _userService;
        }
        [BindProperty]
        public string email { get; set; }
        [BindProperty]
        public string password { get; set; }
        public string Message { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await userService.Login(email, password);
            if (user == null)
            {
                Message = "Invalid username or password.";
                return Page();
            }
            else
            {
                Session.email = user.Email;
                HttpContext.Session.SetString("role", user.Role.RoleName);
                HttpContext.Session.SetString("email", user.Email);
                return RedirectToPage("/Home");
            }
        }
    }
}
