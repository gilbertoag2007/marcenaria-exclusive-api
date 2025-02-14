using MarcenariaExclusive.API.Domain.Exceptions;
using MarcenariaExclusiveAPI.Application.Interfaces;
using MarcenariaExclusiveAPI.Domain.Entities;


namespace MarcenariaExclusiveAPI.Infrastructure.Services
{
    public class ArmarioService : IArmarioService
    {

        public void CalcularPlanoCorte( Armario armario)
        {

            Console.WriteLine("CHEGOU NO SERVICE.");
            throw new DimensoesException(" AS ESPECIFICAÇÕES ESTÃO FORA DE UMA PROPORÇÃO RAZOAVEL PARA O PROJETO");




        }



        private void CalcularPecasLaterais(Armario armario)
        {
            // Calcula os niveis do armario
        }


    }
}
