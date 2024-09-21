namespace MarcenariaExclusiveAPI.Models
{
    public class PecaDTO
    {

        public int Altura { get; set; }
        public int Largura { get; set; }
        public int Espessura { get; set; } // Espessura em milímetros
        public int Quantidade { get; set; }

        public PecaDTO(Peca peca)
        {
            Altura = peca.Altura;
            Largura = peca.Largura;
            Espessura = peca.Espessura;
            Quantidade = peca.Quantidade;
        }

    }
}
