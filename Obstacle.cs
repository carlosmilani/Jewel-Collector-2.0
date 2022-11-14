/// <summary>
/// Essa classe representa um obstáculo abstrato.
/// </summary>
public class Obstacle : Objeto
{
    /// <summary>
    /// Construtor da classe Obstacle
    /// </summary>
    /// <param name="x">Posição horizontal</param>
    /// <param name="y">Posição vertical</param>
    public Obstacle(int x, int y) : base(x, y) { }
}