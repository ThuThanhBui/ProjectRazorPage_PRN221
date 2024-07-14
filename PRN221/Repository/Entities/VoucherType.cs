using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("VoucherType")]
    public class VoucherType
    {
        [Key]
        public Guid Id { get; set; }

        public string VoucherTypeName { get; set; }

        public virtual ICollection<Voucher>? Vouchers { get; set; }
    }
}
