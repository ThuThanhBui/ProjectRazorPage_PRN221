using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Interface
{
    public interface IProductTypeRepository
    {
        Task<List<ProductType>> GetAll();
        Task<ProductType> GetById(Guid id);
        Task<bool> Add(ProductType productType);
        Task<bool> DeleteById(Guid id);
        Task<bool> Update(ProductType productType);
    }
}
