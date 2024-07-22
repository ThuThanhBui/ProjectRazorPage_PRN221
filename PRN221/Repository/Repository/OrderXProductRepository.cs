using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class OrderXProductRepository : IOrderXProductRepository
    {
        private readonly PRNDbContext _context;

        public OrderXProductRepository(PRNDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> Add(OrderXProduct op)
        {
            await _context.OrderXProducts.AddAsync(op);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<OrderXProduct> FindOne(Expression<Func<OrderXProduct, bool>> predicate)
        {
            OrderXProduct x = null;
            try
            {
                x = await _context.OrderXProducts.SingleOrDefaultAsync(predicate);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return x;
        }

        public async Task<List<OrderXProduct>> FindAll(Expression<Func<OrderXProduct, bool>> predicate)
        {
            List<OrderXProduct> list = new List<OrderXProduct>();
            try
            {
                list = await _context.OrderXProducts.Where(predicate).Include(m => m.Product).Include(m => m.Order).ToListAsync();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return list;
        }

        public async Task<bool> DeleteAllByOrderId(Guid orderId)
        {
            try
            {
                var orderProducts = await _context.OrderXProducts
                    .Where(op => op.OrderId == orderId)
                    .ToListAsync();

                if (orderProducts != null && orderProducts.Any())
                {
                    _context.OrderXProducts.RemoveRange(orderProducts);
                    return await _context.SaveChangesAsync() > 0;
                }

                return false;
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                throw new ApplicationException("Error deleting order products", ex);
            }
        }

        public async Task<bool> DeleteOne(Guid orderId, Guid productId)
        {
            try
            {
                var op = await _context.OrderXProducts
                    .FirstOrDefaultAsync(op => op.OrderId == orderId && op.ProductId == productId);

                if (op != null)
                {
                    _context.OrderXProducts.Remove(op);
                    return await _context.SaveChangesAsync() > 0;
                }

                return false;
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                throw new ApplicationException("Error deleting order product", ex);
            }
        }

        public async Task<List<OrderXProduct>> GetByOrderId(Guid orderId)
        {
            return await _context.OrderXProducts
                .Where(op => op.OrderId == orderId)
                .Include(op => op.Product)
                .ToListAsync();
        }

        public async Task<List<OrderXProduct>> GetByProductId(Guid productId)
        {
            return await _context.OrderXProducts
                .Where(op => op.ProductId == productId)
                .ToListAsync();
        }

        public async Task<OrderXProduct> GetOne(Guid orderId, Guid productId)
        {
            return await _context.OrderXProducts
                .Where(op => op.OrderId == orderId && op.ProductId == productId)
                .Include(op => op.Order)
                .Include(op => op.Product)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> Update(OrderXProduct op)
        {
            try
            {
                var existingOp = await GetOne(op.OrderId.Value, op.ProductId.Value);

                if (existingOp != null)
                {
                    existingOp.Quantity = op.Quantity;
                    _context.OrderXProducts.Update(existingOp);
                    return await _context.SaveChangesAsync() > 0;
                }

                return false;
            }
            catch (Exception ex)
            {
                // Handle or log the exception
                throw new ApplicationException("Error updating order product", ex);
            }
        }
    }
}
