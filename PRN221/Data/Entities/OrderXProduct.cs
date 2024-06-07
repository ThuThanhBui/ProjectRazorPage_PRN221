using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class OrderXProduct
    {
        public Guid orderId {  get; set; }
        public Guid productId { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
