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
using Microsoft.AspNetCore.Http;
using System.Buffers.Text;
using System.Net.NetworkInformation;
using NuGet.Protocol;
using System.Text.Json;

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
            if (user == null || user.IsDeleted == true)
            {
                Message = "Invalid username or password.";
                return Page();
            }

            else 
            {
                //set img
                if (user.Image != null)
                {
                    HttpContext.Session.SetString("image",user.Image);
                }
                else
                {
                    HttpContext.Session.SetString("image", "https://i.imgur.com/ZTkt4I5.jpg");
                }
                //set info
                HttpContext.Session.SetString("name", user.FullName);
                HttpContext.Session.SetString("role", user.Role.RoleName);
                HttpContext.Session.SetString("email", user.Email);
                HttpContext.Session.SetString("userId", user.Id.ToString());

                //check role chuyen trang
                if (user.Role.RoleName == "Staff" || user.Role.RoleName == "Admin")
                {
                    return RedirectToPage("/ProfilePages/Index");
                }
                else if (user.Role.RoleName == "Member")
                {
                    return RedirectToPage("/Home");

                }
            }

            return Page();
        }
    }
}
