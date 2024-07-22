using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Data.Entities;
using Service.Interface;
using Service.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace PRN221.Pages.OrderPages
{
    public class IndexModel : PageModel
    {
        private readonly IOrderService _orderService;
        public IndexModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public List<OrderModel> Orders { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string StatusFilter { get; set; }
        public JsonResult OnGetSignalR()
        {
            OnGetAsync().Wait();
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                WriteIndented = true
            };

            return new JsonResult(Orders, options);
        }
        public async Task OnGetAsync()
        {
            if (!StatusFilter.IsNullOrEmpty())
            {
                Orders = await _orderService.GetByStatus(StatusFilter);
            }
            else
            {
                Orders = await _orderService.GetAll();
            }

        }
    }
}
