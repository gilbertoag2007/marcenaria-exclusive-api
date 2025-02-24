using MarcenariaExclusive.API.Domain.Entities;
using MarcenariaExclusive.API.Domain.Enums;
using MarcenariaExclusive.API.Domain.Exceptions;
using MarcenariaExclusiveAPI.Application.Interfaces;
using MarcenariaExclusiveAPI.Domain.Entities;


namespace MarcenariaExclusiveAPI.Infrastructure.Services
{
    public class ArmarioService : IArmarioService
    {

        public PlanoCorte CalcularPlanoCorte(Armario armario)
        {

            Console.WriteLine("CHEGOU NO SERVICE.");
            //  throw new DimensoesException(" AS ESPECIFICAÇÕES ESTÃO FORA DE UMA PROPORÇÃO RAZOAVEL PARA O PROJETO");

            PlanoCorte planoCorte = new PlanoCorte();
            planoCorte.Armario = armario;

            planoCorte.Pecas.Add(
             new Peca(armario.Profundidade, armario.Altura, Espessura.Milimetros15, 2, FinalidadePeca.Lateral));

            planoCorte.Pecas.Add(
            new Peca(armario.Largura - 3, armario.Profundidade, Espessura.Milimetros15, 1, FinalidadePeca.Base));// redução de 3cm por conta da espessura das duas peças laterais

            planoCorte.Pecas.Add(
             new Peca(armario.Largura - 3, armario.Profundidade, Espessura.Milimetros15, 1, FinalidadePeca.Topo));// redução de 3cm por conta da espessura das duas peças laterais

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
                    planoCorte.Pecas.Add(
                    new Peca(armario.Profundidade, armario.Largura - 3, Espessura.Milimetros15, quantidadeDivisaoNivel, FinalidadePeca.DivisaoInterna));
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
                        
                        planoCorte.Pecas.Add(
                        new Peca(larguraPorta, nivel.AlturaNivel - 1, Espessura.Milimetros15, nivel.QuantidadePortas, FinalidadePeca.PortaNivel));// redução de 1cm na largura e altura para gerar um recuo de 0,5 centímetros em cada lado da porta.

                    }

                }
                if (nivel.QuantidadeGavetas > 0)
                {
                planoCorte.Pecas.AddRange(CalcularPecaGavetas(nivel.AlturaNivel, armario.Largura, nivel.QuantidadeGavetas, armario.Profundidade, nivel));
                }


                }
            return planoCorte;
        }


    // Calcula a largura de cada porta considerando a largura do armario e descontando 1 cm para dar um recuo de 0.5 cm em cada lado de casa porta.
    public double CalcularLarguraPorta(int larguraArmario, int quantidadePortas)
    {
        return ( (larguraArmario - 1) / quantidadePortas);
    }



        public List<Peca> CalcularPecaGavetas(double alturaNivel, int larguraArmario,int quantidadeGavetas, int profundidadeArmario, Nivel nivel)
        {
            List<Peca> pecaGavetas = new List<Peca>();
            // Faces das gavetas
            
            double alturaGaveta= (alturaNivel / quantidadeGavetas)  ;// altura da face de cada gaveta descontando 0.2 entre cada gaveta

            pecaGavetas.Add(new Peca(larguraArmario -1, alturaGaveta, Espessura.Milimetros15,nivel.QuantidadeGavetas, FinalidadePeca.FaceGaveta));// redução de 1cm na largura de cada face da gaveta para gerar um recuo de 0,5 centímetros em cada.

            // Laterais Gavetas

            double alturaLateriasGavetas = alturaGaveta * 0.70;

            int larguraLateralGaveta = profundidadeArmario - 1;

            pecaGavetas.Add(
            new Peca( larguraLateralGaveta , alturaLateriasGavetas, Espessura.Milimetros15,nivel.QuantidadeGavetas * 2, FinalidadePeca.LateralGaveta));// redução de 1cm na largura da lateral e 30% na altura de cada lateral da gaveta.
                                                                                                                                                       // quantidade multiplicada por 2 para laterais da direita e esquerda


            int larguraTraseiraGaveta = larguraArmario -8;// Largura do armario menos 1 cm de cada lado (direita e esquerda) pela espessura da laterial, menos 1 de cada lado de espaco par corredição da gaveta
            // traseira gavetas

            pecaGavetas.Add(new Peca(larguraTraseiraGaveta, alturaLateriasGavetas, Espessura.Milimetros15, nivel.QuantidadeGavetas, FinalidadePeca.TraseiraGaveta));

            // Fundo Gaveta
            pecaGavetas.Add(new Peca(larguraTraseiraGaveta +3,   larguraLateralGaveta + 0.5 , Espessura.Milimetros6,nivel.QuantidadeGavetas, FinalidadePeca.TraseiraGaveta));

            return pecaGavetas;
        }


    }
}
