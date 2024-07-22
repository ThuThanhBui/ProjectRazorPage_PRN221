using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repository.Repository.Interface;
using Service.Interface;
using Service.Model;
using System.Security.Principal;

namespace PRN221.Pages.OrderMember
{
    public class DetailModel : PageModel
    {
        private readonly IOrderService _orderService;
        private readonly IOrderXProductService _orderXProductService;
        private readonly IVoucherService _voucherService;

        public DetailModel(IOrderService orderService, IOrderXProductService orderXProductService, IVoucherService voucherService)
        {
            _orderService = orderService;
            _orderXProductService = orderXProductService;
            _voucherService = voucherService;
        }

        [BindProperty]
        public OrderModel order { get; set; }
        [BindProperty]
        public List<OrderXProductModel> orderXproducts { get; set; }
        [BindProperty]
        public VoucherModel voucher { get; set; }

        public decimal total = 0;
        public decimal discount = 0;
        public decimal totalPaid = 0;
        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            order = await _orderService.GetById(id);
            if (order == null)
            {
                return NotFound();
            }

            orderXproducts = await _orderXProductService.GetByOrderId(id);
            foreach (var item in orderXproducts)
            {
                total += item.Quantity * item.Product.Price;
            }

            if (order.Voucher != null)
            {
                voucher = await _voucherService.GetById((Guid)order.VoucherId);
                if (order.Voucher.VoucherTypeId == Guid.Parse("B2645A49-584A-4156-B843-38F8D0DD5A63"))
                {
                    discount = order.Voucher.Content;
                    totalPaid = total - discount;
                }
                else if (order.Voucher.VoucherTypeId == Guid.Parse("BBC4208D-C6D4-405F-99C9-EE2F17C0B212"))
                {
                    discount = total / 100 * order.Voucher.Content;
                    totalPaid = total - discount;
                }
            }
            else
            {
                totalPaid = total;
            }

            return Page();
        }
    }
}
