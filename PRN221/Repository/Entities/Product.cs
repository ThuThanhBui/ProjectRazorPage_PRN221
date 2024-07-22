using Repository.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("Product")]
    public class Product : BaseEntity
    {
        public string? Image { get; set; }
        public string ProductName { get; set; }
        public string? Description { get; set; }
        public int StockQuantity { get; set; }
        public decimal Price { get; set; }
        public string? Brand { get; set; }
        public double? AverageRating { get; set; }
        public Guid? ProductTypeId { get; set; }
        public virtual ProductType? ProductType { get; set; }
        public virtual ICollection<OrderXProduct>? OrderXProducts { get; set; }
        public virtual ICollection<ProductFeedback>? ProductFeedbacks { get; set; }
    }
}
