/// <summary>
/// Essa classe representa uma posição vazia no mapa.
/// </summary>
public class Vazio : Objeto
{
    /// <summary>
    /// Construtor da classe Vazio.
    /// </summary>
    /// <param name="x">Posição horizontal</param>
    /// <param name="y">Posição vertical</param>
    public Vazio(int x, int y) : base(x, y) { }

    /// <summary>
    /// Este método altera a representação de um espaço vazio no mapa. 
    /// </summary>
    /// <returns> Retorna a representação de um espaço vazio em string </returns>
    public override string ToString() { return "--"; }
}