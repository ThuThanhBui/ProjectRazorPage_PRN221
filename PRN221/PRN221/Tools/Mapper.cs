using AutoMapper;
using Data.Entities;
using Service.Model;

namespace PRN221.Tools
{
    public class Mapper: Profile
    {
        public Mapper()
        {
            CreateMap<Order, OrderModel>().ReverseMap();
        }
    }
}
