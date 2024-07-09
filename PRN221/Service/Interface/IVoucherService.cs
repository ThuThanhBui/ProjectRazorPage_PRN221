using Data.Entities;
using Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IVoucherService
    {
        Task<List<VoucherModel>> GetAll();
        Task<List<VoucherModel>> GetVoucherByTypeId(Guid id);
        Task<VoucherModel> GetById(Guid? id);
        Task<bool> Add(VoucherModel voucher);
        Task<bool> Delete(Guid id);
        Task<bool> Update(VoucherModel voucher);
    }
}
