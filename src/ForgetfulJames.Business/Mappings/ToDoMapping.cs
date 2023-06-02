using AutoMapper;
using ForgetfulJames.Domain.Entities;
using ForgetfulJames.Dto.Entities;

namespace ForgetfulJames.Business.Mappings
{
    public class ToDoMapping : Profile
    {
        public ToDoMapping() 
        {
            CreateMap<ToDoDto, ToDo>()
                .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.DueDate))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Starred, opt => opt.MapFrom(src => src.Starred))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));

            CreateMap<ToDo, ToDoDto>()
                .ForPath(dest => dest.DueDate, opt => opt.MapFrom(src => src.DueDate))
                .ForPath(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForPath(dest => dest.Image, opt => opt.MapFrom(src => src.Image))
                .ForPath(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForPath(dest => dest.Starred, opt => opt.MapFrom(src => src.Starred))
                .ForPath(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));
        }
    }
}
