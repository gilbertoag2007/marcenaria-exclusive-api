
namespace MarcenariaExclusiveAPI.Domain.Enums
{


    /// <summary>
    /// Enumeração que define os tipos de conteúdo que podem estar presentes em um nível do móvel.
    /// </summary>
    public enum ConteudoNivel
    {
        /// <summary>
        /// Apenas portas.
        /// </summary>
        Portas,

        /// <summary>
        /// Portas e prateleiras internas.
        /// </summary>
        PortasPrateleirasInternas,

        /// <summary>
        /// Contém gavetas.
        /// </summary>
        Gavetas,

        /// <summary>
        /// Espaço sem portas, gavetas ou prateleiras internas, mas com fundo.
        /// </summary>
        VazadoComFundo,

        /// <summary>
        /// Espaço sem portas, gavetas ou prateleiras internas, mas sem fundo.
        /// </summary>
        VazadoSemFundo
    }
}
