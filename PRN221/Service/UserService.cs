using AutoMapper;
using Data.Entities;
using Repository.Repository.Interface;
using Service.Interface;
using Service.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> AddUser(UserModel user)
        {
            try
            {
                var entity = _mapper.Map<User>(user);
                var result = await _repository.Add(entity);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteUser(Guid id)
        {
            return await _repository.Delete(id);
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            var users = await _repository.GetAll();
            return _mapper.Map<List<UserModel>>(users);
        }

        public async Task<UserModel> GetUserById(Guid id)
        {
            var user = await _repository.GetById(id);
            return _mapper.Map<UserModel>(user);
        }

        public async Task<bool> UpdateUser(UserModel user)
        {
            var entity = _mapper.Map<User>(user);
            return await _repository.Update(entity);
        }
    }
}
