using MarcenariaExclusive.API.Application.Interfaces;
using MarcenariaExclusive.API.Domain.Entities;
using MarcenariaExclusive.API.Domain.Enums;
using MarcenariaExclusive.API.Domain.Exceptions;
using MarcenariaExclusiveAPI.Application.Interfaces;
using MarcenariaExclusiveAPI.Domain.Entities;
using System.Numerics;


namespace MarcenariaExclusiveAPI.Infrastructure.Services
{
    public class ArmarioService : IArmarioService
    {

        private readonly IArmarioValidacaoService _validador;


        public ArmarioService(IArmarioValidacaoService validador)
        {
            _validador = validador;
        }

        public PlanoCorte CalcularPlanoCorte(Armario armario)
        {

            Console.WriteLine("CHEGOU NO SERVICE.");
            //  throw new DimensoesException(" AS ESPECIFICAÇÕES ESTÃO FORA DE UMA PROPORÇÃO RAZOAVEL PARA O PROJETO");

            _validador.ValidarEspecificacoesArmario(armario);
  
            PlanoCorte planoCorte = new PlanoCorte();
            planoCorte.Armario = armario;
            planoCorte.Pecas = CalcularPecasEstruturais(armario);




            planoCorte.Materiais = CalcularMateriais(planoCorte);



            return planoCorte;
        }


        // Calcula as especificações das peças estruturais como Letarais, base, topo, fundo e prateleias de divisão de nível.
        private List<Peca> CalcularPecasEstruturais(Armario armario) 
        {
            
          List<Peca> pecas = new List<Peca>();

            pecas.Add(
             new Peca(armario.Profundidade, armario.Altura, Espessura.Milimetros15, 2, FinalidadePeca.Lateral));

            pecas.Add(
           new Peca(armario.Largura - 3, armario.Profundidade, Espessura.Milimetros15, 1, FinalidadePeca.Base));// redução de 3cm por conta da espessura das duas peças laterais

            pecas.Add(
            new Peca(armario.Largura - 3, armario.Profundidade, Espessura.Milimetros15, 1, FinalidadePeca.Topo));// redução de 3cm por conta da espessura das duas peças laterais

            pecas.Add(
           new Peca(armario.Largura, 7, Espessura.Milimetros15, 1, FinalidadePeca.AcabamentoInferior));

            pecas.Add(
           new Peca(armario.Largura, 7, Espessura.Milimetros15, 1, FinalidadePeca.AcabamentoSuperior));

            pecas.Add(
           new Peca(armario.Largura, armario.Altura, Espessura.Milimetros6, 1, FinalidadePeca.FundoArmario));

            if ((armario.Niveis.Count -1)  > 0)
            {
                pecas.Add(
               new Peca(armario.Profundidade, armario.Largura - 3, Espessura.Milimetros15, armario.Niveis.Count, FinalidadePeca.DivisaoHorizontalNivel));
            }


            return pecas;
        }




        private List<Peca> CalcularPecaGavetas(Armario armario)
        {
            List<Peca> pecaGavetas = new List<Peca>();
            // Faces das gavetas


            foreach (var nivel in armario.Niveis)
            {

                double alturaGaveta = (nivel.AlturaNivel / nivel.QuantidadeGavetas);// altura da face de cada gaveta descontando 0.2 entre cada gaveta

                pecaGavetas.Add(new Peca(armario.Largura - 1, alturaGaveta, Espessura.Milimetros15, nivel.QuantidadeGavetas, FinalidadePeca.FaceGaveta));// redução de 1cm na largura de cada face da gaveta para gerar um recuo de 0,5 centímetros em cada.

                // Laterais Gavetas

                double alturaLateriasGavetas = alturaGaveta * 0.70;

                int larguraLateralGaveta = armario.Profundidade - 1;

                pecaGavetas.Add(
                new Peca(larguraLateralGaveta, alturaLateriasGavetas, Espessura.Milimetros15, nivel.QuantidadeGavetas * 2, FinalidadePeca.LateralGaveta));// redução de 1cm na largura da lateral e 30% na altura de cada lateral da gaveta.
                                                                                                                                                          // quantidade multiplicada por 2 para laterais da direita e esquerda
                int larguraTraseiraGaveta = armario.Largura - 8;// Largura do armario menos 1 cm de cada lado (direita e esquerda) pela espessura da laterial, menos 1 de cada lado de espaco par corredição da gaveta
                                                               // traseira gavetas

                pecaGavetas.Add(new Peca(larguraTraseiraGaveta, alturaLateriasGavetas, Espessura.Milimetros15, nivel.QuantidadeGavetas, FinalidadePeca.TraseiraGaveta));

                // Fundo Gaveta
                pecaGavetas.Add(new Peca(larguraTraseiraGaveta + 3, larguraLateralGaveta + 0.5, Espessura.Milimetros6, nivel.QuantidadeGavetas, FinalidadePeca.TraseiraGaveta));

               
            }
            return pecaGavetas;
        }


        /// <summary>
        /// Calcula a lista de materiais necessários para a montagem do armário com base no plano de corte fornecido.
        /// </summary>
        /// <param name="planoCorte">O plano de corte contendo as peças do armário.</param>
        /// <returns>Uma lista de materiais necessários para a montagem do armário.</returns>
        public List<Material> CalcularMateriais(PlanoCorte planoCorte)
        {
            try
            {
                List<Material> materiais = new List<Material>();

                foreach (var peca in planoCorte.Pecas)
                {
                    if (peca.FinalidadePeca == FinalidadePeca.Base || peca.FinalidadePeca == FinalidadePeca.Topo || peca.FinalidadePeca == FinalidadePeca.DivisaoHorizontalNivel || peca.FinalidadePeca == FinalidadePeca.Prateleira)
                    {
                        int quantidadeParafusos45mm;
                        if (planoCorte.Armario.Profundidade <= 30) // Utilizado 2 parafusos em cada lado, caso a profundidade seja menor ou igual a 30cm ou 3 caso seja maior
                        {
                            quantidadeParafusos45mm = 4;
                        }
                        else
                        {
                            quantidadeParafusos45mm = 6;
                        }
                        materiais.Add(new Material(quantidadeParafusos45mm, TipoMaterial.Parafuso45mm));
                    }
                    else if (peca.FinalidadePeca == FinalidadePeca.FundoArmario)
                    {
                        // Calcula a largura x altura da peça e multiplica por 2 para definir a quantidade de pregos necessários para pregar o fundo do armário
                        int alturaLarguraCalculada = (planoCorte.Armario.Largura + planoCorte.Armario.Altura) * 2;

                        // Colocando cada prego a uma distância de 10cm um do outro
                        int quantidadePregosFundoArmario = alturaLarguraCalculada / 10;

                        materiais.Add(new Material(quantidadePregosFundoArmario, TipoMaterial.Prego15mm));
                    }
                    else if (peca.FinalidadePeca == FinalidadePeca.AcabamentoSuperior || peca.FinalidadePeca == FinalidadePeca.AcabamentoInferior)
                    {
                        // Parafuso para cada lado do acabamento
                        materiais.Add(new Material(2, TipoMaterial.Parafuso30mm));
                    }
                    else if (peca.FinalidadePeca == FinalidadePeca.PortaArmario || peca.FinalidadePeca == FinalidadePeca.PortaNivel)
                    {
                        if (peca.Altura <= 70)
                        {
                            // Duas dobradiças para cada porta até 70cm de altura
                            materiais.Add(new Material(2 * peca.Quantidade, TipoMaterial.Dobradica));
                        }
                        else if (peca.Altura > 70 && peca.Altura <= 150)
                        {
                            // Três dobradiças para cada porta maior que 70cm de altura e menor ou igual a 150cm
                            materiais.Add(new Material(3 * peca.Quantidade, TipoMaterial.Dobradica));
                        }
                        else if (peca.Altura > 150)
                        {
                            // Quatro dobradiças para cada porta maior que 150cm de altura
                            materiais.Add(new Material(4 * peca.Quantidade, TipoMaterial.Dobradica));
                        }

                        materiais.Add(new Material(1, TipoMaterial.Puxador));
                    }
                    else if (peca.FinalidadePeca == FinalidadePeca.FaceGaveta)
                    {
                        materiais.Add(new Material(4 * peca.Quantidade, TipoMaterial.CantoneiraGaveta));
                    }
                    else if (peca.FinalidadePeca == FinalidadePeca.TraseiraGaveta)
                    {
                        materiais.Add(new Material(4 * peca.Quantidade, TipoMaterial.Parafuso30mm));
                    }
                    else if (peca.FinalidadePeca == FinalidadePeca.FundoGaveta)
                    {
                        // Tamanho linear da largura da lateral da gaveta
                        double tamanhoLinearLateral = planoCorte.Pecas
                            .Where(peca => peca.FinalidadePeca == FinalidadePeca.LateralGaveta)
                            .Select(peca => peca.Largura)
                            .FirstOrDefault();

                        // Tamanho linear da largura do fundo da gaveta
                        double tamanhoLinearFundo = peca.Largura;

                        // Tamanho linear total da largura da gaveta para definir quantidade de pregos necessários.
                        // Deve ser utilizados pregos a cada 10cm
                        int quantidadePregos = (int)((tamanhoLinearLateral + tamanhoLinearFundo) * 2 / 10);

                        materiais.Add(new Material(quantidadePregos, TipoMaterial.Prego15mm));
                    }
                }

                return materiais;
            }
            catch (Exception ex)
            {
                throw new CalculoException("Ocorreu um erro durante os calculos da quantidade de materiais.", ex);
            }
        }

       
            }
        }


