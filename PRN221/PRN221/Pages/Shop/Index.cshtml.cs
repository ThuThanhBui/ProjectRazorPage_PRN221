using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using PRN221.Service.Model;
using Service.Interface;
using Service.Model;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace PRN221.Pages.Shop
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

        public List<ProductModel> Products { get; set; } = default!;
        public List<ProductTypeModel> ProductTypes { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string keyword { get; set; }

        


        public async Task OnGetAsync(Guid? id = null)
        {
            ProductTypes = await _productTypeService.GetAll();
            if (id == null)
            {
                Products = await _productService.GetAll();
            }
            else
            {
                Products = await _productService.GetByTypeId((Guid)id);
            }
        }

        public async Task<IActionResult> OnPostAddToCartAsync(Guid? id)
        {

            var product = await _productService.GetById((Guid)id);

            if (product == null)
            {
                return NotFound();
            }

            // check order has any userId with status ( not completed ) and then create order and get id order
            var userId = HttpContext.Session.GetString("userId");
            var order = await _orderService.FindOne(m => m.UserId == Guid.Parse(userId) && m.Status.ToLower() == "Waiting".ToLower());

            // + if has any order with userId and not completed, we use this order, else null we create new order with status Not completed
            if (order == null)
            {
                bool isCreated = await _orderService.Add(new OrderModel
                {
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    IsDeleted = false,
                    Description = string.Empty,
                    Status = "Waiting",
                    TotalPrice = 0,
                    UserId = Guid.Parse(userId),
                    VoucherId = null,
                });
                if (isCreated)
                {
                    order = await _orderService.FindOne(m => m.UserId == Guid.Parse(userId) && m.Status.ToLower() == "Waiting".ToLower());
                }
            }

            // check orderXProduct has any orderId
            // + if null, create new
            var orderXProduct = await _orderXProductService.FindOne(m => m.OrderId == order.Id && m.ProductId == product.Id);
            if (orderXProduct == null)
            {
                bool isCreated = await _orderXProductService.Add(new OrderXProductModel
                {
                    Id = Guid.NewGuid(),
                    CreatedDate = DateTime.Now,
                    LastUpdatedDate = DateTime.Now,
                    IsDeleted = false,
                    Quantity = 1,
                    OrderId = order.Id.Value,
                    ProductId = product.Id.Value,
                });
                // update price order
                if (isCreated)
                {
                    TempData["Message"] = ($"{product.ProductName} added to cart.");
                }
            }
            else
            {
                //+ quantity, update quantity orderXProducy, price order
                orderXProduct.Quantity += 1;
                bool isUpdated = await _orderXProductService.Update(orderXProduct);
                if (isUpdated)
                {
                    TempData["Message"] = ($"{product.ProductName} increased 1");
                }
            }

            // update total price in order
            var listCart = await _orderXProductService.FindAll(m => m.OrderId == order.Id);
            order.TotalPrice = 0;
            listCart.ForEach(async x =>
            {
                order.TotalPrice += (x.Quantity * x.Product.Price);
                
            });

            await _orderService.Update(order);


            return RedirectToPage();
        }
    }
}
