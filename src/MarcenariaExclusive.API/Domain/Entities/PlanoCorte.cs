using MarcenariaExclusiveAPI.Domain.Entities;

namespace MarcenariaExclusive.API.Domain.Entities
{
    /// <summary>
    /// Representa um plano de corte para um armário, contendo a lista de peças a serem cortadas.
    /// </summary>
    public class PlanoCorte
    {
        /// <summary>
        /// Armário para o qual o plano de corte será gerado.
        /// </summary>
        public Armario Armario { get; set; }

        /// <summary>
        /// Lista de peças que compõem o plano de corte.
        /// </summary>
        public List<Peca> Pecas { get; set; } = new List<Peca>();
    }
}