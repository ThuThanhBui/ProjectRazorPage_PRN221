using Data.Entities;
using Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IProductTypeService
    {
        Task<List<ProductTypeModel>> GetAll();
        Task<ProductTypeModel> GetById(Guid id);
        Task<bool> Add(ProductTypeModel model);
        Task<bool> DeleteById(Guid id);
        Task<bool> Update(ProductTypeModel model);
    }
}
