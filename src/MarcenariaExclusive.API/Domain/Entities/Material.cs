using MarcenariaExclusive.API.Domain.Enums;

namespace MarcenariaExclusiveAPI.Domain.Entities
{
    /// <summary>
    /// Representa um material utilizado na marcenaria.
    /// </summary>
    public class Material
    {
        /// <summary>
        /// Quantidade do material disponível.
        /// </summary>
        public int Quantidade;

        /// <summary>
        /// Tipo do material.
        /// </summary>
        public TipoMaterial TipoMaterial { get; set; }
    }
}