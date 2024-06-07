using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("Voucher")]
    public class Voucher
    {
        [Key]
        public Guid id { get; set; }
        public string content { get; set; }
        public bool isDeleted { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime updatedDate { get; set; }

        public Guid voucherTypeId { get; set; }
        public virtual VoucherType voucherType { get; set; }
        public virtual ICollection<Order> orders { get; set; }
    }
}
