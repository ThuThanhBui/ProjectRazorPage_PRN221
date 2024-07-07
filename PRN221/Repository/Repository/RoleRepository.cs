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
    public class RoleRepository : IRoleRepository
    {
        private readonly PRNDbContext _context;
        public RoleRepository(PRNDbContext context)
        {
            _context = context;
        }
        public async Task<Role> getRoleByName(string roleName)
        {
            return await _context.Roles.Where(r => r.roleName == roleName).FirstOrDefaultAsync();
        }
    }
}
