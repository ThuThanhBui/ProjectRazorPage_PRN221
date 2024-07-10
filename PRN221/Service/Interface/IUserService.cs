using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
	public interface IUserService
	{
		Task<User> Login(string email, string password);
		Task<bool> Add(User user);
	}
}
