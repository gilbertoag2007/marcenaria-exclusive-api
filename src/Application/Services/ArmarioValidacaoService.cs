using MarcenariaExclusive.API.Application.Interfaces;
using MarcenariaExclusive.API.Domain.Exceptions;
using MarcenariaExclusiveAPI.Domain.Entities;
using MarcenariaExclusiveAPI.Domain.Enums;
using System.Linq;

namespace MarcenariaExclusive.API.Infrastructure.Services
{
    public class ArmarioValidacaoService : IArmarioValidacaoService
    {   
public void ValidarEspecificacoesArmario(Armario armario)
        {
            // Validações de portas
            ValidarQuantidadePortas(armario);

            // Validações de níveis
            ValidarNivelComNumeroUm(armario);
            ValidarNiveisComNumerosRepetidos(armario);
            ValidarSequenciaNumerosNiveis(armario);
            ValidarNiveisCobertura(armario);

            // Validações prateleiras
            ValidarQuantidadePrateleiras(armario);

            // Validações de divisões internas
            ValidarQuantidadeDivisoesInternas(armario);

            // Validações de conteúdo do nível
            ValidarConteudoNivelSimultaneo(armario);
            ValidarQuantidadeConteudoNivel(armario);
            ValidarNiveisCobertosComFundo(armario);
            ValidarAlturaTotalNiveis(armario);

            // Validação gavetas
            ValidarAlturaGavetas(armario);
            ValidarProfundidadeGavetas(armario);

            // validação para portas
      
            ValidarPortaCobreNiveisComConteudosDiferentes(armario);

        }


        /// <summary>
        /// Valida se o armário possui a quantidade necessária de divisões internas verticais com base na quantidade de portas.
        /// </summary>
        /// <param name="armario">O objeto Armario a ser validado.</param>
        /// <exception cref="DimensoesException">Lançada quando a quantidade de divisões internas verticais é insuficiente para a quantidade de portas.</exception>
        public void ValidarQuantidadeDivisoesInternas(Armario armario)
        {
            foreach (var porta in armario.Portas)
            {
                int quantidadeDivisaoInternaNecessaria = 0;

                if (armario.Portas.Count >= 3 && armario.Portas.Count <= 4)
                {
                    quantidadeDivisaoInternaNecessaria = 1;
                }
                else if (armario.Portas.Count >= 5 && armario.Portas.Count <= 6)
                {
                    quantidadeDivisaoInternaNecessaria = 2;
                }
                

                if (quantidadeDivisaoInternaNecessaria > 0)
                {
                    int quantidadeDivisoesInternas = armario.Niveis
                            .Where(nivel => porta.NiveisCobertura.Contains(nivel.NumeroNivel))
                            .Sum(nivel => nivel.QuantidadeDivisoes);
                    if (quantidadeDivisoesInternas < quantidadeDivisaoInternaNecessaria)
                    {
                        throw new DimensoesException($"Para a quantidade de portas informadas são necessárias pelo menos {quantidadeDivisaoInternaNecessaria} divisões internas verticais.");
                    }
                }
            }
        }


        /// <summary>
        /// Valida se a quantidade de prateleiras é adequada com base na altura do nível.
        /// </summary>
        /// <param name="armario">O objeto Armario a ser validado.</param>
        /// <exception cref="ConteudoNivelException">Lançada quando a quantidade de prateleiras é superior à altura do nível.</exception>
        public void ValidarQuantidadePrateleiras(Armario armario)
        {
            foreach (var nivel in armario.Niveis)
            {
                if (nivel.QuantidadePrateleiras > 0)
                {
                    double alturaDisponivel = nivel.AlturaNivel;
                    double espessuraPrateleira = 1.5;
                    double areaLivre = 20.0;
                    double alturaTotalPrateleiras = (espessuraPrateleira + areaLivre) * nivel.QuantidadePrateleiras;

                    if (alturaTotalPrateleiras > alturaDisponivel)
                    {
                        int quantidadeMaximaPrateleirasParaNivel = (int)Math.Floor(alturaDisponivel / (espessuraPrateleira + areaLivre));
                        throw new ConteudoNivelException($"A quantidade máxima de prateleiras para o nível {nivel.NumeroNivel} são {quantidadeMaximaPrateleirasParaNivel}.");
                    }
                }
            }
        }


        /// <summary>
        /// Valida se a quantidade de portas do armário é adequada com base na largura do armário.
        /// </summary>
        /// <param name="armario">O objeto Armario a ser validado.</param>
        /// <exception cref="DimensoesException">Lançada quando a largura das portas é menor que 20 cm ou maior que 40 cm.</exception>
        public void ValidarQuantidadePortas(Armario armario)
        {
            foreach (var porta in armario.Portas)
            {
                if (armario.Portas.Count > 0)
                {
                    double larguraPorta = CalcularLarguraPorta(armario.Largura, armario.Portas.Count);
                    if (larguraPorta < 20 || larguraPorta > 40)
                    {
                        int quantidadePortasNecessarias = (int)Math.Ceiling(armario.Largura / 20.0);


                        if (quantidadePortasNecessarias > armario.Portas.Count) {
                            throw new DimensoesException($"De acordo com a largura informada, são necessários pelo menos {quantidadePortasNecessarias} porta(s).");
                        }
                        
                        
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
        /// <summary>
        /// Valida se os números identificadores dos níveis são sequenciais.
        /// </summary>
        /// <param name="armario">O objeto Armario a ser validado.</param>
        /// <exception cref="DimensoesException">Lançada quando os números identificadores dos níveis não são sequenciais.</exception>
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

        /// <summary>
        /// Valida se os níveis de cobertura das portas existem nos níveis do armário.
        /// </summary>
        /// <param name="armario">O objeto Armario a ser validado.</param>
        /// <exception cref="DimensoesException">Lançada quando um nível de cobertura citado na porta não existe nos níveis do armário.</exception>
        public void ValidarNiveisCobertura(Armario armario)
        {
            var niveisExistentes = armario.Niveis.Select(n => n.NumeroNivel).ToList();

            foreach (var porta in armario.Portas)
            {
                foreach (var nivelCobertura in porta.NiveisCobertura)
                {
                    if (!niveisExistentes.Contains(nivelCobertura))
                    {
                        throw new ConteudoNivelException($"O nível {nivelCobertura} citado na porta não existe nos níveis do armário.");
                    }
                }
            }
        }




        private double CalcularLarguraPorta(int larguraArmario, int quantidadePortas)
        {
            return ((larguraArmario - 1) / quantidadePortas);
        }
        /// <summary>
        /// Valida se o conteúdo do nível é composto exclusivamente por prateleiras, gavetas ou divisões verticais internas.
        /// </summary>
        /// <param name="armario">O objeto Armario a ser validado.</param>
        /// <exception cref="ConteudoNivelException">Lançada quando o nível contém mais de um tipo de conteúdo.</exception>
        public void ValidarConteudoNivelSimultaneo(Armario armario)
        {
            foreach (var nivel in armario.Niveis)
            {
                int count = 0;
                if (nivel.QuantidadePrateleiras > 1) count++;
                if (nivel.QuantidadeGavetas > 1) count++;
                if (nivel.QuantidadeDivisoes > 1) count++;

                if (count > 1)
                {
                    throw new ConteudoNivelException("O Conteúdo do nível deve ser composto exclusivamente por prateleiras, gavetas ou divisões verticais internas.");
                }
            }
        }


        /// <summary>
        /// Valida se a quantidade de conteúdo em cada nível do armário é adequada com base no tipo de conteúdo.
        /// </summary>
        /// <param name="armario">O objeto Armario a ser validado.</param>
        /// <exception cref="ConteudoNivelException">Lançada quando a quantidade de prateleiras, gavetas ou divisões verticais é maior que 1 e o tipo de conteúdo do nível não corresponde.</exception>
        public void ValidarQuantidadeConteudoNivel(Armario armario)
        {
            foreach (var nivel in armario.Niveis)
            {
                if (nivel.QuantidadePrateleiras > 1 && nivel.ConteudoNivel != ConteudoNivel.Prateleiras)
                {
                    throw new ConteudoNivelException($"A quantidade de prateleiras só pode ser maior que 1 quando o conteúdo do nível for Prateleiras. Nível: {nivel.NumeroNivel}");
                }

                if (nivel.QuantidadeGavetas > 1 && nivel.ConteudoNivel != ConteudoNivel.Gavetas)
                {
                    throw new ConteudoNivelException($"A quantidade de gavetas só pode ser maior que 1 quando o conteúdo do nível for Gavetas. Nível: {nivel.NumeroNivel}");
                }

                if (nivel.QuantidadeDivisoes > 1 && nivel.ConteudoNivel != ConteudoNivel.DivisoesVerticais)
                {
                    throw new ConteudoNivelException($"A quantidade de divisões só pode ser maior que 1 quando o conteúdo do nível for DivisoesVerticais. Nível: {nivel.NumeroNivel}");
                }
            }
        }





        /// <summary>
        /// Valida se os níveis cobertos por portas possuem fundo.
        /// </summary>
        /// <param name="armario">O objeto Armario a ser validado.</param>
        /// <exception cref="ConteudoNivelException">Lançada quando um nível coberto por uma porta não possui fundo.</exception>
        public void ValidarNiveisCobertosComFundo(Armario armario)
        {
            foreach (var porta in armario.Portas)
            {
                foreach (var nivelCobertura in porta.NiveisCobertura)
                {
                    var nivel = armario.Niveis.FirstOrDefault(n => n.NumeroNivel == nivelCobertura);
                    if (nivel != null && !nivel.PossuiFundo)
                    {
                        throw new ConteudoNivelException($"O nível {nivel.NumeroNivel} obrigatoriamente deve possuir fundo por ser coberto por uma porta.");
                    }
                }
            }
        }

      



        /// <summary>
        /// Valida se a soma da altura de todos os níveis não ultrapassa a altura disponível do armário.
        /// </summary>
        /// <param name="armario">O objeto Armario a ser validado.</param>
        /// <exception cref="DimensoesException">Lançada quando a soma da altura de todos os níveis ultrapassa a altura disponível do armário.</exception>
        public void ValidarAlturaTotalNiveis(Armario armario)
        {
            // Obtém a altura total disponível do armário
            double alturaDisponivel = armario.Altura;

            // Subtrai 7 cm da altura disponível se o armário possuir acabamento superior
            if (armario.PossuiAcabamentoSuperior)
            {
                alturaDisponivel -= 7;
            }

            // Subtrai 7 cm da altura disponível se o armário possuir acabamento inferior
            if (armario.PossuiAcabamentoInferior)
            {
                alturaDisponivel -= 7;
            }

            // Calcula a soma da altura de todos os níveis do armário
            double alturaTotalNiveis = armario.Niveis.Sum(nivel => nivel.AlturaNivel);

            // Verifica se a soma da altura de todos os níveis é igual a altura disponível do armário
            if (alturaTotalNiveis != alturaDisponivel)
            {
                // Lança uma exceção se a soma da altura de todos os níveis forem diferentes da altura disponível
                throw new DimensoesException($"A soma da altura de todos os níveis ({alturaTotalNiveis} cm) deve ser igual a altura disponível do armário ({alturaDisponivel} cm).");
            }
        }




        /// <summary>
        /// Valida se a altura de cada gaveta em um nível é adequada.
        /// </summary>
        /// <param name="armario">O objeto Armario a ser validado.</param>
        /// <exception cref="ConteudoNivelException">Lançada quando a altura de uma gaveta é inferior a 10 cm.</exception>
        public void ValidarAlturaGavetas(Armario armario)
        {
            foreach (var nivel in armario.Niveis)
            {
                if (nivel.QuantidadeGavetas > 0)
                {
                    double alturaDisponivel = nivel.AlturaNivel -  ((0.2 * (nivel.QuantidadeGavetas - 1)) + 1.5 );// altura disponivel descontando 2mm entre gavetas e 1.5cm da placa de divisao de nivel
                    double alturaGaveta = alturaDisponivel / nivel.QuantidadeGavetas;

                    if (alturaGaveta < 10)
                    {
                        throw new ConteudoNivelException($"A altura de cada gaveta no nível {nivel.NumeroNivel} deve ser de pelo menos 10 cm. Altura calculada: {alturaGaveta} cm.");
                    }
                }
            }
        }
        /// <summary>
        /// Valida se a profundidade do armário é adequada para conter gavetas.
        /// </summary>
        /// <param name="armario">O objeto Armario a ser validado.</param>
        /// <exception cref="ConteudoNivelException">Lançada quando a profundidade do armário é inferior a 20 cm e contém gavetas.</exception>
        public void ValidarProfundidadeGavetas(Armario armario)
        {
            // Verifica se a profundidade do armário é menor que 20 cm
            if (armario.Profundidade < 20)
            {
                // Itera sobre cada nível do armário
                foreach (var nivel in armario.Niveis)
                {
                    // Verifica se o nível contém gavetas
                    if (nivel.ConteudoNivel == ConteudoNivel.Gavetas)
                    {
     
                    }
                }
            }
        }

        // Lança uma exceção se a profundidade do armário for insuficiente para conter gavetas
        /// <summary>
        /// Valida se uma porta cobre mais de um nível com diferentes tipos de conteúdo quando o armário tem no máximo duas portas.
        /// </summary>
        /// <param name="armario">O objeto Armario a ser validado.</param>
        /// <exception cref="ConteudoNivelException">Lançada quando uma porta cobre mais de um nível com diferentes tipos de conteúdo e o armário tem mais de duas portas.</exception>
        public void ValidarPortaCobreNiveisComConteudosDiferentes(Armario armario)
        {
            if (armario.Portas.Count > 2)
            {
                foreach (var porta in armario.Portas)
                {
                    var conteudos = new HashSet<ConteudoNivel>();
                    foreach (var nivelCobertura in porta.NiveisCobertura)
                    {
                        var nivel = armario.Niveis.FirstOrDefault(n => n.NumeroNivel == nivelCobertura);
                        if (nivel != null)
                        {
                            conteudos.Add(nivel.ConteudoNivel);
                        }
                    }
                    if (conteudos.Count > 1)
                    {
                        throw new ConteudoNivelException($"A porta que cobre os níveis {string.Join(", ", porta.NiveisCobertura)} não pode cobrir níveis com diferentes tipos de conteúdo quando o armário tem mais de duas portas.");
                    }
                }
            }
        }

        
      
    }
}
