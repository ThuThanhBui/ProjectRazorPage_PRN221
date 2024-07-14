using System;
using System.Collections.Generic;
using System.Linq;
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

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public async Task OnGetAsync()
        {
            int pageSize = 5;
            var users = await _userService.GetAllUsers();

            if (!string.IsNullOrEmpty(SearchTerm))
            {
                users = users.Where(u => u.FullName.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase)
                                      || u.Email.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            users = users.OrderByDescending(u => u.UpdatedDate).ToList();

            TotalPages = (int)Math.Ceiling(users.Count / (double)pageSize);
            Users = users.Skip((PageIndex - 1) * pageSize).Take(pageSize).ToList();

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
