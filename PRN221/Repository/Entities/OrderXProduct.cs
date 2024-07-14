using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class OrderXProduct : BaseEntity
    {
        public int Quantity { get; set; }

        public Guid? OrderId { get; set; }
        public Guid? ProductId { get; set; }
        public virtual Order? Order { get; set; }
        public virtual Product? Product { get; set; }
    }
}
