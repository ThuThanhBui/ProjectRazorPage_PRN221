using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        [BindProperty(SupportsGet = true)]
        public int PageIndex { get; set; } = 1;
        public int TotalPages { get; set; }
        public int StartPage { get; set; }
        public int EndPage { get; set; }

        public async Task OnGetAsync()
        {
            int pageSize = 5; 
            var users = await _userService.GetAllUsers();
            TotalPages = (int)Math.Ceiling(users.Count / (double)pageSize);
            Users = await _userService.GetPagedUsers(PageIndex, pageSize);

            StartPage = Math.Max(1, PageIndex - 1);
            EndPage = Math.Min(TotalPages, PageIndex + 1);

            if (PageIndex == 1)
            {
                EndPage = Math.Min(3, TotalPages);
            }
            if (PageIndex == TotalPages)
            {
                StartPage = Math.Max(1, TotalPages - 2);
            }
        }
    }
}
