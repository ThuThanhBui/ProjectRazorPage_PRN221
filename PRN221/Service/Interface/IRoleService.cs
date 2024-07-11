using Data.Entities;
using Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IRoleService
    {
        Task<RoleModel> getRoleByName(string roleName);
        Task<List<RoleModel>> GetAll();
    }
}
