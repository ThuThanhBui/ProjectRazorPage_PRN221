using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("ProductFeedback")]
    public class ProductFeedback
    {
        [Key]
        public Guid id { get; set; }
        public int rating { get; set; }
        public string comment { get; set; }
        public bool isDeleted { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime updatedDate { get; set; }

        public Guid userId { get; set; }
        public Guid productId { get; set; }
        public virtual User user { get; set; }
        public virtual Product product { get; set; }
    }
}
