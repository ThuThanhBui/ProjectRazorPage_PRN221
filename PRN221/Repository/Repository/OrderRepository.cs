using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly PRNDbContext _context;

        public OrderRepository(PRNDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetAll()
        {
            return await _context.Orders.Include(o => o.User).Include(o => o.Voucher).ToListAsync();
        }

        public async Task<Order> GetById(Guid id)
        {
            return await _context.Orders.Where(o => o.id == id).SingleOrDefaultAsync();
        }

        public async Task<bool> DeleteById(Guid id)
        {
            var o = await GetById(id);
            o.status = "Canceled";

            return await _context.SaveChangesAsync() > 0;
        }


        public async Task<bool> Update(Order order)
        {
            var o = await GetById(order.id);
            o.description = order.description;
            o.status = order.status;
            o.totalPrice = order.totalPrice;
            o.createdDate = order.createdDate;
            o.updatedDate = order.updatedDate;
            o.voucherId = order.voucherId;
            o.userId = order.userId;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Add(Order order)
        {
            await _context.Orders.AddAsync(order);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Order>> GetByStatus(string status)
        {
            return await _context.Orders.Where(o => o.status == status).Include(o => o.Voucher).Include(o => o.User).ToListAsync();
        }
    }
}
