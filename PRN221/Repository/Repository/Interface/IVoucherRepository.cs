using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Interface
{
    public interface IVoucherRepository
    {
        Task<List<Voucher>> GetAll();
        Task<List<Voucher>> GetVoucherByTypeId(Guid id);
        Task<Voucher> GetById(Guid? id);
        Task<bool> Add(Voucher voucher);
        Task<bool> Delete(Guid id);
        Task<bool> Update(Voucher voucher);
    }
}
