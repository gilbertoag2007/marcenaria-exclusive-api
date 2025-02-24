

using MarcenariaExclusiveAPI.Application.DTOs;
using System.ComponentModel.DataAnnotations;

namespace MarcenariaExclusiveAPI.Domain.Entities
{
    /// <summary>
    /// Classe que representa um armário dentro do domínio da aplicação.
    /// Implementa a interface IMovel e serve como um DTO para representar as propriedades recebidas na API.
    /// </summary>
    public class Armario
    {
        /// <summary>
        /// E-mail do usuário que cadastrou o projeto.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Nome ou descrição do projeto.
        /// </summary>
        public string? NomeProjeto { get; set; }

        /// <summary>
        /// Altura do armário em centímetros.
        /// </summary>
        public int Altura { get; set; }

        /// <summary>
        /// Largura do armário em centímetros.
        /// </summary>
        public int Largura { get; set; }

        /// <summary>
        /// Profundidade do móvel em centímetros.
        /// </summary>
        public int Profundidade { get; set; }

        /// <summary>
        /// Lista de níveis que ocupam o espaço total do móvel.
        /// </summary>
        public List<Nivel> Niveis { get; set; } = new List<Nivel>();

        /// <summary>
        /// Construtor padrão da classe Armario.
        /// </summary>
        public Armario() { }

        /// <summary>
        /// Construtor que recebe um objeto ArmarioDto como parâmetro.
        /// </summary>
        /// <param name="armarioDto">Objeto ArmarioDto.</param>
        public Armario(ArmarioDto armarioDto)
        {
            Email = armarioDto.Email;
            NomeProjeto = armarioDto.NomeProjeto;
            Altura = armarioDto.Altura;
            Largura = armarioDto.Largura;
            Profundidade = armarioDto.Profundidade;
            Niveis = armarioDto.Niveis.Select(n => new Nivel(n)).ToList();
        }


    }
}
