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

            await GetOrder();

            if (orderModel == null)
            {
                TempData["Message"] = ($"Empty cart");
                return Page();
            }
            else
            {
                var orderXProduct = await _orderXProductService.FindAll(m => m.OrderId == orderModel.Id);
                if (orderXProduct == null)
                {
                    TempData["Message"] = ($"Empty cart");
                    return Page();
                }

                carts = orderXProduct.ToList();
                carts = CalculateTotalPriceInCart(carts); // get total price each product

                return Page();
            }

        }

        public async Task GetOrder()
        {
            var userId = HttpContext.Session.GetString("userId");
            orderModel = await _orderService.FindOne(m => m.UserId == Guid.Parse(userId) && m.Status.ToLower() != "Completed".ToLower());
        }

        public List<OrderXProductModel> CalculateTotalPriceInCart(List<OrderXProductModel> carts)
        {
            foreach (var item in carts)
            {
                item.TotalPrice += (item.Quantity * item.Product.Price);
            }

            return carts;
        }

        public async Task<IActionResult> OnPostCheckoutAsync()
        {
            if (orderModel.Id == null)
            {
                await GetOrder();
            }

            orderModel.Status = "Completed";
            await _orderService.Update(orderModel);

            return RedirectToPage("/Cart/AlertSuccessPayment");
        }
        
        public async Task<IActionResult> OnPostRemoveAsync(Guid? productId)
        {
            if (orderModel.Id == null)
            {
                await GetOrder();
            }
            var orderXProduct = await _orderXProductService.FindOne(m => m.OrderId == orderModel.Id && m.ProductId == productId);

            if (orderXProduct == null) return RedirectToPage();

            orderXProduct.Quantity -= 1;

            if (orderXProduct.Quantity == 0)
            {
                await _orderXProductService.DeleteOne(orderModel.Id.Value, productId.Value);
            }

            await _orderXProductService.Update(orderXProduct);

            var listCart = await _orderXProductService.FindAll(m => m.OrderId == orderModel.Id);

            orderModel.TotalPrice = 0;
            listCart.ForEach(async x =>
            {
                orderModel.TotalPrice += (x.Quantity * x.Product.Price);

            });

            await _orderService.Update(orderModel);
            return RedirectToPage();
        }
    }
}
