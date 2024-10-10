using AutoMapper;
using ContentManagementAPI.DTOs;
using ContentManagementAPI.Models;

namespace ContentManagementAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Content, ContentDto>().ReverseMap(); 
            CreateMap<ApplicationUser, RegisterResponseDto>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id));
        }
    }
}