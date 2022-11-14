/// <summary>
/// Essa classe representa uma joia vermelha.
/// </summary>
public class RedJewel : Jewel
{
    /// <summary>
    /// Construtor da classe RedJewel.
    /// </summary>
    /// <param name="x">Posição horizontal</param>
    /// <param name="y">Posição vertical</param>
    public RedJewel(int x, int y) : base(x, y)
    {
        this.value = 100;
        this.cor = "Red";
    }

    /// <summary>
    /// Este método altera a representação de uma joia vermelha no mapa
    /// </summary>
    /// <returns>Retorna a representação de uma joia vermelha em string.</returns>
    public override string ToString() { return "JR"; }

}