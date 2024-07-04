using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model
{
    public class OrderModel
    {
        public Guid id { get; set; }
        public string description { get; set; }
        public decimal totalPrice { get; set; }
        public string status { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime updatedDate { get; set; }

        public Guid? voucherId { get; set; }
        public Guid userId { get; set; }
        public User User { get; set; }
        public Voucher? Voucher { get; set; }
    }
}
