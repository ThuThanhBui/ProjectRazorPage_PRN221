using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model
{
    public class OrderXProductModel
    {
        public Guid orderId { get; set; }
        public Guid productId { get; set; }
        public int quantity { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
