using AutoMapper;
using MarcenariaExclusiveAPI.DTO;
using MarcenariaExclusiveAPI.Models;

namespace MarcenariaExclusiveAPI.Mappings
{
    public class ArmarioProfile: Profile
    {
        public ArmarioProfile()
        {
            CreateMap<ArmarioDto, Armario>();
            CreateMap<Armario, ArmarioDto>();
        }

    }
}
