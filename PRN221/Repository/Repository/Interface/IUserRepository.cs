using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Interface
{
	public interface IUserRepository
	{
		Task<User> Login(string email, string password);
		Task<bool> Add(User user);
        Task<bool> Update(User user);
        Task<bool> Delete(Guid id);
        Task<List<User>> GetAll();
        Task<User> GetById(Guid id);
    }
}
