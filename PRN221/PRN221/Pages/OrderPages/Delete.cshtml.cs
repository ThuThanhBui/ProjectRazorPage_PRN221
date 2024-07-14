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

namespace PRN221.Pages.OrderPages
{
    public class DeleteModel : PageModel
    {
        private readonly IOrderService _orderService;

        public DeleteModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [BindProperty]
        public OrderModel Order { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var order = await _orderService.GetById(id);

            Order = order;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            await _orderService.DeleteById(id);

            return RedirectToPage("/OrderPages/Index");
        }
    }
}
