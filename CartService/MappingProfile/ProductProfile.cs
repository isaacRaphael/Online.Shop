using AutoMapper;
using CartApp.DTOs.Incoming;
using CartApp.Models;

namespace CartApp.MappingProfile
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
