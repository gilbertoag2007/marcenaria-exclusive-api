using MarcenariaExclusiveAPI.Domain.Enums;

namespace MarcenariaExclusiveAPI.Domain.Entities
{
    public class Nivel // Classe modelo para representar as caracteristica de cada nivel do armario
    {
        public int numeroNivel { get; set; } // numero para identificar o nivel

        public double percentualEspaco { get; set; } // percentual de utilizacao do espaco considerando a altura do movel

        public ConteudoNivel conteudoNivel { get; set; } // tipo de conteudo que ocupa o espaço do nivel dentro do movel

        public int QuantidadePrateleiras { get; set; } // Quantidade de prateleiras internas dentro do nivel

        public int QuantidadeGavetas { get; set; } // Quantidade de gavetas dentro do nivel

        public int QuantidadePortas { get; set; } // Quantidade de portas dentro do nivel

        public int QuantidadeDivisoes { get; set; } // Quantidade de divisoes verticais internas

        public Nivel() { }
        public override string ToString()
        {

            return $"numeroNivel: {numeroNivel}, percentualEspaco: {percentualEspaco}, conteudoNivel: {conteudoNivel}, QuantidadePrateleiras: {QuantidadePrateleiras}, QuantidadeGavetas: {QuantidadeGavetas}, QuantidadePortas: {QuantidadePortas}, QuantidadeDivisoes: {QuantidadeDivisoes}  ";

        }



    }
}
