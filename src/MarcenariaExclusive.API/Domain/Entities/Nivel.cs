using MarcenariaExclusiveAPI.Application.DTOs;
using MarcenariaExclusiveAPI.Domain.Enums;

namespace MarcenariaExclusiveAPI.Domain.Entities
{
    /// <summary>
    /// Classe modelo para representar as características de cada nível do armário. Os níveis ficam posicionados um em cima do outro ocupando toda largura disponível do armário e altura de acordo com o percentual definido no atributo percentualEspaco.


    /// </summary>
    public class Nivel
    {
        /// <summary>
        /// Número identificador do nível.
        /// </summary>
        public int NumeroNivel { get; set; }

        /// <summary>
        /// Percentual de utilização do espaço considerando a altura do móvel.
        /// </summary>
        public double AlturaNivel { get; set; }

        /// <summary>
        /// Tipo de conteúdo que ocupa o espaço do nível dentro do móvel.
        /// </summary>
        public ConteudoNivel ConteudoNivel { get; set; }

        /// <summary>
        /// Quantidade de prateleiras internas dentro do nível.
        /// </summary>
        public int QuantidadePrateleiras { get; set; }

        /// <summary>
        /// Quantidade de gavetas dentro do nível.
        /// </summary>
        public int QuantidadeGavetas { get; set; }

        /// <summary>
        /// Quantidade de portas dentro do nível.
        /// </summary>
        public int QuantidadePortas { get; set; }

        /// <summary>
        /// Quantidade de divisões verticais internas.
        /// </summary>
        public int QuantidadeDivisoes { get; set; }

        /// <summary>
        /// Construtor padrão da classe Nivel.
        /// </summary>
        public Nivel() { }

        /// <summary>
        /// Retorna uma representação em string do objeto Nivel.
        /// </summary>
        /// <returns>Uma string representando o nível e suas características.</returns>

        /// <summary>
        /// Construtor que recebe um objeto NivelDto como parâmetro.
        /// </summary>
        /// <param name="nivelDto">Objeto NivelDto.</param>
        public Nivel(NivelDto nivelDto)
        {
            NumeroNivel = nivelDto.NumeroNivel;
            AlturaNivel = nivelDto.AlturaNivel;
            ConteudoNivel = nivelDto.ConteudoNivel;
            QuantidadePrateleiras = nivelDto.QuantidadePrateleiras ?? 0;
            QuantidadeGavetas = nivelDto.QuantidadeGavetas ?? 0;
            QuantidadePortas = nivelDto.QuantidadePortas ?? 0;
            QuantidadeDivisoes = nivelDto.QuantidadeDivisoes ?? 0;
        }

        public override string ToString()
        {
            return $"numeroNivel: {NumeroNivel}, AlturaNivel: {AlturaNivel}, conteudoNivel: {ConteudoNivel}, QuantidadePrateleiras: {QuantidadePrateleiras}, QuantidadeGavetas: {QuantidadeGavetas}, QuantidadePortas: {QuantidadePortas}, QuantidadeDivisoes: {QuantidadeDivisoes}";
        }
    }
}
