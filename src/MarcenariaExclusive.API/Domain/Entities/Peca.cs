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
    /// Espessura da peça.
    /// </summary>
    public Espessura Espessura { get; set; }

/// <summary>
    /// Quantidade de peças.
    /// </summary>
    public int Quantidade { get; set; }

    /// <summary>
    /// Finalidade da peça.
    /// </summary>
    public FinalidadePeca FinalidadePeca { get; set; }

    /// <summary>
    /// Inicializa uma nova instância da classe <see cref="Peca"/>.
    /// </summary>
    /// <param name="largura">Largura da peça em centímetros.</param>
    /// <param name="altura">Altura da peça em centímetros.</param>
    /// <param name="espessura">Espessura da peça.</param>
/// <param name="quantidade"> Quantidade de peças.</param>
    /// <param name="finalidadePeca">Finalidade da peça.</param>
    public Peca(double largura, double altura, Espessura espessura, int quantidade, FinalidadePeca finalidadePeca)
    {
        Largura = largura;
        Altura = altura;
        Espessura = espessura;
        Quantidade= quantidade;
        FinalidadePeca = finalidadePeca;
    }
    /// <summary>
    /// Retorna a descrição da espessura em milímetros.
    /// </summary>
    /// <returns>Uma string contendo a descrição da espessura.</returns>
    public string ObterDescricaoEspessura()
    {
        return Espessura switch
        {
            Espessura.Milimetros15 => "15 milímetros",
            Espessura.Milimetros6 => "6 milímetros",
            _ => "Não informado"
        };
    }

}