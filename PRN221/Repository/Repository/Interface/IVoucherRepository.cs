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
        Task<Voucher> GetById(Guid id);
        Task<bool> Add(Voucher voucher);
        Task<bool> DeleteById(Guid id);
        Task<bool> Update(Voucher voucher);
    }
}
