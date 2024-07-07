using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Interface
{
	public interface IUserReposiroty
	{
		Task<User> Login(string email, string password);
		Task<bool> Add(User user);
	}
}
