using Data.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Repository.Interface
{
    public interface IUserRepository
    {
        Task<bool> Add(User user);
        Task<bool> Delete(Guid id);
        Task<List<User>> GetAll();
        Task<User> GetById(Guid id);
        Task<bool> Update(User user);
    }
}
