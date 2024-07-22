using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model
{
    public class OrderModel : BaseModel
    {
        public string Description { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }

        public Guid? VoucherId { get; set; }
        public Guid UserId { get; set; }
        public UserModel User { get; set; }
        public VoucherModel? Voucher { get; set; }
    }

}
