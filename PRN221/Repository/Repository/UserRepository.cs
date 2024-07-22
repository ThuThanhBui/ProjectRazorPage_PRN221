using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly PRNDbContext _context;

        public UserRepository(PRNDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> Add(User user)
        {
            try
            {
                if (user == null)
                {
                    throw new ArgumentNullException(nameof(user));
                }

                var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
                if (existingUser != null)
                {
                    return false; // User already exists
                }

                await _context.Users.AddAsync(user);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error adding user", ex);
            }
        }

        public async Task<User> Login(string email, string password)
        {
            try
            {
                var user = await _context.Users
                    .Where(u => u.Email == email && u.Password == password)
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync();

                return user;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error during login", ex);
            }
        }

        public async Task<bool> Update(User user)
        {
            try
            {
                var existingUser = await GetById(user.Id);
                if (existingUser == null)
                {
                    return false; // User not found
                }

                // Update properties
                existingUser.FullName = user.FullName;
                existingUser.Email = user.Email;
                existingUser.IsDeleted = user.IsDeleted;
                existingUser.Telephone = user.Telephone;
                existingUser.Gender = user.Gender;
                existingUser.Address = user.Address;
                existingUser.RoleId = user.RoleId;
                existingUser.CreatedDate = user.CreatedDate;
                existingUser.LastUpdatedDate = user.LastUpdatedDate;

                _context.Users.Update(existingUser);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error updating user", ex);
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                var user = await GetById(id);
                if (user == null)
                {
                    return false; // User not found
                }

                user.IsDeleted = true;
                _context.Users.Update(user);
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error deleting user", ex);
            }
        }

        public async Task<List<User>> GetAll()
        {
            try
            {
                return await _context.Users.Include(u => u.Role).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error retrieving all users", ex);
            }
        }

        public async Task<User> GetById(Guid id)
        {
            try
            {
                return await _context.Users.Include(u => u.Role).Where(u => u.Id == id).SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error retrieving user by Id: {id}", ex);
            }
        }

        public async Task<bool> UpdateProfile(User user)
        {
            try
            {
                var o = await GetById(user.Id);
                if (user.Image != null)
                {
                    o.Image = user.Image;
                }
                o.FullName = user.FullName;
                o.Telephone = user.Telephone;
                o.Address = user.Address;
                o.Dob = user.Dob;
                o.Gender = user.Gender;
                o.Email = user.Email;
                o.Password = user.Password;
                o.LastUpdatedDate = user.LastUpdatedDate;

                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            try
            {
                return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error checking for existing user", ex);
            }
        }
    }
}
