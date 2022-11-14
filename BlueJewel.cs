/// <summary>
/// Essa classe representa uma joia azul.
/// </summary>
public class BlueJewel : Jewel
{
    /// <summary>
    /// Construtor da classe BlueJewel.
    /// </summary>
    /// <param name="x">Posição horizontal</param>
    /// <param name="y">Posição vertical</param>
    public BlueJewel(int x, int y) : base(x, y)
    {
        this.value = 10;
        this.cor = "Blue";
        this.energy = 5;
    }

    /// <summary>
    /// Este método altera a representação de uma joia azul no mapa
    /// </summary>
    /// <returns>Retorna a representação de uma joia azul em string.</returns>
    public override string ToString() { return "JB"; }
}