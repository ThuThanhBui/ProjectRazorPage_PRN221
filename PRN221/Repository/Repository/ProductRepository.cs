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
    public class ProductRepository : IProductRepository
    {
        private readonly PRNDbContext _context;

        public ProductRepository(PRNDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _context.Products.Include(o => o.productType).ToListAsync();
        }

        public async Task<Product> GetById(Guid id)
        {
            return await _context.Products.Where(o => o.id == id).SingleOrDefaultAsync();
        }

        public async Task<bool> DeleteById(Guid id)
        {
            var o = await GetById(id);
            o.isDeleted = true;

            return await _context.SaveChangesAsync() > 0;
        }


        public async Task<bool> Update(Product product)
        {
            var o = await GetById(product.id);
            o.name = product.name;
            o.price = product.price;
            o.isDeleted = product.isDeleted;
            o.stockQuantity = product.stockQuantity;
            o.description = product.description;
            o.createdDate = product.createdDate;
            o.updatedDate = product.updatedDate;
            o.productTypeId = product.productTypeId;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Add(Product product)
        {
            await _context.Products.AddAsync(product);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Product>> GetByTypeId(Guid id)
        {
            return await _context.Products.Include(o => o.productType).Where(o => o.productTypeId == id).ToListAsync();

        }
    }
}
