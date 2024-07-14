using AutoMapper;
using Data.Entities;
using Repository.Repository.Interface;
using Service.Interface;
using Service.Model;
using System.Security.Principal;

namespace Service
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly IProductTypeRepository _productTypeRepository;
        private readonly IMapper _mapper;

        public ProductTypeService(IProductTypeRepository productTypeRepository, IMapper mapper)
        {
            _productTypeRepository = productTypeRepository;
            _mapper = mapper;
        }

        public async Task<bool> Add(ProductTypeModel model)
        {
            try
            {
                return await _productTypeRepository.Add(_mapper.Map<ProductType>(model));
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
                return await _productTypeRepository.DeleteById(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<ProductTypeModel>> GetAll()
        {
            try
            {
                return _mapper.Map<List<ProductTypeModel>>(await _productTypeRepository.GetAll());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ProductTypeModel> GetById(Guid id)
        {
            try
            {
                return  _mapper.Map<ProductTypeModel>(await _productTypeRepository.GetById(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Update(ProductTypeModel model)
        {
            try
            {
                return await _productTypeRepository.Update(_mapper.Map<ProductType>(model));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
