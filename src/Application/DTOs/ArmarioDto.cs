using MarcenariaExclusive.API.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MarcenariaExclusiveAPI.Application.DTOs
{
    public class ArmarioDto // Classe DTO  para representar as propriedades de armario recebidas na API 
    {
        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        public string? Email { get; set; } // E-mail do usuario que cadastrou o projeto

        [Required(ErrorMessage = "O nome do projeto é obrigatório.")]
        public string? NomeProjeto { get; set; } // Nome ou descricao do projeto

        [Required(ErrorMessage = "A altura é obrigatória.")]
        [Range(100, 200, ErrorMessage = "A altura deve estar entre 100 e 200 cm.")]
        public int Altura { get; set; } // Altura em centimetros

        [Required(ErrorMessage = "A largura é obrigatória.")]
        [Range(30, 120, ErrorMessage = "A largura deve estar entre 30 e 100 cm.")]
        public int Largura { get; set; } // Largura em centimetros

        [Required(ErrorMessage = "A profundidade é obrigatória.")]
        [Range(20, 70, ErrorMessage = "A profundidade deve estar entre 20 e 70 cm.")]
        public int Profundidade { get; set; } // Profundidade do movel em centimetros

        [Required(ErrorMessage = "É obrigatório informar se o armário tem ou não acabamento inferior.")]
        public bool PossuiAcabamentoInferior { get; set; } // Indica se o armario possui acabamento inferior

        [Required(ErrorMessage = "O estilo do armário é obrigatório.")]
        public Estilo Estilo { get; set; } // Indica o estilo do armário
        
        [Required(ErrorMessage = "É obrigatório informar se o armário tem ou não acabamento superior.")]
        public bool PossuiAcabamentoSuperior { get; set; } // Indica se o armario possui acabamento superior


        [MinLength(1, ErrorMessage = "O armário deve ter pelo menos um nível.")]
        public List<NivelDto> Niveis { get; set; } = new List<NivelDto>(); // Niveis que ocupam o espaco total do movel

        public List<PortaDto> Portas { get; set; } = new List<PortaDto>(); // portas para o armário

        public ArmarioDto() { }

        // Construtor que recebe um objeto Armario como parâmetro
       


    }
}
