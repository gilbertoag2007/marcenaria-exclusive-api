

using MarcenariaExclusiveAPI.Models;

namespace MarcenariaExclusiveAPI.DTO
{
    public class PecaDTO
    {

        public float Altura { get; set; }
        public float Largura { get; set; }
        public float Espessura { get; set; } // Espessura em milímetros
        public float Quantidade { get; set; }

        public PecaDTO(Peca peca)
        {
            Altura = peca.Altura;
            Largura = peca.Largura;
            Espessura = peca.Espessura;
            Quantidade = peca.Quantidade;
        }

    }
}
