using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data.Entities;
using Service.Interface;
using Service.Model;

namespace PRN221.Pages.OrderPages
{
    public class EditModel : PageModel
    {
        private readonly IOrderService _orderService;

        public EditModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [BindProperty]
        public OrderModel Order { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var order = await _orderService.GetById(id);

            Order = order;
            //ViewData["userId"] = new SelectList(_context.Users, "id", "email");
            //ViewData["voucherId"] = new SelectList(_context.Vouchers, "id", "content");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            var order = await _orderService.GetById(id);

            order = Order;

            await _orderService.Update(order);

            return RedirectToPage("/OrderPages/Index");
        }
    }
}
