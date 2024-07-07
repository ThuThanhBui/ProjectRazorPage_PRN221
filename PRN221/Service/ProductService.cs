using AutoMapper;
using Data.Entities;
using Repository.Repository.Interface;
using Service.Interface;
using Service.Model;
using System.Security.Principal;

namespace Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<bool> Add(ProductModel model)
        {
            try
            {
                return await _productRepository.Add(_mapper.Map<Product>(model));
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteById(Guid id)
        {
            try
            {
                return await _productRepository.DeleteById(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ProductModel>> GetAll()
        {
            try
            {
                return _mapper.Map<List<ProductModel>>(await _productRepository.GetAll());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProductModel> GetById(Guid id)
        {
            try
            {
                return  _mapper.Map<ProductModel>(await _productRepository.GetById(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ProductModel>> GetByTypeId(Guid id)
        {
            try
            {
                return _mapper.Map<List<ProductModel>>(await _productRepository.GetByTypeId(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Update(ProductModel model)
        {
            try
            {
                return await _productRepository.Update(_mapper.Map<Product>(model));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
