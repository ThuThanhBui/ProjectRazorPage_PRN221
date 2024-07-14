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
            return await _context.Products.Include(o => o.ProductType).ToListAsync();
        }

        public async Task<Product> GetById(Guid id)
        {
            return await _context.Products.Where(o => o.Id == id).SingleOrDefaultAsync();
        }

        public async Task<bool> DeleteById(Guid id)
        {
            var o = await GetById(id);
            o.IsDeleted = true;

            return await _context.SaveChangesAsync() > 0;
        }


        public async Task<bool> Update(Product product)
        {
            var o = await GetById(product.Id);
            o.ProductName = product.ProductName;
            o.Price = product.Price;
            o.Brand = product.Brand;
            o.Image = product.Image;
            o.IsDeleted = product.IsDeleted;
            o.StockQuantity = product.StockQuantity;
            o.Description = product.Description;
            o.CreatedDate = product.CreatedDate;
            o.LastUpdatedDate = product.LastUpdatedDate;
            o.ProductTypeId = product.ProductTypeId;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Add(Product product)
        {
            await _context.Products.AddAsync(product);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Product>> GetByTypeId(Guid id)
        {
            return await _context.Products.Include(o => o.ProductType).Where(o => o.ProductTypeId == id).ToListAsync();

        }

        public async Task<List<string>> GetAllBrand()
        {
            return await _context.Products.Select(p => p.Brand).Distinct().ToListAsync();
        }

        public async Task<List<Product>> GetByBrand(string brand)
        {
            return await _context.Products.Where(p => p.Brand == brand) .ToListAsync();

        }

        public async Task<List<Product>> Search(string keyword)
        {
            return await _context.Products.Where(p => p.ProductName.ToLower().Contains(keyword.ToLower())).ToListAsync();
        }
    }
}
