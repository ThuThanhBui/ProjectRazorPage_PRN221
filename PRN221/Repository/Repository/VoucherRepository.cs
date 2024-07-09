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
    public class VoucherRepository : IVoucherRepository
    {
        private readonly PRNDbContext _context;

        public VoucherRepository(PRNDbContext context)
        {
            _context = context;
        }

        public async Task<List<Voucher>> GetAll()
        {
            return await _context.Vouchers.ToListAsync();
        }

        public async Task<Voucher> GetById(Guid? id)
        {
            return await _context.Vouchers.Where(o => o.id == id).SingleOrDefaultAsync();
        }

        public async Task<List<Voucher>> GetVoucherByTypeId(Guid id)
        {
            return await _context.Vouchers.Where(v => v.voucherTypeId == id).ToListAsync();
        }

        public async Task<bool> Delete(Guid id)
        {
            var o = await GetById(id);

            _context.Vouchers.Remove(o);

            return await _context.SaveChangesAsync() > 0;
        }


        public async Task<bool> Update(Voucher voucher)
        {
            var o = await GetById(voucher.id);
            o.content = voucher.content;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Add(Voucher voucher)
        {
            await _context.Vouchers.AddAsync(voucher);
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
