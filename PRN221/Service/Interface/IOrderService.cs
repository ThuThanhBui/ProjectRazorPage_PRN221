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
    public interface IOrderService
    {
        Task<List<OrderModel>> GetAll();
        Task<OrderModel> GetById(Guid id);
        Task<bool> Add(OrderModel model);
        Task<bool> DeleteById(Guid id);
        Task<bool> Update(OrderModel model);
        Task<List<OrderModel>> GetByStatus(string Status);
        Task<OrderModel> FindOne(Expression<Func<Order, bool>> predicate);
        Task<List<OrderModel>> FindAll(Expression<Func<Order, bool>> predicate);
        Task<List<OrderModel>> GetByUserId(Guid id);
    }
}
