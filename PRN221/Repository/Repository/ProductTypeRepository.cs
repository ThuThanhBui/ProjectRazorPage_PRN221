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
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly PRNDbContext _context;

        public ProductTypeRepository(PRNDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductType>> GetAll()
        {
            return await _context.ProductTypes.ToListAsync();
        }

        public async Task<ProductType> GetById(Guid id)
        {
            return await _context.ProductTypes.Where(o => o.id == id).SingleOrDefaultAsync();
        }

        public async Task<bool> Update(ProductType productType)
        {
            var o = await GetById(productType.id);
            o.productType = productType.productType;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Add(ProductType productType)
        {
            await _context.ProductTypes.AddAsync(productType);
            return await _context.SaveChangesAsync() > 0;
        }

        public Task<bool> DeleteById(Guid id)
        {
            throw new NotImplementedException();
        }

    }
}
