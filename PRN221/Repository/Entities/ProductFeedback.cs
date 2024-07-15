using Repository.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("ProductFeedback")]
    public class ProductFeedback : BaseEntity
    {
        public int Rating { get; set; }
        public string? Comment { get; set; }

        public Guid? UserId { get; set; }
        public Guid? ProductId { get; set; }
        public virtual User? User { get; set; }
        public virtual Product? Product { get; set; }
    }
}
