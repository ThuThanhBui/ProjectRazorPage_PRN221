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
        public List<OrderXProductModel> orderXProducts { get; set; }

        public async Task OnGetAsync(Guid id)
        {
            var order = await _orderService.GetById(id);
            Order = order;

            vouchers = await _voucherService.GetAll();

            orderXProducts = await _orderXProductService.GetByOrderId(Order.id);

        }

        public async Task<IActionResult> OnPostAsync(Guid id, List<OrderXProductModel> orderXProduct)
        {
            var order = await _orderService.GetById(id);
            //orderXProducts = await _orderXProductService.GetByOrderId(Order.id);
            decimal total = 0;
            foreach (var item in orderXProduct)
            {
                total += item.Product.price * item.quantity;
            }
            if (Order.voucherId.HasValue)
            {
                VoucherModel voucher = await _voucherService.GetById((Guid)Order.voucherId);
                if (voucher.voucherType.typeName == "Percentage Discount Voucher")
                {
                    total = total / 100 * (100 - voucher.content);
                }
                else if (voucher.voucherType.typeName == "Fixed Discount Voucher")
                {
                    total = total - voucher.content;
                }
            }
            Order.totalPrice = total;
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
