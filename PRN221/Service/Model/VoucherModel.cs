using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model
{
    public class VoucherModel : BaseModel
    {
        public string VoucherName { get; set; }
        public int Content { get; set; }
        public int? Condition { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid? VoucherTypeId { get; set; }

        public VoucherTypeModel? VoucherType { get; set; }
    }

}
