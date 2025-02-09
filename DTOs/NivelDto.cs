using MarcenariaExclusiveAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace MarcenariaExclusiveAPI.DTO
{
    public class NivelDto // Classe DTO para representar as caracteristica de cada nivel do armario
    {
        [Required(ErrorMessage = "O número identificador do nível é obrigatório.")]
        [Range(1, 10, ErrorMessage = "O número identificador do nível deve estar entre 1 e 10.")]
        public int numeroNivel { get; set; } // numero para identificar o nivel

        [Required(ErrorMessage = "O percentual de ocupação do espaço é obrigatório.")]
        [Range(10, 100, ErrorMessage = "O percentual de ocupação do espaço do nível deve estar entre 10 e 100.")]
        public double percentualEspaco { get; set; } // percentual do espaco que o nivel vai ocupar no armario

        [Required(ErrorMessage = "O conteúdo do nível é obrigatório.")]
        public ConteudoNivel conteudoNivel { get; set; } // tipo de conteudo que ocupa o espaço do nivel dentro do movel

        [Range(1, 100, ErrorMessage = "O percentual de ocupação do espaço do nível deve estar entre 10 e 100.")]
        public int? QuantidadePrateleiras { get; set; } // Quantidade de prateleiras internas dentro do nivel

        [Range(1, 10, ErrorMessage = "A quantidade de gavetas deve estar entre 1 e 10.")]
        public int? QuantidadeGavetas { get; set; } // Quantidade de gavetas dentro do nivel

        [Range(1,4 , ErrorMessage = "A quantidade de portas deve estar entre 1 e 4.")]
        public int? QuantidadePortas { get; set; } // Quantidade de portas dentro do nivel


        [Range(1, 10, ErrorMessage = "A quantidade de divi deve estar entre 1 e 4.\"")]
        public int? QuantidadeDivisoes { get; set; } // Quantidade de divisoes verticais internas


    }
}
