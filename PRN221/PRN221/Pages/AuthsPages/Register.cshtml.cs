//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Data.Entities;
//using Service.Model;
//using Service;
//using AutoMapper;
//using Service.Interface;

//namespace PRN221.Pages.AuthsPages
//{
//    public class RegisterModel : PageModel
//    {
//        private readonly IUserService _userService;
//        private readonly IMapper _mapper;
//        private readonly IRoleService _roleService;

//        public RegisterModel(IUserService userService, IMapper mapper, IRoleService roleService)
//        {
//            _userService = userService;
//            _mapper = mapper;
//            _roleService = roleService;
//        }

//        public void OnGet()
//        {
//        }

//        [BindProperty]
//        public UserModel UserModel { get; set; } = default!;

        

//        public async Task<IActionResult> OnPostAsync()
//        {
//            if (!ModelState.IsValid)
//            {
//                ModelState.AddModelError("", "One or more files has wrong.");
//                return Page();
//            }
//            var addingUser = _mapper.Map<User>(UserModel);
//            addingUser.roleId = (await _roleService.getRoleByName("Member")).id;
//            var user = await _userService.Add(addingUser);
//           if (user == null) 
//            {
//                ModelState.AddModelError("","Error whild adding customer");
//                return Page();
//            }
//            TempData["Message"] = "Register Successfully!";
//            return Redirect("/authspages/login");
//        }
//    }
//}
