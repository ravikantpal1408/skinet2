using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDTO>()
                .ForMember(destination => destination.ProductBrand, source => source.MapFrom(final => final.ProductBrand.Name))
                .ForMember(destination => destination.ProductType, source => source.MapFrom(final => final.ProductType.Name));
        }
    }
}