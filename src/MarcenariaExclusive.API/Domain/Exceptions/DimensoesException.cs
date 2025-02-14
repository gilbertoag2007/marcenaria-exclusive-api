﻿namespace MarcenariaExclusive.API.Domain.Exceptions
{
    /// <summary>
    /// Exceção personalizada para indicar erros nas dimensões e proporções de um armário
    /// quando não estiverem de acordo com as regras de negócio.
    /// </summary>
    public class DimensoesException : Exception
    {
        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="DimensoesException"/> com uma mensagem de erro especificada.
        /// </summary>
        /// <param name="message">A mensagem que descreve o erro.</param>
        public DimensoesException(string message) : base(message) { }

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="DimensoesException"/> com uma mensagem de erro especificada
        /// e uma exceção interna que é a causa desse erro.
        /// </summary>
        /// <param name="message">A mensagem que descreve o erro.</param>
        /// <param name="innerException">A exceção que é a causa da exceção atual.</param>
        public DimensoesException(string message, Exception innerException) : base(message, innerException) { }
    }
}
