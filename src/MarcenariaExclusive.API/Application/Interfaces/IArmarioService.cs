using MarcenariaExclusive.API.Domain.Entities;
using MarcenariaExclusiveAPI.Domain.Entities;

namespace MarcenariaExclusiveAPI.Application.Interfaces
{
    public interface IArmarioService
    {

        public PlanoCorte CalcularPlanoCorte(Armario armario);
    }
}