/// <summary>
/// Essa classe representa um obstáculo aquático
/// </summary>
public class Water : Obstacle
{
    /// <summary>
    /// Construtor da classe Water.
    /// </summary>
    /// <param name="x">Posição horizontal</param>
    /// <param name="y">Posição vertical</param>
    public Water(int x, int y) : base(x, y) {}

    /// <summary>
    /// Este método altera a representação da água no mapa. 
    /// </summary>
    /// <returns> Retorna a representação de água em string </returns>
    public override string ToString() {return "##";}
}