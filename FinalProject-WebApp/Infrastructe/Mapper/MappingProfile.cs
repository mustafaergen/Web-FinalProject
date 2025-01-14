using AutoMapper;
using FinalProject_Entities.DTOs;
using FinalProject_Entities.Models;

namespace FinalProject_WebApp.Infrastructe.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductCreateDTO, Product>().ReverseMap();
            CreateMap<ProductUpdateDTO, Product>().ReverseMap();
            CreateMap<ProductDTO,Product>().ReverseMap();
        }
    }
}
