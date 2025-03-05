using MarcenariaExclusiveAPI.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MarcenariaExclusiveAPI.Application.DTOs
{
    public class NivelDto // Classe DTO para representar as caracteristica de cada nivel do armario
    {
        [Required(ErrorMessage = "O número identificador do nível é obrigatório.")]
        [Range(1, 10, ErrorMessage = "O número identificador do nível deve estar entre 1 e 10.")]
        public int NumeroNivel { get; set; } // numero para identificar o nivel

        [Required(ErrorMessage = "A altura do nível em centimetros é obrigatória.")]
        public double AlturaNivel { get; set; } // Altura do nivel em centimetros

        [Required(ErrorMessage = "O conteúdo do nível é obrigatório.")]
        public ConteudoNivel ConteudoNivel { get; set; } // tipo de conteudo que ocupa o espaço do nivel dentro do movel

        public int? QuantidadePrateleiras { get; set; } // Quantidade de prateleiras internas dentro do nivel

        [Range(1, 10, ErrorMessage = "A quantidade de gavetas deve estar entre 1 e 10.")]
        public int? QuantidadeGavetas { get; set; } // Quantidade de gavetas dentro do nivel

        [Range(1, 10, ErrorMessage = "A quantidade de divi deve estar entre 1 e 4.")]
        public int? QuantidadeDivisoes { get; set; } // Quantidade de divisoes verticais internas

        public bool PossuiFundo { get; set; } // Quantidade de divisoes verticais internas


        public NivelDto() { }


    }
}
