﻿using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Interface
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll();
        Task<List<Product>> GetByTypeId(Guid id);
        Task<List<string>> GetAllBrand();
        Task<List<Product>> GetByBrand(string brand);
        Task<Product> GetById(Guid id);
        Task<bool> Add(Product product);
        Task<bool> DeleteById(Guid id);
        Task<bool> Update(Product product);
        Task<List<Product>> Search(string keyword);
    }
}
