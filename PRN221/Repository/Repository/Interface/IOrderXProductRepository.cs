using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Interface
{
    public interface IOrderXProductRepository
    {
        Task<List<OrderXProduct>> GetByOrderId(Guid id);
        Task<List<OrderXProduct>> GetByProductId(Guid id);
        Task<OrderXProduct> GetOne(Guid oId, Guid pId);
        Task<bool> Add(OrderXProduct op);
        Task<bool> Update(OrderXProduct op);
        Task<bool> DeleteOne(Guid oId, Guid pId);
        Task<bool> DeleteAllByOrderId(Guid id);
    }
}
