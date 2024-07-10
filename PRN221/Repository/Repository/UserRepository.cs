﻿using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
	public class UserRepository : IUserReposiroty
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
	}
}