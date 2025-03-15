namespace MarcenariaExclusive.API.Application.DTOs
{
    /// <summary>
    /// Representa um DTO para materiais que serão utilizados para montagem do armário.
    /// </summary>
    public class MaterialDto
    {
        /// <summary>
        /// Material necessário para montagem do armário.
        /// </summary>
        public string? Material { get; set; }

        /// <summary>
        /// Quantidade de Material necessário para montagem do armário.
        /// </summary>
        public int Quantidade { get; set; }

        /// <summary>
        /// Material alternativo caso não tenha o material principal.
        /// </summary>
        public string? MaterialAlternativo { get; set; }
    }
}
