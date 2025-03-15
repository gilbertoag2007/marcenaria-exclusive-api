using System.ComponentModel;

namespace MarcenariaExclusive.API.Domain.Enums
{
    /// <summary>
    /// Enumeração que define as opções de espessura para os materiais do móvel.
    /// </summary>
    public enum Espessura
    {
        /// <summary>
        /// Espessura de 15 milímetros.
        /// </summary>
        [Description("1.5 centimetros")] 
        Milimetros15,

        /// <summary>
        /// Espessura de 6 milímetros.
        /// </summary>
        [Description("6 milímetros")] 
        Milimetros6
    }
}
