using MarcenariaExclusive.API.Application.DTOs;
using MarcenariaExclusive.API.Domain.Entities;
using MarcenariaExclusiveAPI.Application.DTOs;
using MarcenariaExclusiveAPI.Domain.Entities;

namespace MarcenariaExclusiveAPI.Application.Interfaces
{
    public interface IArmarioService
    {
        public PlanoCorteDto CalcularPlanoCorte(Armario armario);

        public double CalcularLarguraPorta(int larguraArmario, PortaDto portaDto);

        public double CalcularAlturaPorta(ArmarioDto armarioDto, PortaDto portaDto);
    }
}