using AutoMapper;
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
    public class RoleService : IRoleService
    {
        private readonly IMapper _mapper;
        private readonly IRoleRepository _roleRepository;

        public RoleService(IMapper mapper, IRoleRepository roleRepository)
        {
            _mapper = mapper;
            _roleRepository = roleRepository;
        }

        public async Task<RoleModel> getRoleByName(string roleName)
        {
            try
            {
                return _mapper.Map<RoleModel>(await _roleRepository.getRoleByName(roleName));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<RoleModel>> GetAll()
        {
            try
            {
                return _mapper.Map<List<RoleModel>>(await _roleRepository.GetAll());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
