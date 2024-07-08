using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    [Table("Voucher")]
    public class Voucher
    {
        [Key]
        public Guid id { get; set; }
        public string vouchername { get; set; }
        public int content { get; set; } 
        public int condition { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool isDeleted { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime updatedDate { get; set; }

        public Guid voucherTypeId { get; set; }
        public virtual VoucherType voucherType { get; set; }
        public virtual ICollection<Order> orders { get; set; }
    }
}
