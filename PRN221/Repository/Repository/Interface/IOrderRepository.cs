using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Interface
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAll();
        Task<Order> GetById(Guid id);
        Task<bool> Add(Order order);
        Task<bool> DeleteById(Guid id);
        Task<bool> Update(Order order);
        Task<List<Order>> GetByStatus(string Status);
        Task<Order> FindOne(Expression<Func<Order, bool>> predicate);
        Task<List<Order>> FindAll(Expression<Func<Order, bool>> predicate);
        Task<List<Order>> GetByUserId(Guid id);
    }
}
