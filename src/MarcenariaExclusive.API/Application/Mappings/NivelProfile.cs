using AutoMapper;
using MarcenariaExclusiveAPI.Application.DTOs;
using MarcenariaExclusiveAPI.Domain.Entities;

namespace MarcenariaExclusiveAPI.Application.Mappings
{
    public class NivelProfile : Profile
    {
        public NivelProfile()
        {
            CreateMap<NivelDto, Nivel>();
            CreateMap<Nivel, NivelDto>();
        }

    }
}
