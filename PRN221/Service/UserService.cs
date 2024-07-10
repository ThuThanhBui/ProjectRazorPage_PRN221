using AutoMapper;
using Data.Entities;
using Repository.Repository.Interface;
using Service.Interface;
using Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
		{
			_userRepository = userRepository;
			_mapper = mapper;
		}

		public async Task<bool> Add(User user)
		{
			return await _userRepository.Add(user);
		}

		public async Task<User> Login(string email, string password)
		{
			return await _userRepository.Login(email, password);
		}



        //XuanViet
        //public async Task<bool> AddUser(UserModel user)
        //{
        //    try
        //    {
        //        var entity = _mapper.Map<User>(user);
        //        var result = await _userRepository.Add(entity);
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        public async Task<bool> DeleteUser(Guid id)
        {
            return await _userRepository.Delete(id);
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            var users = await _userRepository.GetAll();
            return _mapper.Map<List<UserModel>>(users);
        }

        public async Task<UserModel> GetUserById(Guid id)
        {
            var user = await _userRepository.GetById(id);
            return _mapper.Map<UserModel>(user);
        }
        
        public async Task<bool> UpdateUser(UserModel user)
        {
            var entity = _mapper.Map<User>(user);
            return await _userRepository.Update(entity);
        }
    }
}
