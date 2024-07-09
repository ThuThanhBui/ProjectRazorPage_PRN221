﻿using AutoMapper;
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
            CreateMap<Product, ProductModel>().ReverseMap();
            CreateMap<ProductType, ProductTypeModel>().ReverseMap();
            CreateMap<Voucher, VoucherModel>().ReverseMap();
            CreateMap<OrderXProduct, OrderXProductModel>().ReverseMap();
        }
    }
}
