

using MarcenariaExclusiveAPI.Application.DTOs;
using System.ComponentModel.DataAnnotations;

namespace MarcenariaExclusiveAPI.Domain.Entities
{
    // Classe Armario que implementa a interface IMovel
    public class Armario // Classe DTO  para representar as propriedades de armario recebidas na API 
    {
        public string? Email { get; set; } // E-mail do usuario que cadastrou o projeto

        public string? NomeProjeto { get; set; } // Nome ou descricao do projeto

        public int Altura { get; set; } // Altura em centimetros

        public int Largura { get; set; } // Largura em centimetros

        public int Profundidade { get; set; } // Profundidade do movel em centimetros

        public List<Nivel> Niveis { get; set; } = new List<Nivel>(); // Niveis que ocupam o espaco total do movel


        public Armario() { }
    }

    

}
