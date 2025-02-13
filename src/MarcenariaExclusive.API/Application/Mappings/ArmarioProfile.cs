using AutoMapper;
using MarcenariaExclusiveAPI.Application.DTOs;
using MarcenariaExclusiveAPI.Domain.Entities;

namespace MarcenariaExclusiveAPI.Application.Mappings
{
    public class ArmarioProfile : Profile
    {
        public ArmarioProfile()
        {
            CreateMap<ArmarioDto, Armario>();
            CreateMap<Armario, ArmarioDto>();
        }

    }
}
