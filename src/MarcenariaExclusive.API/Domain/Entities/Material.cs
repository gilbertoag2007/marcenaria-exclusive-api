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

        /// <summary>
        /// Material alternativo caso não tenha o material principal.
        /// </summary>
        /// 
        public string MaterialAlternativo { get; set; }

        /// <summary>
        /// Construtor padrão.
        /// </summary>


        public Material()
        {
        }

        /// <summary>
        /// Construtor com argumentos.
        /// </summary>
        /// <param name="quantidade">Quantidade do material disponível.</param>
        /// <param name="tipoMaterial">Tipo do material.</param>
        public Material(int quantidade, TipoMaterial tipoMaterial)
        {
            Quantidade = quantidade;
            TipoMaterial = tipoMaterial;
        }

    }

}