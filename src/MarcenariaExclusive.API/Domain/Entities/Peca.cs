using MarcenariaExclusive.API.Domain.Enums;

/// <summary>
/// Representa os atributos de uma peça de MDF calculada de acordo com as especificações do armário.
/// </summary>
public class Peca
{
    /// <summary>
    /// Largura da peça em centímetros.
    /// </summary>
    public int Largura { get; set; }

    /// <summary>
    /// Altura da peça em centímetros.
    /// </summary>
    public int Altura { get; set; }

    /// <summary>
    /// Espessura da peça.
    /// </summary>
    public Espessura Espessura { get; set; }

    /// <summary>
    /// Finalidade da peça.
    /// </summary>
    public FinalidadePeca TipoPeca { get; set; }

    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="Peca"/>.
    /// </summary>
    /// <param name="largura">Largura da peça em centímetros.</param>
    /// <param name="altura">Altura da peça em centímetros.</param>
    /// <param name="espessura">Espessura da peça.</param>
    /// <param name="tipoPeca">Finalidade da peça.</param>
    public Peca(int largura, int altura, Espessura espessura, FinalidadePeca tipoPeca)
    {
        Largura = largura;
        Altura = altura;
        Espessura = espessura;
        TipoPeca = tipoPeca;
    }
}