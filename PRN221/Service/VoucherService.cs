using AutoMapper;
using Data.Entities;
using Repository.Repository;
using Repository.Repository.Interface;
using Service.Interface;
using Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class VoucherService : IVoucherService
    {
        private readonly IVoucherRepository _repository;
        private readonly IMapper _mapper;

        public VoucherService(IVoucherRepository repository , IMapper mapper) 
        { 
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> Add(VoucherModel voucher)
        {
            try
            {
                return await _repository.Add(_mapper.Map<Voucher>(voucher));
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
                return await _repository.DeleteById(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<VoucherModel>> GetAll()
        {
            try
            {
                return _mapper.Map<List<VoucherModel>>(await _repository.GetAll());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<VoucherTypeModel>> GetAllVoucherType()
        {
            try
            {
                return _mapper.Map<List<VoucherTypeModel>>(await _repository.GetAllVoucherType());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<VoucherModel> GetById(Guid id)
        {
            try
            {
                return _mapper.Map<VoucherModel>(await _repository.GetById(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Update(VoucherModel voucher)
        {
            try
            {
                return await _repository.Update(_mapper.Map<Voucher>(voucher));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
