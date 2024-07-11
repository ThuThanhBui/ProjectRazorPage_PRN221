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
	public class UserRepository : IUserRepository
	{
		private readonly PRNDbContext context;

		public UserRepository(PRNDbContext _context) 
		{
			context = _context;
		}

		public async Task<bool> Add(User user)
		{
			try
			{
                if (user == null)
                {
                    throw new ArgumentNullException(nameof(user));
                }
                var existingUser = await context.Users.FirstOrDefaultAsync(u => u.email == user.email);
                if (existingUser != null)
                {
                    return false;
                }

                await context.Users.AddAsync(user);
				return await context.SaveChangesAsync() > 0;

				return true;
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}

		public async Task<User> Login(string email, string password)
		{
			try
			{
				var user = await context.Users.Where(u => u.email == email && u.password == password).Include(m => m.Role).FirstOrDefaultAsync();

				return user;
			} catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

        //XuanViet
        public async Task<bool> Update(User user)
        {
            var u = await GetById(user.id);
            u.fullName = user.fullName;
            u.email = user.email;
            u.isDeleted = user.isDeleted;
            u.telephone = user.telephone;
            u.gender = user.gender;
            u.address = user.address;
            u.roleId = user.roleId;
            u.createdDate = user.createdDate;
            u.updatedDate = user.updatedDate;

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(Guid id)
        {
            var user = await GetById(id);
            if (user == null)
            {
                return false;
            }

            user.isDeleted = true;
            context.Users.Update(user);
            return await context.SaveChangesAsync() > 0;
        }
            
        public async Task<List<User>> GetAll()
        {
            return await context.Users.Include(u => u.Role).ToListAsync();
        }

        public async Task<List<User>> GetPagedUsers(int pageIndex, int pageSize)
        {
            return await context.Users.Include(u => u.Role)
                                      .OrderByDescending(u => u.updatedDate)
                                      .Skip((pageIndex - 1) * pageSize)
                                      .Take(pageSize)
                                      .ToListAsync();
        }

        public async Task<User> GetById(Guid id)
        {
            return await context.Users.Where(u => u.id == id).SingleOrDefaultAsync();
        }

    }
}
