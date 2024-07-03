using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("ProductType")]
    public class ProductType
    {
        [Key]
        public Guid id { get; set; }
        public string productType { get; set; }

        public virtual ICollection<Product> products { get; set;}
    }
}
