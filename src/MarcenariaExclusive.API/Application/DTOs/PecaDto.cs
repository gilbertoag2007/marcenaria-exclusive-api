using MarcenariaExclusive.API.Domain.Enums;

namespace MarcenariaExclusive.API.Application.DTOs
{
    /// <summary>
    /// Classe DTO para representar os atributos de uma peça de MDF calculada de acordo com as especificações do armário.
    /// </summary>
    public class PecaDto
    {
        /// <summary>
        /// Dimensão da peça calculando a Largura x altura da peça em centímetros.
        /// </summary>
        public string Dimensao { get; set; }

        /// <summary>
        /// Espessura da peça.
        /// </summary>
        public string Espessura { get; set; }

        /// <summary>
        /// Quantidade de peças.
        /// </summary>
        public string Quantidade { get; set; }

        /// <summary>
        /// Finalidade da peça.
        /// </summary>
        public string FinalidadePeca { get; set; }

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="PecaDto"/>.
        /// </summary>
        public PecaDto() { }
    }
}
