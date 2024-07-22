using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Data.Entities;
using Microsoft.IdentityModel.Tokens;
using Service.Interface;
using Service.Model;

namespace PRN221.Pages.OrderMember
{
    public class IndexModel : PageModel
    {
        private readonly IOrderService _orderService;
        public IndexModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public List<OrderModel> Orders { get; set; } = default!;

   //     [BindProperty(SupportsGet = true)]
  //      public string StatusFilter { get; set; }

        public async Task OnGetAsync()
        {
    //        if (!StatusFilter.IsNullOrEmpty())
  //          {
                Orders = await _orderService.GetByUserId(Guid.Parse(HttpContext.Session.GetString("userId")));
    //        }
     //       else
      //      {
      //          Orders = await _orderService.GetAll();
       //     }

        }
    }
}
