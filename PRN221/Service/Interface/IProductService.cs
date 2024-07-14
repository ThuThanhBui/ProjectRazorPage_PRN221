using Data.Entities;
using Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IProductService
    {
        Task<List<ProductModel>> GetAll();
        Task<List<ProductModel>> GetByTypeId(Guid id);
        Task<List<string>> GetAllBrand();
        Task<List<ProductModel>> GetByBrand(string brand);
        Task<ProductModel> GetById(Guid id);
        Task<bool> Add(ProductModel model);
        Task<bool> DeleteById(Guid id);
        Task<bool> Update(ProductModel model);
        Task<List<ProductModel>> Search(string keyword);

    }
}
