namespace MarcenariaExclusive.API.Domain.Exceptions
{
    /// <summary>
    /// Exceção personalizada para indicar erros durante o calculo de peças e materiais,
 
    /// </summary>
    public class CalculoException : Exception
    {
        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="DimensoesException"/> com uma mensagem de erro especificada.
        /// </summary>
        /// <param name="message">A mensagem que descreve o erro.</param>
        public CalculoException(string message) : base(message) { }

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="DimensoesException"/> com uma mensagem de erro especificada
        /// e uma exceção interna que é a causa desse erro.
        /// </summary>
        /// <param name="message">A mensagem que descreve o erro.</param>
        /// <param name="innerException">A exceção que é a causa da exceção atual.</param>
        public CalculoException(string message, Exception innerException) : base(message, innerException) { }
    }
}
