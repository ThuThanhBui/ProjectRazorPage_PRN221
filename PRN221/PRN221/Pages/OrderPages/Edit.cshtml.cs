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

        [BindProperty]
        public List<OrderXProductModel> orderXProducts { get; set; }

        public async Task OnGetAsync(Guid id)
        {
            var order = await _orderService.GetById(id);
            Order = order;

            vouchers = await _voucherService.GetAll();

            orderXProducts = await _orderXProductService.GetByOrderId(Order.id);

        }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            var order = await _orderService.GetById(id);
            //orderXProducts = await _orderXProductService.GetByOrderId(Order.id);
            decimal total = 0;
            List<OrderXProductModel> list = new List<OrderXProductModel>();
            foreach (var item in orderXProducts)
            {
                list.Add(await _orderXProductService.GetOne(item.orderId, item.productId));
            }
            for (int i = 0; i < list.Count; i++)
            {
                list[i].quantity = orderXProducts[i].quantity;
                await _orderXProductService.Update(list[i]);
                total += list[i].Product.price * list[i].quantity;
                //var op = await _orderXProductService.GetOne(item.orderId, item.productId);
                //if (op != null)
                //{
                //    op.quantity = item.quantity;
                //    await _orderXProductService.Update(op);
                //    total += item.Product.price * item.quantity;
                //}
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
            order.updatedDate = DateTime.Now;

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
