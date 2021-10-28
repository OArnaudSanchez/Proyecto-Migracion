using AutoMapper;
using ProyectoMigracion.Core.DTOs;
using ProyectoMigracion.Core.Entities;

namespace ProyectoMigracion.Infrastructure.AutoMapper
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Persona, PersonaDTO>().ReverseMap();
        }
    }
}
