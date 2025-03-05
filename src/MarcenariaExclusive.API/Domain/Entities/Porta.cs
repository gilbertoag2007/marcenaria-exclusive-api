using MarcenariaExclusiveAPI.Application.DTOs;
using System.ComponentModel.DataAnnotations;

namespace MarcenariaExclusive.API.Domain.Entities
{
    public class Porta
    {

        /// <summary>
        /// Quantidade de portas.
        /// </summary>
        [Required(ErrorMessage = "A quantidade de portas é obrigatória.")]
        [Range(1, 4, ErrorMessage = "A quantidade de portas deve estar entre 1 e 4.")]
        public int QuantidadePortas { get; set; }

        /// <summary>
        /// Lista de níveis cobertos pela porta.
        /// </summary>
        [MinLength(1, ErrorMessage = "A lista de níveis cobertos pela porta deve ter pelo menos um nível.")]
        public List<int> NiveisCobertura { get; set; } = new List<int>();

        public Porta(PortaDto portaDto) 
        {
            QuantidadePortas = portaDto.QuantidadePortas;
            NiveisCobertura = portaDto.NiveisCobertura;
        }
    }
}
