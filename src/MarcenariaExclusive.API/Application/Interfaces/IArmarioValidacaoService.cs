using MarcenariaExclusive.API.Domain.Entities;
using MarcenariaExclusiveAPI.Domain.Entities;

namespace MarcenariaExclusive.API.Application.Interfaces
{
    public interface IArmarioValidacaoService
    {

        public void ValidarEspecificacoesArmario(Armario armario);
    }
}
