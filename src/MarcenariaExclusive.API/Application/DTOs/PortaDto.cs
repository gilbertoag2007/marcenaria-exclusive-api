using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MarcenariaExclusiveAPI.Application.DTOs
{
    /// <summary>
    /// Classe DTO para representar as propriedades de uma porta.
    /// </summary>
    public class PortaDto
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
    }
}
