using AutoMapper;
using Data.Entities;
using Repository.Repository.Interface;
using Service.Interface;
using Service.Model;
using System.Security.Principal;

namespace Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<bool> Add(OrderModel model)
        {
            try
            {
                return await _orderRepository.Add(_mapper.Map<Order>(model));
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
                return await _orderRepository.DeleteById(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<OrderModel>> GetAll()
        {
            try
            {
                return _mapper.Map<List<OrderModel>>(await _orderRepository.GetAll());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<OrderModel> GetById(Guid id)
        {
            try
            {
                return  _mapper.Map<OrderModel>(await _orderRepository.GetById(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<OrderModel>> GetByStatus(string Status)
        {
            try
            {
                return _mapper.Map<List<OrderModel>>(await _orderRepository.GetByStatus(Status));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Update(OrderModel model)
        {
            try
            {
                return await _orderRepository.Update(_mapper.Map<Order>(model));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
