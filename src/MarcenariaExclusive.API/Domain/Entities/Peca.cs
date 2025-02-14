using MarcenariaExclusive.API.Domain.Enums;

/// <summary>
/// Representa os atributos de uma peça de mdf calculada de acordo com as especificações do armário.
/// </summary>
public class Peca
{
    /// <summary>
    /// Largura da peça em centímetros.
    /// </summary>
    public int largura { get; set; }

    /// <summary>
    /// Altura da peça em centímetros.
    /// </summary>
    public int altura { get; set; }

    /// <summary>
    /// Espessura da peça.
    /// </summary>
    public Espessura espessura { get; set; }

    /// <summary>
    /// Finalidade da peça.
    /// </summary>
    public FinalidadePeca tipoPeca { get; set; }

    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="Peca"/>.
    /// </summary>
    public Peca()
    {
    }
}
