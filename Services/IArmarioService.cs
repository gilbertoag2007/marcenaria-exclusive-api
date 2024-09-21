using MarcenariaExclusiveAPI.Models;

namespace MarcenariaExclusiveAPI.Services
{
    public interface IArmarioService
    {
        public PlanoDTO CalcularPlanoCorte(MovelDTO movel);

    }
}
