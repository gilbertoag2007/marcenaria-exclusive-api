using MarcenariaExclusive.API.Domain.Entities;
using MarcenariaExclusive.API.Domain.Enums;
using MarcenariaExclusive.API.Domain.Exceptions;
using MarcenariaExclusiveAPI.Application.Interfaces;
using MarcenariaExclusiveAPI.Domain.Entities;


namespace MarcenariaExclusiveAPI.Infrastructure.Services
{
    public class ArmarioService : IArmarioService
    {

        public void CalcularPlanoCorte(Armario armario)
        {

            Console.WriteLine("CHEGOU NO SERVICE.");
            //  throw new DimensoesException(" AS ESPECIFICAÇÕES ESTÃO FORA DE UMA PROPORÇÃO RAZOAVEL PARA O PROJETO");

            PlanoCorte planoCorte = new PlanoCorte();
            planoCorte.Armario = armario;

            planoCorte.Pecas.Add(
             new Peca(armario.Largura, armario.Altura, Espessura.Milimetros15, 2, FinalidadePeca.Lateral));

            planoCorte.Pecas.Add(
            new Peca(armario.Largura - 3, armario.Altura, Espessura.Milimetros15, 1, FinalidadePeca.Base));// redução de 3cm por conta da espessura das duas peças laterais

            planoCorte.Pecas.Add(
             new Peca(armario.Largura - 3, armario.Altura, Espessura.Milimetros15, 1, FinalidadePeca.Topo));// redução de 3cm por conta da espessura das duas peças laterais

            planoCorte.Pecas.Add(
             new Peca(armario.Largura, 7, Espessura.Milimetros15, 1, FinalidadePeca.AcabamentoInferior));

            planoCorte.Pecas.Add(
            new Peca(armario.Largura, 7, Espessura.Milimetros15, 1, FinalidadePeca.AcabamentoSuperior));

            planoCorte.Pecas.Add(
            new Peca(armario.Largura, armario.Altura, Espessura.Milimetros6, 1, FinalidadePeca.FundoArmario));

            int quantidadeDivisaoNivel = armario.Niveis.Count - 1;// define quantidade de chapas para separar um nivel de outro.

            foreach (var nivel in armario.Niveis)
            {

                if (quantidadeDivisaoNivel > 0)
                {
                    planoCorte.Pecas.Add(new Peca(armario.Profundidade, nivel.AlturaNivel, Espessura.Milimetros15, quantidadeDivisaoNivel, FinalidadePeca.DivisaoInterna));
                }

                if ( nivel.QuantidadePortas > 0)
                {
                    if (nivel.QuantidadePortas == 1)
                    {
                        planoCorte.Pecas.Add(
                        new Peca(armario.Largura - 1, nivel.AlturaNivel - 1, Espessura.Milimetros15, 1, FinalidadePeca.PortaNivel));// redução de 1cm na largura e altura para gerar um recuo de 0,5 centímetros em cada lado da porta.
                    }
                    else
                    {
                        double larguraPorta = CalcularLarguraPorta(armario.Largura, nivel.QuantidadePortas); // largura de cada porta
                        planoCorte.Pecas.Add(new Peca(larguraPorta, nivel.AlturaNivel - 1, Espessura.Milimetros15, nivel.QuantidadePortas, FinalidadePeca.PortaNivel));// redução de 1cm na largura e altura para gerar um recuo de 0,5 centímetros em cada lado da porta.

                    }

                }

            }
        }


    // Calcula a largura de cada porta considerando a largura do armario e descontando 1 cm para dar um recuo de 0.5 cm em cada lado de casa porta.
    public double CalcularLarguraPorta(int larguraArmario, int quantidadePortas)
    {
        return ( (larguraArmario - 1) / quantidadePortas);
    }



/// <summary>
/// Calcula a altura de um nivel dentro do armario com base na altura total e no percentual de espaço utilizado.
/// </summary>
/// <param name="alturaArmario">A altura total do armario em centímetros.</param>
/// <param name="percentualEspaco">O percentual de espaço ocupado pelo nivel dentro do armario.</param>
/// <returns>A altura correspondente do nivel em centímetros.</returns>



        public List<Peca> CalcularPecaGavetas(int alturaNivel, int larguraArmario,int quantidadeGavetas, int profundidadeArmario, Nivel nivel)
        {
            List<Peca> pecaGavetas = new List<Peca>();
            // Faces das gavetas
            
            double alturaGaveta= alturaNivel / quantidadeGavetas;// altura da face de cada gaveta

            pecaGavetas.Add(new Peca(larguraArmario -1, alturaGaveta, Espessura.Milimetros15,nivel.QuantidadeGavetas, FinalidadePeca.FaceGaveta));// redução de 1cm na largura de cada face da gaveta para gerar um recuo de 0,5 centímetros em cada.

            // Laterais Gavetas

            double alturaLateriasGavetas = alturaGaveta * 0.70;

            int larguraLateralGaveta = profundidadeArmario - 1;

            pecaGavetas.Add(new Peca( larguraLateralGaveta , alturaLateriasGavetas, Espessura.Milimetros15,nivel.QuantidadeGavetas * 2, FinalidadePeca.LateralGaveta));// redução de 1cm na largura da lateral e 30% na altura de cada lateral da gaveta.


            int larguraTraseiraGaveta = larguraArmario -8;
            // traseira gavetas

            pecaGavetas.Add(new Peca(   larguraTraseiraGaveta , alturaLateriasGavetas, Espessura.Milimetros15,nivel.QuantidadeGavetas, FinalidadePeca.TraseiraGaveta));// redução de 3 cm correspondente  a espessura da lateral do armario e lateral da gaveta mais 1 cm do trilho para os dois lados da gaveta totalizando 8 cm.

            // Fundo Gaveta
            pecaGavetas.Add(new Peca(larguraTraseiraGaveta +3,   larguraLateralGaveta + 0.5 , Espessura.Milimetros6,nivel.QuantidadeGavetas, FinalidadePeca.TraseiraGaveta));

            return pecaGavetas;
        }


    }
}
