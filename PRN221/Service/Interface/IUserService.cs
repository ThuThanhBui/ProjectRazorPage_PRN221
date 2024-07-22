using Data.Entities;
using Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
	public interface IUserService
	{
        //Khoi
		Task<User> Login(string email, string password);
		Task<bool> Add(User user);

        //XuanViet
        Task<bool> AddUser(UserModel user);
        Task<bool> Update(UserModel user);
        Task<bool> DeleteUser(Guid id);
        Task<List<UserModel>> GetAllUsers();
        Task<UserModel> GetById(Guid id);
        Task<UserModel?> GetByEmail(string email);

        //Thu
        Task<bool> UpdateProfile(UserModel user);
    }
}
