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
    public class OrderXProductRepository : IOrderXProductRepository
    {
        private readonly PRNDbContext _context;

        public OrderXProductRepository(PRNDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(OrderXProduct op)
        {
            await _context.OrderXProducts.AddAsync(op);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAllByOrderId(Guid id)
        {
            foreach (var op in _context.OrderXProducts)
            {
                if(op.orderId == id)
                {
                    _context.OrderXProducts.Remove(op);
                }
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteOne(Guid oId, Guid pId)
        {
            var op = await _context.OrderXProducts.Where(op => 
                                op.orderId == oId && op.productId == pId).FirstOrDefaultAsync();
            _context.OrderXProducts.Remove(op);
            return await _context.SaveChangesAsync() > 0;

        }

        public async Task<List<OrderXProduct>> GetByOrderId(Guid id)
        {
            return await _context.OrderXProducts.Where(op => op.orderId == id).Include(op => op.Product).ToListAsync();
        }

        public async Task<List<OrderXProduct>> GetByProductId(Guid id)
        {
            return await _context.OrderXProducts.Where(op => op.productId == id).ToListAsync();
        }

        public async Task<OrderXProduct> GetOne(Guid oId, Guid pId)
        {
            return await _context.OrderXProducts.Where(op => op.orderId == oId && op.productId ==pId)
                .Include(op => op.Order).Include(op => op.Product).FirstOrDefaultAsync();
        }

        public async Task<bool> Update(OrderXProduct op)
        {
            var getOp = await GetOne(op.orderId, op.productId);
            getOp.quantity = op.quantity;

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
