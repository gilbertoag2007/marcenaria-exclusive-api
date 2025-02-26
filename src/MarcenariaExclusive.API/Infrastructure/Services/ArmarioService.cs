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

        public PlanoCorte CalcularPlanoCorte(Armario armario)
        {

            Console.WriteLine("CHEGOU NO SERVICE.");
            //  throw new DimensoesException(" AS ESPECIFICAÇÕES ESTÃO FORA DE UMA PROPORÇÃO RAZOAVEL PARA O PROJETO");

            PlanoCorte planoCorte = CalcularPecasEstruturais(armario);

            planoCorte.Materiais = CalcularMateriais(planoCorte);

            foreach (var nivel in armario.Niveis)
            {


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


        // Calcula as especificações das peças estruturais como Letarais, base, topo, fundo e prateleias de divisão de nível.
        private PlanoCorte CalcularPecasEstruturais(Armario armario) 
        {
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

            if ((armario.Niveis.Count -1)  > 0)
            {
                planoCorte.Pecas.Add(
                new Peca(armario.Profundidade, armario.Largura - 3, Espessura.Milimetros15, armario.Niveis.Count, FinalidadePeca.DivisaoHorizontalNivel));
            }


            return planoCorte;
        }
        
        private double CalcularLarguraPorta(int larguraArmario, int quantidadePortas)
    {
        return ( (larguraArmario - 1) / quantidadePortas);
    }



        private List<Peca> CalcularPecaGavetas(double alturaNivel, int larguraArmario,int quantidadeGavetas, int profundidadeArmario, Nivel nivel)
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

        public void ValidarQuantidadePortas(Armario armario)
        {
            
            foreach (var nivel in armario.Niveis)
            {
                if (nivel.QuantidadePortas > 0)
                {
                    double larguraPorta = CalcularLarguraPorta(armario.Largura, nivel.QuantidadePortas);
                    if (larguraPorta < 20 || larguraPorta > 40)
                    {
                        int quantidadePortasNecessarias = (int)Math.Ceiling(armario.Largura / 20.0);
                        throw new DimensoesException($"A quantidade de portas no nível {nivel.NumeroNivel} é inválida. Para atender a largura mínima de 20cm e máxima de 40cm, são necessárias {quantidadePortasNecessarias} portas no nível {nivel.NumeroNivel}.");
                    }
                }
            }
        }
        /// <summary>
        /// Valida se o armário contém pelo menos um nível com o número identificador 1.
        /// </summary>
        /// <param name="armario">O objeto Armario a ser validado.</param>
        public void ValidarNivelComNumeroUm(Armario armario)
        {
            // Verifica se existe algum nível com o número identificador 1
            if (!armario.Niveis.Any(nivel => nivel.NumeroNivel == 1))
            {
                // Lança uma exceção se não houver nenhum nível com o número identificador 1
                throw new DimensoesException("O armário deve conter pelo menos um nível com o número identificador 1.");
            }
        }
        public void ValidarNiveisComNumerosRepetidos(Armario armario)
        {
            // Cria um dicionário para armazenar a contagem de cada número de nível
            Dictionary<int, int> contadorNiveis = new Dictionary<int, int>();

            // Itera sobre cada nível no armário
            foreach (var nivel in armario.Niveis)
            {
                // Verifica se o número do nível já está no dicionário
                if (contadorNiveis.ContainsKey(nivel.NumeroNivel))
                {
                    // Incrementa a contagem do número do nível
                    contadorNiveis[nivel.NumeroNivel]++;
                }
                else
                {
                    // Adiciona o número do nível ao dicionário com contagem inicial de 1
                    contadorNiveis[nivel.NumeroNivel] = 1;
                }
            }

            // Verifica se há algum número de nível com contagem maior que 1
            foreach (var contagem in contadorNiveis)
            {
                if (contagem.Value > 1)
                {
                    // Lança uma exceção se houver números de nível repetidos
                    throw new DimensoesException($"O número do nível {contagem.Key} está repetido {contagem.Value} vezes. Cada nível deve ter um número identificador único.");
                }
            }
        }
        public void ValidarSequenciaNumerosNiveis(Armario armario)
        {
            // Ordena os níveis pelo número identificador
            var niveisOrdenados = armario.Niveis.OrderBy(nivel => nivel.NumeroNivel).ToList();

            // Verifica se os números identificadores são sequenciais
            for (int i = 0; i < niveisOrdenados.Count; i++)
            {
                if (niveisOrdenados[i].NumeroNivel != i + 1)
                {
                    throw new DimensoesException($"Os números identificadores dos níveis devem ser sequenciais. O nível esperado era {i + 1}, mas foi encontrado {niveisOrdenados[i].NumeroNivel}.");
                }
            }
        }


    }
}
