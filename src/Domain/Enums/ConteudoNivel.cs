
using System.ComponentModel;

namespace MarcenariaExclusiveAPI.Domain.Enums
{


    /// <summary>
    /// Enumeração que define os tipos de conteúdo que podem estar presentes em um nível do móvel.
    /// </summary>
    public enum ConteudoNivel
    {
        /// <summary>
        /// Prateleiras internas.
        /// </summary>
        [Description("prateleiras")]
        Prateleiras,

        /// <summary>
        /// Contém gavetas.
        /// </summary>
        [Description("gavetas")]
        Gavetas,

          /// <summary>
          /// Divisão Vertical dentro do nível.
          /// </summary>    
        [Description("divisões verticais")] 
        DivisoesVerticais,
        
        /// <summary>
        /// Nível sem contéúdo
        /// </summary>
        [Description("Sem conteúdo pré-definido")] 
        Livre



    }
}
