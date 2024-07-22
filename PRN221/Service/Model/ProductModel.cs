using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model
{
    public class ProductModel : BaseModel
    {
        public string? Image { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Brand must contain only alphabetic characters.")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Stock quantity is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Stock quantity must be equal or greater than 0.")]
        public int StockQuantity { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(1, double.MaxValue, ErrorMessage = "The price must be greater than 0.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Brand is required")]
        public string Brand { get; set; }

        public double? AverageRating { get; set; }

        [Required(ErrorMessage = "Product type is required")]
        public Guid ProductTypeId { get; set; }
        public ProductTypeModel ProductType { get; set; }
    }

}
