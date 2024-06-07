using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("Product")]
    public class Product
    {
        [Key]
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
        public virtual ICollection<OrderXProduct>? OrderXProducts { get; set; }
        public virtual ICollection<ProductFeedback> ProductFeedbacks { get; set; }
    }
}
