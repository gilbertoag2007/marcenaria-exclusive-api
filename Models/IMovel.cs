namespace MarcenariaExclusiveAPI.Models
{
    public interface IMovel
    {
        int Altura { get; set; }
        int Largura { get; set; }
        int Profundidade { get; set; }
        int Tipo { get; set; }

        Peca CalcularBase();
        Peca CalcularTopo();
        Peca CalcularLaterais();
        Peca CalcularFundo();
    }

}
