using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly PRNDbContext _context;

        public OrderRepository(PRNDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Order>> GetAll()
        {
            return await _context.Orders
                .Include(o => o.User)
                .Include(o => o.Voucher)
                .ToListAsync();
        }

        public async Task<Order> GetById(Guid id)
        {
            return await _context.Orders
                .Where(o => o.Id == id)
                .SingleOrDefaultAsync();
        }

        public async Task<bool> DeleteById(Guid id)
        {
            try
            {
                var order = await _context.Orders.FindAsync(id);
                if (order == null)
                    return false;

                order.Status = "Canceled";
                order.IsDeleted = true;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                throw new ApplicationException("Error deleting order by Id", ex);
            }
        }

        public async Task<bool> Update(Order order)
        {
            try
            {
                var existingOrder = await _context.Orders.FindAsync(order.Id);
                if (existingOrder == null)
                    return false;

                existingOrder.Description = order.Description;
                existingOrder.Status = order.Status;
                existingOrder.TotalPrice = order.TotalPrice;
                existingOrder.IsDeleted = order.IsDeleted;
                existingOrder.CreatedDate = order.CreatedDate;
                existingOrder.LastUpdatedDate = order.LastUpdatedDate;
                existingOrder.VoucherId = order.VoucherId;

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                throw new ApplicationException("Error updating order", ex);
            }
        }

        public async Task<bool> Add(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return true; // Assuming successful save
        }

        public async Task<List<Order>> GetByStatus(string status)
        {
            return await _context.Orders
                .Where(o => o.Status == status)
                .Include(o => o.Voucher)
                .Include(o => o.User)
                .ToListAsync();
        }
    }
}
