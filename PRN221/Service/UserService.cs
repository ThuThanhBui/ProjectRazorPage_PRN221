﻿using AutoMapper;
using Data.Entities;
using Repository.Repository;
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
        public async Task<bool> AddUser(UserModel user)
        {
            try
            {
                var existingUser = await _userRepository.GetUserByEmail(user.Email);
                if (existingUser != null)
                {
                    return false; // User already exists
                }

                return await _userRepository.Add(_mapper.Map<User>(user));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<bool> Update(UserModel user)
        {
            try
            {
                return await _userRepository.Update(_mapper.Map<User>(user));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteUser(Guid id)
        {
            return await _userRepository.Delete(id);
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            var users = await _userRepository.GetAll();
            return _mapper.Map<List<UserModel>>(users);
        }

        public async Task<UserModel> GetById(Guid id)
        {
            try
            {
                return _mapper.Map<UserModel>(await _userRepository.GetById(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UserModel?> GetByEmail(string email)
        {
            try
            {
                var user = await _userRepository.GetUserByEmail(email);
                return _mapper.Map<UserModel>(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        //ThanhThu
        public Task<bool> UpdateProfile(UserModel user)
        {
            try
            {
                return _userRepository.UpdateProfile(_mapper.Map<User>(user));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
