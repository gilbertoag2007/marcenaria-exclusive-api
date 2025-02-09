using System.ComponentModel.DataAnnotations;

namespace MarcenariaExclusiveAPI.DTO 
{
    public class ArmarioDto // Classe DTO  para representar as propriedades de armario recebidas na API 
    {
        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [Range(8, 100, ErrorMessage = "O e-mail deve ter entre 8 e 100 caracteres")]
        public string? Email { get; set; } // E-mail do usuario que cadastrou o projeto

        [Required(ErrorMessage = "O nome do projeto é obrigatório.")]
        [Range(8, 100, ErrorMessage = "O nome do projeto deve ter entre 3 e 60 caracteres")]
        public string? NomeProjeto { get; set; } // Nome ou descricao do projeto

        [Required(ErrorMessage = "A altura é obrigatória.")]
        [Range(100, 200, ErrorMessage = "A altura deve estar entre 100 e 200 cm.")]
        public int Altura { get; set; } // Altura em centimetros

        [Required(ErrorMessage = "A largura é obrigatória.")]
        [Range(100, 200, ErrorMessage = "A largura deve estar entre 30 e 200 cm.")]
        public int Largura { get; set; } // Largura em centimetros

        [Required(ErrorMessage = "A profundidade é obrigatória.")]
        [Range(100, 200, ErrorMessage = "A profundidade deve estar entre 20 e 70 cm.")]
        public int Profundidade { get; set; } // Profundidade do movel em centimetros

        [MinLength(1, ErrorMessage = "O armário deve ter pelo menos um nível.")]
        public List<NivelDto> Niveis { get; set; } = new List<NivelDto>(); // Niveis que ocupam o espaco total do movel

    }
}
