using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NuGet.Packaging;
using PRN221.Service.Model;
using Service.Interface;
using Service.Model;
using System.Data;

namespace PRN221.Pages.Cart
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IOrderXProductService _orderXProductService;
        private readonly IProductTypeService _productTypeService;

        public IndexModel(IProductService productService, IOrderService orderService, IOrderXProductService orderXProductService, IProductTypeService productTypeService)
        {
            _productService = productService;
            _orderService = orderService;
            _orderXProductService = orderXProductService;
            _productTypeService = productTypeService;
        }

        [BindProperty]
        public List<OrderXProductModel> carts { get; set; } = default!;

        [BindProperty]
        public OrderModel orderModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            if (carts == null)
            {
                carts = new List<OrderXProductModel>();
            }

            var userId = HttpContext.Session.GetString("userId");
            var order = await _orderService.FindOne(m => m.UserId == Guid.Parse(userId) && m.Status.ToLower() != "Completed".ToLower());
            if (order == null)
            {
                TempData["Message"] = ($"Empty cart");
                return RedirectToPage();
            } else
            {
                var orderXProduct = await _orderXProductService.FindAll(m => m.OrderId == order.Id);
                if (orderXProduct == null)
                {
                    TempData["Message"] = ($"Empty cart");
                    return RedirectToPage();
                }

                carts = orderXProduct.ToList();
                carts = CalculateTotalPriceInCart(carts); // get total price each product
                orderModel = order; // get total price

                return Page();
            }

        }

        public List<OrderXProductModel> CalculateTotalPriceInCart(List<OrderXProductModel> carts)
        {
            foreach (var item in carts)
            {
                item.TotalPrice += (item.Quantity * item.Product.Price);
            }

            return carts;
        }
    }
}
