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
        private readonly IVoucherService _voucherService;
        private readonly IOrderXProductService _orderXProductService;

        public EditModel(IOrderService orderService, IVoucherService voucherService, IOrderXProductService orderXProductService)
        {
            _orderService = orderService;
            _voucherService = voucherService;
            _orderXProductService = orderXProductService;
        }

        [BindProperty]
        public OrderModel Order { get; set; } = default!;

        public List<VoucherModel> vouchers { get; set; } = default!;
        public List<OrderXProductModel> orderXProducts { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var order = await _orderService.GetById(id);
            Order = order;

            vouchers = await _voucherService.GetAll();

            orderXProducts = await _orderXProductService.GetByOrderId(Order.id);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            var order = await _orderService.GetById(id);

            VoucherModel voucher = await _voucherService.GetById(Order.voucherId);
            decimal total = 0;
            foreach (var item in orderXProducts)
            {
                total += item.Product.price * item.quantity;
            }

            if (voucher.voucherType.typeName == "Percentage Discount Voucher")
            {
                total = total / 100 * (1 - int.Parse(voucher.content.Substring(0, 2)));
            }
            else if (voucher.voucherType.typeName == "Fixed Discount Voucher")
            {
                total = total - decimal.Parse(voucher.content);
            }

            order = Order;

            bool updateSuccess = await _orderService.Update(order);
            if (updateSuccess)
            {
                return RedirectToPage("/OrderPages/Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
