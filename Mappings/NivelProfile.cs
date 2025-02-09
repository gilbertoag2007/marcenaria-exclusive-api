using AutoMapper;
using MarcenariaExclusiveAPI.DTO;
using MarcenariaExclusiveAPI.Models;

namespace MarcenariaExclusiveAPI.Mappings
{
    public class NivelProfile: Profile
    {
        public NivelProfile()
        {
            CreateMap<NivelDto, Nivel>();
            CreateMap<Nivel, NivelDto>();
        }

    }
}
