
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
        /// Quantidade de divisões verticais internas.
        /// </summary>
        public int QuantidadeDivisoes { get; set; }


        /// <summary>
        /// Indica se o nível tem ou não fundo.
        /// </summary>
        public bool PossuiFundo{ get; set; }

        /// <summary>
        /// Construtor padrão da classe Nivel.
        /// </summary>
        public Nivel() { }

      

        public override string ToString()
        {
            return $"numeroNivel: {NumeroNivel}, AlturaNivel: {AlturaNivel}, conteudoNivel: {ConteudoNivel}, QuantidadePrateleiras: {QuantidadePrateleiras}, QuantidadeGavetas: {QuantidadeGavetas}, QuantidadeDivisoes: {QuantidadeDivisoes}";
        }
    }
}
