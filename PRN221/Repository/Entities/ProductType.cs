using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("ProductType")]
    public class ProductType
    {
        [Key]
        public Guid Id { get; set; }
        public string ProductTypeName { get; set; }

        public virtual ICollection<Product>? Products { get; set; }
    }
}
