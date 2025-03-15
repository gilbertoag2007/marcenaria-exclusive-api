using System.ComponentModel;

namespace MarcenariaExclusive.API.Domain.Enums
{
    /// <summary>
    /// Enumeração que representa os diferentes tipos de materiais utilizados na marcenaria.
    /// </summary>
    public enum TipoMaterial
    {
        /// <summary>
        /// Prego de 15 milímetros.
        /// </summary>
        [Description("prego de 15mm")] 
        Prego15mm,

        /// <summary>
        /// Parafuso de 45 milímetros.
        /// </summary>
        [Description("parafuso philips 45mm x xxmm")] 
        Parafuso45mm,

        /// <summary>
        /// Parafuso de 45 milímetros.
        /// </summary>
        [Description("parafuso philips 30mm x xxmm")] 
        Parafuso30mm,

        /// <summary>
        /// Puxador para gavetas.
        /// </summary>
        [Description("puxador")] 
        Puxador,

        /// <summary>
        /// Trilho para gavetas .
        /// </summary>
        [Description("trilho")] 
        Trilho,

        /// <summary>
        /// Cantoneira para .
        /// </summary>
        [Description("cantoneira para prateleira")] 
        CantoneiraPrateleira,
       
        /// <summary>
        /// Dobradiças de 35mm para portas.
        /// </summary>
        [Description("dobradiça caneco 35mm")] 
        Dobradica35mm,

        /// <summary>
        /// Dobradiças de 28mm para portas.
        /// </summary>
        [Description("dobradiça caneco 28mm")] 
        Dobradica28mm,

        /// <summary>
        /// Cantoneira pequena para faces de gavetas.
        /// </summary>
        [Description("cantoneira para gaveta")] 
        CantoneiraGaveta,

    }
}
