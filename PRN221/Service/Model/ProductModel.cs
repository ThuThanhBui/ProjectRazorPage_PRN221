using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model
{
    public class ProductModel : BaseModel
    {
        public string? Image { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int StockQuantity { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; }
        public double? AverageRating { get; set; }
        public Guid ProductTypeId { get; set; }
        public ProductTypeModel ProductType { get; set; }
    }

}
