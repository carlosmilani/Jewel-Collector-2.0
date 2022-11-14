/// <summary>
/// Essa classe representa uma árvore.
/// </summary>
public class Tree : Obstacle
{
    /// <summary>
    /// Esse membro guarda o quanto de energia uma árvore armazena.
    /// </summary>
    public int energy = 3;

    /// <summary>
    /// Construtor da classe Tree;
    /// </summary>
    /// <param name="x">Posição horizontal</param>
    /// <param name="y">Posição vertical</param>
    public Tree(int x, int y) : base(x, y) { }

    /// <summary>
    /// Este método altera a representação da árvore no mapa. 
    /// </summary>
    /// <returns> Retorna a representação de uma árvore em string </returns>
    public override string ToString() { return "$$"; }
}