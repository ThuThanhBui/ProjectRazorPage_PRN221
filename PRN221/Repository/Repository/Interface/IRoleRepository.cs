using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Interface
{
    public interface IRoleRepository
    {
        Task<Role> getRoleByName(string roleName);
        Task<List<Role>> GetAll();
    }
}
