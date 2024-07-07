using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model
{
    public class ProductModel
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int stockQuantity { get; set; }
        public decimal price { get; set; }
        public bool isDeleted { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime updatedDate { get; set; }

        public Guid productTypeId { get; set; }
        public virtual ProductType productType { get; set; }
    }
}
