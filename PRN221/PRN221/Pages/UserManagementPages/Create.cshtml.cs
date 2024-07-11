using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service.Interface;
using Service.Model;
using System.Threading.Tasks;

namespace PRN221.Pages.UserManagement
{
    public class CreateModel : PageModel
    {
        private readonly IUserService _userService;

        public CreateModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public UserModel User { get; set; }

        public void OnGet()
        {
        }

        
    }
}
