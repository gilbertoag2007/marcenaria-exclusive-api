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
        [Required(ErrorMessage = "A quantidade de portas � obrigat�ria.")]
        [Range(1, 5, ErrorMessage = "A quantidade de portas deve estar entre 1 e 5.")]
        public int QuantidadePortas { get; set; }

        /// <summary>
        /// Lista de n�veis cobertos pela porta.
        /// </summary>
        [MinLength(1, ErrorMessage = "A porta obrigatoriamente tem que cobrir pelo menos n�vel.")]
        public List<int> NiveisCobertura { get; set; } = new List<int>();
    }
}
