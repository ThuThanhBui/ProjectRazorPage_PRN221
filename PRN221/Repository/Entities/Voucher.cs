using Repository.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("Voucher")]
    public class Voucher : BaseEntity
    {
        public string VoucherName { get; set; }

        public int Content { get; set; }

        public int? Condition { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public Guid? VoucherTypeId { get; set; }

        public virtual VoucherType? VoucherType { get; set; }

        public virtual ICollection<Order>? Orders { get; set; }
    }

}
