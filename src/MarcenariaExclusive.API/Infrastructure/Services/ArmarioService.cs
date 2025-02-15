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
          //  throw new DimensoesException(" AS ESPECIFICAÇÕES ESTÃO FORA DE UMA PROPORÇÃO RAZOAVEL PARA O PROJETO");

PlanoCorte planoCorte = new PlanoCorte();
planoCorte.Armario = armário;

Peca laterais = new Peca(armario.Largura, armário.Altura, Espessura.Milimetros15,2 FinalidadePeca.Lateral);

Peca base = new Peca(armario.Largura -3, armário.Altura, Espessura.Milimetros15,1 FinalidadePeca.Base);// redução de 3cm por conta da espessura das duas peças laterais

Peca topo = new Peca(armario.Largura -3, armário.Altura, Espessura.Milimetros15,1 FinalidadePeca.Topo);// redução de 3cm por conta da espessura das duas peças laterais

Peca acabamentoInferior = new Peca(armario.Largura, 7, Espessura.Milimetros15,1 FinalidadePeca.AcabamentoInferior);

Peca acabamentoSuperior = new Peca(armario.Largura, 7, Espessura.Milimetros15,1 FinalidadePeca.AcabamentoSuperior);

Peca fundo = new Peca(armario.Largura, armário.Altura, Espessura.Milimetros6,1 FinalidadePeca.Fundo);
        }

/// <summary>
/// Calcula a altura de um nível dentro do armário com base na altura total e no percentual de espaço utilizado.
/// </summary>
/// <param name="alturaArmario">A altura total do armário em centímetros.</param>
/// <param name="percentualEspaco">O percentual de espaço ocupado pelo nível dentro do armário.</param>
/// <returns>A altura correspondente do nível em centímetros.</returns>
public double CalcularAlturaNivel(int alturaArmario, double percentualEspaco)
{
    return (alturaArmario * percentualEspaco / 100);
}


        private void CalcularPecasLaterais(Armario armario)
        {
            // Calcula os niveis do armario
        }


    }
}
