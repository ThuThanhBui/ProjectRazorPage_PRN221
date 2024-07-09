using AutoMapper;
using Data.Entities;
using Repository.Repository.Interface;
using Service.Interface;
using Service.Model;
using System.Security.Principal;

namespace Service
{
    public class VoucherService : IVoucherService
    {
        private readonly IVoucherRepository _repository;
        private readonly IMapper _mapper;

        public VoucherService(IVoucherRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Add(VoucherModel model)
        {
            try
            {
                return await _repository.Add(_mapper.Map<Voucher>(model));
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                return await _repository.Delete(id);
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

        public async Task<VoucherModel> GetById(Guid? id)
        {
            try
            {
                return  _mapper.Map<VoucherModel>(await _repository.GetById(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<VoucherModel>> GetVoucherByTypeId(Guid id)
        {
            try
            {
                return _mapper.Map<List<VoucherModel>>(await _repository.GetVoucherByTypeId(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Update(VoucherModel model)
        {
            try
            {
                return await _repository.Update(_mapper.Map<Voucher>(model));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
