using Domain.Enums;
using MarcenariaExclusive.API.Domain.Entities;
using System.Collections.Generic;

namespace MarcenariaExclusive.API.Application.DTOs
{
    /// <summary>
    /// Classe DTO para representar o plano de corte de um armário.
    /// </summary>
    public class PlanoCorteDto
    {
        /// <summary>
        /// Nome ou descrição do projeto.
        /// </summary>
        public string NomeProjeto { get; set; }

        /// <summary>
        /// e-mail do usuario que projeto ou armario
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Tamanho total de peças em metros quadrados.
        /// </summary>
        public string TamanhoTotalPecasM2 { get; set; }

        /// <summary>
        /// Lista de peças que compõem o plano de corte.
        /// </summary>
        public List<PecaDto> Pecas { get; set; } = new List<PecaDto>();

        /// <summary>
        /// Lista de materiais para montagem do armário.
        /// </summary>
        public List<MaterialDto> Materiais { get; set; } = new List<MaterialDto>();

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="PlanoCorteDto"/>.
        /// </summary>
        public PlanoCorteDto() { }

       

    }
}
