/// <summary>
/// Essa classe representa uma joia verde.
/// </summary>
public class GreenJewel : Jewel
{
    /// <summary>
    /// Construtor da classe GreenJewel.
    /// </summary>
    /// <param name="x">Posição horizontal</param>
    /// <param name="y">Posição vertical</param>
    public GreenJewel(int x, int y) : base(x, y)
    {
        this.value = 50;
        this.cor = "Green";
    }

    /// <summary>
    /// Este método altera a representação de uma joia verde no mapa
    /// </summary>
    /// <returns>Retorna a representação de uma joia verde em string.</returns>
    public override string ToString() { return "JG"; }
}