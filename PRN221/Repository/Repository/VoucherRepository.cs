using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class VoucherRepository : IVoucherRepository
    {
        private readonly PRNDbContext _context;

        public VoucherRepository(PRNDbContext context) {
            _context = context;
        }

        public async Task<bool> Add(Voucher voucher)
        {
            await _context.Vouchers.AddAsync(voucher);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteById(Guid id)
        {
            Voucher voucher = await GetById(id);
            voucher.IsDeleted = true;
            _context.Vouchers.Update(voucher);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Voucher>> GetAll()
        {
            List<Voucher> list = await _context.Vouchers.ToListAsync();
            return list;
        }

        public async Task<List<VoucherType>> GetAllVoucherType()
        {
          List<VoucherType> vouchers = await _context.VoucherTypes.ToListAsync();
            return vouchers;
        }

        public async Task<Voucher> GetById(Guid id)
        {
            return await _context.Vouchers.Where(m => m.Id == id).Include(m => m.VoucherType).SingleOrDefaultAsync();
        }

        public async Task<bool> Update(Voucher voucher)
        {
            _context.Vouchers.Update(voucher);
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
