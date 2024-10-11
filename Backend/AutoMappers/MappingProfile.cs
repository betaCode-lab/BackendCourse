using AutoMapper;
using Backend.DTOs.BeerDTOs;
using Backend.Models;

namespace Backend.AutoMappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BeerInsertDto, Beer>();
            CreateMap<BeerUpdateDto, Beer>();

            CreateMap<Beer, BeerDto>()
                .ForMember(dto => dto.Id, 
                            m => m.MapFrom(src => src.BeerID));
        }
    }
}
