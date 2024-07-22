using AutoMapper;
using Data.Entities;
using Repository.Repository;
using Repository.Repository.Interface;
using Service.Interface;
using Service.Model;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Principal;

namespace Service
{
    public class OrderXProductService : IOrderXProductService
    {
        private readonly IOrderXProductRepository _repository;
        private readonly IMapper _mapper;

        public OrderXProductService(IOrderXProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }



        public async Task<bool> Add(OrderXProductModel model)
        {
            try
            {
                return await _repository.Add(_mapper.Map<OrderXProduct>(model));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteAllByOrderId(Guid id)
        {
            try
            {
                return await _repository.DeleteAllByOrderId(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteOne(Guid oId, Guid pId)
        {
            try
            {
                return await _repository.DeleteOne(oId, pId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<OrderXProductModel> FindOne(Expression<Func<OrderXProduct, bool>> predicate)
        {
            try
            {
                return _mapper.Map<OrderXProductModel>(await _repository.FindOne(predicate));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<OrderXProductModel>> FindAll(Expression<Func<OrderXProduct, bool>> predicate)
        {
            try
            {
                return _mapper.Map<List<OrderXProductModel>>(await _repository.FindAll(predicate));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<OrderXProductModel>> GetByOrderId(Guid id)
        {
            try
            {
                return _mapper.Map<List<OrderXProductModel>>(await _repository.GetByOrderId(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<OrderXProductModel>> GetByProductId(Guid id)
        {
            try
            {
                return _mapper.Map<List<OrderXProductModel>>(await _repository.GetByProductId(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<OrderXProductModel> GetOne(Guid oId, Guid pId)
        {
            try
            {
                return _mapper.Map<OrderXProductModel>(await _repository.GetOne(oId, pId));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Update(OrderXProductModel model)
        {
            try
            {
                return await _repository.Update(_mapper.Map<OrderXProduct>(model));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
