using Repository.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("Order")]
    public class Order : BaseEntity
    {
        public string Description { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }

        public Guid? VoucherId { get; set; }
        public Guid? UserId { get; set; }
        public virtual User? User { get; set; }
        public virtual Voucher? Voucher { get; set; }
        public virtual ICollection<OrderXProduct>? OrderXProducts { get; set; }
    }

}
