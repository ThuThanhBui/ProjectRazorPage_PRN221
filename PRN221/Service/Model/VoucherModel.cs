﻿using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Model
{
    public class VoucherModel
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

    }
}
