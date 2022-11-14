/// <summary>
/// Essa classe representa uma joia abstrata.
/// </summary>
public class Jewel : Objeto
{
    /// <summary>
    /// Esse membro representa o valor de uma joia.
    /// </summary>
    public int value;

    /// <summary>
    /// Esse membro representa a cor de uma joia.
    /// </summary>
    public string? cor;

    /// <summary>
    /// Esse membro representa o quanto uma joia pode ser convertida em energia.
    /// </summary>
    public int energy = 0;

    /// <summary>
    /// Construtor da classe Jewel
    /// </summary>
    /// <param name="x">Posição horizontal</param>
    /// <param name="y">Posição vertical</param>
    public Jewel(int x, int y) : base(x, y) { }
}