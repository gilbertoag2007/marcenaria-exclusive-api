
using System.ComponentModel.DataAnnotations;

namespace MarcenariaExclusive.API.Domain.Entities
{
    public class Porta
    {
        /// <summary>
        /// Largura da porta.
        /// </summary>
        public double Largura { get; set; }

        /// <summary>
        /// Altura da porta.
        /// </summary>
        public double Altura { get; set; }

        public List<int> NiveisCobertura { get; set; } = new List<int>();
    }
}
