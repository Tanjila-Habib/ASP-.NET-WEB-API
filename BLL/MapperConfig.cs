using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;

namespace BLL
{
    public class MapperConfig
    {
        static MapperConfiguration cfg = new MapperConfiguration(c => {
            c.CreateMap<Appointment, AppointmentDTO>().ReverseMap();
            c.CreateMap<AppointmentCreateDTO, Appointment>()
        .ForMember(d => d.User, opt => opt.Ignore())
        .ForMember(d => d.Professional, opt => opt.Ignore());

            c.CreateMap<UserDTO, User>().ReverseMap();
            c.CreateMap<UserCreateDTO, User>().ReverseMap();
            c.CreateMap<ProfessionalDTO, Professional>().ReverseMap();
            c.CreateMap<ProfessionalCreateDTO,ProfessionalDTO>().ReverseMap();
            c.CreateMap<ProfessionalCreateDTO,Professional>().ReverseMap();

        });
        public static Mapper GetMapper()
        {
            return new Mapper(cfg);
        }
}
}
