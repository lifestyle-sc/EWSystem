using AutoMapper;
using Entities.Models;
using Shared.DTOs;

namespace EWApp
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserForRegistrationDto, User>();

            CreateMap<User, UserDto>();

            CreateMap<WaterSampleForCreationDto, WaterSample>();

            CreateMap<WaterSample, WaterSampleDto>();

            CreateMap<WaterSampleForUpdateDto, WaterSample>().ReverseMap();
        }
    }
}
