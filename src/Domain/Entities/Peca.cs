using MarcenariaExclusive.API.Domain.Enums;

/// <summary>
/// Representa os atributos de uma peça de MDF calculada de acordo com as especificações do armário.
/// </summary>
public class Peca
{
    /// <summary>
    /// Largura da peça em centímetros.
    /// </summary>
    public double Largura { get; set; }

    /// <summary>
    /// Altura da peça em centímetros.
    /// </summary>
    public double Altura { get; set; }

    /// <summary>
    /// Espessura da peça em centímetros.
    /// </summary>
    public double Espessura { get; set; }

    /// <summary>
    /// Finalidade da peça.
    /// </summary>
    public FinalidadePeca FinalidadePeca { get; set; }

    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="Peca"/>.
    /// </summary>
    /// <param name="largura">Largura da peça em centímetros.</param>
    /// <param name="altura">Altura da peça em centímetros.</param>
    /// <param name="espessura">Espessura da peça em centímetros.</param>

    /// <param name="finalidadePeca">Finalidade da peça.</param>
    public Peca(double largura, double altura, double espessura, FinalidadePeca finalidadePeca)
    {
        Largura = largura;
        Altura = altura;
        Espessura = espessura;
        FinalidadePeca = finalidadePeca;
    }
   

}