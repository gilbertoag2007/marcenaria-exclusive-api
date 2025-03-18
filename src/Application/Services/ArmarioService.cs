using Domain.Enums;
using MarcenariaExclusive.API.Application.DTOs;
using MarcenariaExclusive.API.Application.Interfaces;
using MarcenariaExclusive.API.Common;
using MarcenariaExclusive.API.Domain.Entities;
using MarcenariaExclusive.API.Domain.Enums;
using MarcenariaExclusive.API.Domain.Exceptions;
using MarcenariaExclusiveAPI.Application.DTOs;
using MarcenariaExclusiveAPI.Application.Interfaces;
using MarcenariaExclusiveAPI.Domain.Entities;
using MarcenariaExclusiveAPI.Domain.Enums;
using System.Collections.Generic;
using System.Linq;


namespace MarcenariaExclusiveAPI.Infrastructure.Services
{
    public class ArmarioService : IArmarioService
    {

        private readonly IArmarioValidacaoService _validador;


        public ArmarioService(IArmarioValidacaoService validador)
        {
            _validador = validador;
        }

        /// <summary>
        /// Calcula o plano de corte para um armário com base nas suas especificações.
        /// </summary>
        /// <param name="armario">O armário para o qual o plano de corte será calculado.</param>
        /// <returns>Um objeto PlanoCorteDto contendo as peças e materiais necessários para a montagem do armário.</returns>
        /// <exception cref="ValidacaoException">Lançada quando as especificações do armário ou conteúdo dos níveis são inválidos.</exception>
        public PlanoCorteDto CalcularPlanoCorte(Armario armario)
        {
            _validador.ValidarEspecificacoesArmario(armario);

            PlanoCorte planoCorte = new PlanoCorte();
            planoCorte.Armario = armario;
            
            planoCorte.Pecas.AddRange(CalcularPecasEstruturais(armario));
            planoCorte.Pecas.AddRange(CalcularPecasConteudoNiveis(armario));
            planoCorte.Pecas.AddRange(CalcularFundosNiveis(armario));
            planoCorte.Pecas.AddRange(CalcularPecasPortas(armario));
            
            planoCorte.Materiais.AddRange(CalcularMateriais(planoCorte));
            PlanoCorteDto planoCorteDto = ConveterPlanoDTO(planoCorte);
            
            return planoCorteDto;
        }
   
        ///summary>
        /// Calcula as peças estruturais de um armário com base nas suas especificações.
        /// </summary>
        /// <param name="armario">O armário para o qual as peças estruturais serão calculadas.</param>
        /// <returns>Uma lista de peças estruturais do armário.</returns>
        /// <exception cref="CalculoException">Lançada quando ocorre um erro durante o cálculo das peças estruturais.</exception>
        private List<Peca> CalcularPecasEstruturais(Armario armario)
        {
            try
            {

                List<Peca> pecas = new List<Peca>();

                pecas.Add(new Peca(armario.Profundidade, armario.Altura, Constantes.EspessuraMDFPadrao, FinalidadePeca.LateralDireita));

                pecas.Add( new Peca(armario.Profundidade, armario.Altura, Constantes.EspessuraMDFPadrao, FinalidadePeca.LateralEsquerda));

                pecas.Add(new Peca(armario.Largura - (Constantes.EspessuraMDFPadrao * 2), armario.Profundidade, Constantes.EspessuraMDFPadrao, FinalidadePeca.Base)); // redução de 3cm por conta da espessura das duas peças laterais

                pecas.Add( new Peca(armario.Largura - (Constantes.EspessuraMDFPadrao * 2), armario.Profundidade, Constantes.EspessuraMDFPadrao, FinalidadePeca.Topo)); // redução de 3cm por conta da espessura das duas peças laterais


                if (armario.PossuiAcabamentoInferior)
                {
                    pecas.Add(new Peca(armario.Largura, Constantes.AlturaAcabamentoCm, Constantes.EspessuraMDFPadrao, FinalidadePeca.AcabamentoInferior));

                }
                
                if (armario.PossuiAcabamentoSuperior)
                {
                    pecas.Add(new Peca(armario.Largura, 7, Constantes.AlturaAcabamentoCm, FinalidadePeca.AcabamentoSuperior));

                }

                return pecas;

            }

            catch (Exception ex)
            {
                throw new CalculoException("Ocorreu um erro durante o cálculo das peças estruturais.", ex);
            }

        }        /// <summary>
        /// Calcula as peças de gavetas de um armário com base nas suas especificações.
        /// </summary>
        /// <param name="armario">O armário para o qual as peças de gavetas serão calculadas.</param>
        /// <returns>Uma lista de peças de gavetas do armário.</returns>
        /// <exception cref="CalculoException">Lançada quando ocorre um erro durante o cálculo das peças de gavetas.</exception>
        private List<Peca> CalcularPecaGavetas(Armario armario)
        {
            List<Peca> pecaGavetas = new List<Peca>();

            try
            {
                foreach (var nivel in armario.Niveis)
                {
                    if (nivel.ConteudoNivel == ConteudoNivel.Gavetas)
                    {
                        double alturaDisponivelNivel = nivel.AlturaNivel - ((0.2 * (nivel.QuantidadeGavetas - 1)) + 1.5); // altura disponível descontando 2mm entre gavetas e 1.5cm da placa de divisão de nível

                        double alturaFaceGaveta = alturaDisponivelNivel / nivel.QuantidadeGavetas;

                        double alturaLateraisGaveta = alturaFaceGaveta * 0.70;

                        int larguraLateralGaveta = armario.Profundidade - 1;
                        int larguraTraseiraGaveta = armario.Largura - 8; // Largura do armário menos 1 cm de cada lado (direita e esquerda) pela espessura da lateral, menos 1 de cada lado de espaço para corrediça da gaveta

                        for (int i = 0; i < nivel.QuantidadeGavetas; i++)
                        {
                            pecaGavetas.Add(new Peca(armario.Largura - 1, alturaFaceGaveta, Constantes.EspessuraMDFPadrao, FinalidadePeca.FaceGaveta)); // redução de 1cm na largura de cada face da gaveta para gerar um recuo de 0,5 centímetros em cada lado do armário.
                            pecaGavetas.Add(new Peca(larguraTraseiraGaveta, alturaLateraisGaveta, Constantes.EspessuraMDFPadrao, FinalidadePeca.TraseiraGaveta));

                            // Fundo Gaveta
                            pecaGavetas.Add(new Peca(larguraTraseiraGaveta + 3, larguraLateralGaveta + 0.5, Constantes.EspessuraMDFFundo, FinalidadePeca.FundoGaveta));

                            // Laterais Gavetas
                            pecaGavetas.Add(new Peca(larguraLateralGaveta, alturaLateraisGaveta, Constantes.EspessuraMDFPadrao, FinalidadePeca.LateralGaveta)); // redução de 1cm na largura da lateral e 30% na altura de cada lateral da gaveta.
                            pecaGavetas.Add(new Peca(larguraLateralGaveta, alturaLateraisGaveta, Constantes.EspessuraMDFPadrao, FinalidadePeca.LateralGaveta)); // quantidade multiplicada por 2 para laterais da direita e esquerda
                        }
                    }
                }
            } catch (CalculoException ex)
            {
                throw new CalculoException("Ocorreu um erro durante o cálculo das peças das gavetas.", ex);

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

                int quantidadeParafusos45mm = 0;
                int quantidadePregosFundoArmario = 0;
                int quantidadeParafusoAcabamento = 0;
                int quantidadeDobradicas35 = 0;
                int quantidadeCantoneiraGaveta = 0;
                int quantidadePregos = 0;
                int quantidadeParafuso30 = 0;
                int quantidadePuxador = 0;

                foreach (var peca in planoCorte.Pecas)
                {
                    if (peca.FinalidadePeca == FinalidadePeca.Base || peca.FinalidadePeca == FinalidadePeca.Topo || peca.FinalidadePeca == FinalidadePeca.DivisaoHorizontalNivel || peca.FinalidadePeca == FinalidadePeca.Prateleira)
                    {
                        if (planoCorte.Armario.Profundidade <= 30)
                        {
                            quantidadeParafusos45mm += 4;
                        }
                        else
                        {
                            quantidadeParafusos45mm += 6;
                        }
                    }
                    else if (peca.FinalidadePeca == FinalidadePeca.FundoArmario)
                    {
                        int alturaLarguraCalculada = (planoCorte.Armario.Largura + planoCorte.Armario.Altura) * 2;
                        quantidadePregosFundoArmario = alturaLarguraCalculada / 10;
                    }
                    else if (peca.FinalidadePeca == FinalidadePeca.AcabamentoSuperior || peca.FinalidadePeca == FinalidadePeca.AcabamentoInferior)
                    {
                        quantidadeParafusoAcabamento += 2;
                    }
                    else if (peca.FinalidadePeca == FinalidadePeca.Porta)
                    {
                        if (peca.Altura <= 70)
                        {
                            quantidadeDobradicas35 += 2;
                        }
                        else if (peca.Altura > 70 && peca.Altura <= 150)
                        {
                            quantidadeDobradicas35 += 3;
                        }
                        else if (peca.Altura > 150)
                        {
                            quantidadeDobradicas35 += 4;
                        }
                        quantidadePuxador += 1;
                    }
                    else if (peca.FinalidadePeca == FinalidadePeca.FaceGaveta)
                    {
                        quantidadeCantoneiraGaveta += 4;
                        quantidadePuxador += 1;
                    }
                    else if (peca.FinalidadePeca == FinalidadePeca.TraseiraGaveta)
                    {
                        quantidadeParafuso30 += 4;
                    }
                    else if (peca.FinalidadePeca == FinalidadePeca.FundoGaveta)
                    {
                        double tamanhoLinearLateral = planoCorte.Pecas
                            .Where(peca => peca.FinalidadePeca == FinalidadePeca.LateralGaveta)
                            .Select(peca => peca.Largura)
                            .FirstOrDefault();
                        double tamanhoLinearFundo = peca.Largura;
                        quantidadePregos += (int)((tamanhoLinearLateral + tamanhoLinearFundo) * 2 / 10);
                    }
                }

                if (quantidadePregosFundoArmario > 0)
                    materiais.Add(new Material(quantidadePregosFundoArmario, TipoMaterial.Prego15mm));
                if (quantidadeParafusos45mm > 0)
                    materiais.Add(new Material(quantidadeParafusos45mm, TipoMaterial.Parafuso45mm));
                if (quantidadeParafusoAcabamento > 0)
                    materiais.Add(new Material(quantidadeParafusoAcabamento, TipoMaterial.Parafuso30mm));
                if (quantidadeDobradicas35 > 0)
                    materiais.Add(new Material(quantidadeDobradicas35, TipoMaterial.Dobradica35mm));
                if (quantidadeCantoneiraGaveta > 0)
                    materiais.Add(new Material(quantidadeCantoneiraGaveta, TipoMaterial.CantoneiraGaveta));
                if (quantidadeParafuso30 > 0)
                    materiais.Add(new Material(quantidadeParafuso30, TipoMaterial.Parafuso30mm));
                if (quantidadePregos > 0)
                    materiais.Add(new Material(quantidadePregos, TipoMaterial.Prego15mm));
                if (quantidadePuxador > 0)
                    materiais.Add(new Material(quantidadePuxador, TipoMaterial.Puxador));

                return materiais;
            }
            catch (Exception ex)
            {
                throw new CalculoException("Ocorreu um erro durante os calculos da quantidade de materiais.", ex);
            }
        }


        private List<Peca> CalcularFundosNiveis(Armario armario)
        {
            List<Peca> fundosNiveis = new List<Peca>();

            foreach (var nivel in armario.Niveis)
            {
                if (nivel.PossuiFundo)
                {
                    fundosNiveis.Add(new Peca(armario.Largura-0.5, nivel.AlturaNivel - 0.5, Constantes.EspessuraMDFFundo,  FinalidadePeca.FundoArmario)); // redução de meio centimetros no fundo para melhor acabamento.
                }
            }

            return fundosNiveis;
        }

        private PlanoCorteDto ConveterPlanoDTO(PlanoCorte planoCorte)
        {
            PlanoCorteDto planoCorteDto = new PlanoCorteDto();


            planoCorteDto.NomeProjeto = planoCorte.Armario.NomeProjeto;
            planoCorteDto.Email = planoCorte.Armario.Email;
            planoCorteDto.TamanhoTotalPecasM2 = $"{CalcularTamanhoTotalPecasM2(planoCorte.Pecas):F2}";
            planoCorteDto.Pecas.AddRange(AgruparPecas(planoCorte.Pecas));
            
            planoCorteDto.Materiais = planoCorte.Materiais.Select(m => new MaterialDto
            {
                Material = $"{EnumExtensions.GetDescription(m.TipoMaterial)}",
                Quantidade = m.Quantidade,
                MaterialAlternativo = m.MaterialAlternativo

            }).ToList();
            return planoCorteDto;
        }

        /// <summary>
        /// Agrupa as peças de acordo com a finalidade e calcula a quantidade de cada tipo de peça.
        /// </summary>
        /// <param name="listaPecas">Lista de peças a serem agrupadas.</param>
        /// <returns>Uma lista de objetos PecaDto contendo as peças agrupadas e suas quantidades.</returns>
        private List<PecaDto> AgruparPecas(List<Peca> listaPecas)
        {
            var pecasAgrupadas = listaPecas
            
            .GroupBy(p => new { p.FinalidadePeca, p.Altura, p.Largura })
            .Select(g => new PecaDto
            {
                Dimensao = $"{g.Key.Altura.ToString("0.##")} cm x {g.Key.Largura.ToString("0.##")} cm",
                Espessura = $"{(g.First().Espessura * 10)} mm",
                Quantidade = g.Count().ToString(),
                FinalidadePeca = EnumExtensions.GetDescription(g.Key.FinalidadePeca)
            })
            .ToList();

            return pecasAgrupadas;
        }
        private double CalcularTamanhoTotalPecasM2(List<Peca> listaPecas)
        {
            // Calcula a área de cada peça (largura * altura) em metros quadrados e multiplica pela quantidade de peças
            // Soma todas as áreas para obter o tamanho total
            return listaPecas.Sum(p => ((p.Largura * p.Altura) / 10000));
        }




        private List<Peca> CalcularPecasConteudoNiveis(Armario armario)
        {
            List<Peca> pecasConteudo = new List<Peca>();


            if (armario.Niveis.Count > 1)
            {
                for (int i = 1; i < armario.Niveis.Count; i++)
                {
                    pecasConteudo.Add(
                       new Peca(armario.Largura - (Constantes.EspessuraMDFPadrao * 2), armario.Profundidade, Constantes.EspessuraMDFPadrao, FinalidadePeca.DivisaoHorizontalNivel));
                }

            }
            foreach (var nivel in armario.Niveis)
            {
                switch (nivel.ConteudoNivel)
                {
                    case ConteudoNivel.Prateleiras:
                        for (int i = 0; i < nivel.QuantidadePrateleiras; i++)
                        {
                            pecasConteudo.Add(new Peca(
                                armario.Largura - (Constantes.EspessuraMDFPadrao * 2),
                                armario.Profundidade,
                                Constantes.EspessuraMDFPadrao,
                                
                                FinalidadePeca.Prateleira));
                        }
                        break;

                    case ConteudoNivel.Gavetas:
                        pecasConteudo.AddRange(CalcularPecaGavetas(armario));
                        break;

                    case ConteudoNivel.DivisoesVerticais:
                        for (int i = 0; i < nivel.QuantidadeDivisoes; i++)
                        {
                            pecasConteudo.Add(new Peca(
                                armario.Profundidade,
                                nivel.AlturaNivel - Constantes.EspessuraMDFPadrao, // Desconta a espessura da peça que serve como divisão de nivel 
                                Constantes.EspessuraMDFPadrao,                                
                                FinalidadePeca.DivisaoVerticalInterna));
                        }
                        break;
                }
            }

            return pecasConteudo;
        }
        /// <summary>
        /// Calcula o tamanho das portas de um armário com base nas suas especificações.
        /// </summary>
        /// <param name="armario">O armário para o qual as portas serão calculadas.</param>
        /// <returns>Uma lista de objetos Porta contendo as dimensões calculadas para cada porta.</returns>
        /// <exception cref="CalculoException">Lançada quando ocorre um erro durante o cálculo das dimensões das portas.</exception>
        private List<Peca> CalcularPecasPortas(Armario armario)
        {
            List<Peca> pecas = new List<Peca>();

            foreach (var porta in armario.Portas)
            {
                double alturaPorta = porta.NiveisCobertura.Sum(nivel => armario.Niveis.First(n => n.NumeroNivel == nivel).AlturaNivel) - 1; // reduz 1 cm para recuo na parte superior e inferior
                double larguraPorta = armario.Largura / armario.Portas.Count; // reduz 1 cm para recuo na direita e esquerda

               
                    pecas.Add(new Peca(                    
                        larguraPorta,
                        alturaPorta,
                        Constantes.EspessuraMDFPadrao,
                        FinalidadePeca.Porta
                    ));
                
            }

            return pecas;
        }





        /// <summary>
        /// Calcula a altura total das portas de um armário com base nos níveis cobertos por cada porta.
        /// </summary>
        /// <param name="portaDto">Objeto PortaDto contendo as informações das portas e os níveis que elas cobrem.</param>
        /// <param name="armario">Objeto Armario contendo as especificações do armário.</param>
        /// <returns>A altura total das portas em centímetros, descontando 1 cm para recuo inferior e superior.</returns>
        public double CalcularAlturaPorta( ArmarioDto armarioDto, PortaDto portaDto)
        {
            double somaAlturaNiveis = 0;

            foreach (var nivelCobertura in portaDto.NiveisCobertura)
            {
                var nivel = armarioDto.Niveis.FirstOrDefault(n => n.NumeroNivel == nivelCobertura);
                if (nivel != null)
                {
                    somaAlturaNiveis += nivel.AlturaNivel;
                }
            }

            return somaAlturaNiveis - 1; // redução de 1 cm para recuo inferior e superior
        }
        /// <summary>
        /// Calcula a largura de cada porta de um armário com base na largura total do armário e na quantidade de portas.
        /// </summary>
        /// <param name="larguraArmario">A largura total do armário em centímetros.</param>
        /// <param name="portas">A lista de objetos PortaDto representando as portas do armário.</param>
        /// <returns>A largura de cada porta em centímetros.</returns>
        /// <exception cref="ArgumentException">Lançada quando a lista de portas é nula ou vazia.</exception>
        public double CalcularLarguraPorta(int larguraArmario, PortaDto porta)
        {
            

            return (larguraArmario - 1) / porta.QuantidadePortas;
        }
 
       
            }
        }


