namespace MarcenariaExclusiveAPI.Models
{
    public class Peca
    {
        // Atributos da classe Peca
        public int Altura { get; set; }
        public int Largura { get; set; }
        public int Espessura { get; set; } // Espessura em milímetros
        public int Quantidade { get; set; }

        public Peca(int altura, int largura, int espessura, int quantidade)
        {
            Altura = altura;
            Largura = largura;
            Espessura = espessura;
            Quantidade = quantidade;
        }
    }
}
