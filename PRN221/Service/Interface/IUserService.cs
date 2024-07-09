using Service.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IUserService
    {
        Task<bool> AddUser(UserModel user);
        Task<bool> DeleteUser(Guid id);
        Task<List<UserModel>> GetAllUsers();
        Task<UserModel> GetUserById(Guid id);
        Task<bool> UpdateUser(UserModel user);
    }
}
