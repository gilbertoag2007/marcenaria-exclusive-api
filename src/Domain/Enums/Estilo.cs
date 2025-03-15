using System.ComponentModel;

namespace MarcenariaExclusive.API.Domain.Enums
{


    /// <summary>
    /// Enumeração que define o estilo do armário.
    /// </summary>
    public enum Estilo
    {
        /// <summary>
        /// Armário de chao
        /// </summary>
        [Description("armário de chão")] 
        Chao,
        /// <summary>
        /// Armário aéreo
        /// </summary>
        [Description("armário supenso")] 
        Suspenso

    }
}
