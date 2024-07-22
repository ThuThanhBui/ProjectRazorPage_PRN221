using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model
{
    public class OrderXProductModel : BaseModel
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }

        public OrderModel? Order { get; set; }
        public ProductModel? Product { get; set; }
    }

}
