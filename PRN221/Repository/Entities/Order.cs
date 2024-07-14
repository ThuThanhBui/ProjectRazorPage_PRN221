using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public Guid id { get; set; }
        public string description { get; set; }
        public decimal totalPrice { get; set; }
        public string status { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime updatedDate { get; set; }

        public Guid? voucherId { get; set; }
        public Guid userId { get; set; }
        public virtual User User { get; set; }
        public virtual Voucher? Voucher { get; set; }
        public virtual ICollection<OrderXProduct>? OrderXProducts { get; set; }
    }
}
