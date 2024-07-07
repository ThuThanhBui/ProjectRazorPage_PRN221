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
            CreateMap<Blog, BlogModel>().ReverseMap();
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<Role, RoleModel>().ReverseMap();
            CreateMap<Product, ProductModel>().ReverseMap();
            CreateMap<ProductType, ProductTypeModel>().ReverseMap();
        }
    }
}
