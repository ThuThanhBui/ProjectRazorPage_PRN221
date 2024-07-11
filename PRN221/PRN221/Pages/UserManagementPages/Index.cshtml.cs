using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Interface;
using Service.Model;

namespace PRN221.Pages.UserManagement
{
    public class IndexModel : PageModel
    {
        private readonly IUserService _userService;

        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }

        public List<UserModel> Users { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Users = await _userService.GetAllUsers();
        }
    }
}
