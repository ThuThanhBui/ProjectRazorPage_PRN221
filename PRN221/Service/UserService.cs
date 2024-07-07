using AutoMapper;
using Data.Entities;
using Repository.Repository.Interface;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
	public class UserService : IUserService
	{
		private readonly IUserReposiroty _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserReposiroty userRepository, IMapper mapper)
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
	}
}
