﻿using MarcenariaExclusiveAPI.Domain.Entities;
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
        [Range(30, 200, ErrorMessage = "A largura deve estar entre 30 e 200 cm.")]
        public int Largura { get; set; } // Largura em centimetros

        [Required(ErrorMessage = "A profundidade é obrigatória.")]
        [Range(20, 70, ErrorMessage = "A profundidade deve estar entre 20 e 70 cm.")]
        public int Profundidade { get; set; } // Profundidade do movel em centimetros

        [MinLength(1, ErrorMessage = "O armário deve ter pelo menos um nível.")]
        public List<NivelDto> Niveis { get; set; } = new List<NivelDto>(); // Niveis que ocupam o espaco total do movel

        public ArmarioDto() { }

        // Construtor que recebe um objeto Armario como parâmetro
       


    }
}
