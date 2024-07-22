using Data.Entities;
using Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IOrderXProductService
    {
        Task<List<OrderXProductModel>> GetByOrderId(Guid id);
        Task<List<OrderXProductModel>> GetByProductId(Guid id);
        Task<OrderXProductModel> GetOne(Guid oId, Guid pId);
        Task<bool> Add(OrderXProductModel model);
        Task<bool> Update(OrderXProductModel model);
        Task<bool> DeleteOne(Guid oId, Guid pId);
        Task<bool> DeleteAllByOrderId(Guid id);
        Task<OrderXProductModel> FindOne(Expression<Func<OrderXProduct, bool>> predicate);
        Task<List<OrderXProductModel>> FindAll(Expression<Func<OrderXProduct, bool>> predicate);
    }
}
