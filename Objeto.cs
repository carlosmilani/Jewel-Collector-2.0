/// <summary>
/// Essa classe representa um objeto qualquer no mapa.
/// </summary>
public class Objeto
{
    /// <summary>
    /// Esse membro representa a posição horizontal.
    /// </summary>
    public int pos_x;

    /// <summary>
    /// Esse membro representa a posição vertical.
    /// </summary>
    public int pos_y;

    /// <summary>
    /// Construtor da classe Objeto
    /// </summary>
    /// <param name="x">Posição horizontal</param>
    /// <param name="y">Posição vertical</param>
    public Objeto(int x, int y) { pos_x = x; pos_y = y; }
}