/// <summary>
/// Essa classe representa um elemento radiativo.
/// </summary>
public class Radioactive : Objeto
{
    /// <summary>
    /// Esse membro representa o quanto de energia o robô perde ao pegar este elemento.
    /// </summary>
    /// <value>-30</value>
    public int energy { get; private set; }

    /// <summary>
    /// Esse membro representa o quanto de energia o robô perde ao ficar adjacente a este elemento.
    /// </summary>
    /// <value>-10</value>
    public int near_energy { get; private set; }

    /// <summary>
    /// Construtor da classe RadioActive.
    /// </summary>
    /// <param name="x">Posição horizontal</param>
    /// <param name="y">Posição vertical</param>
    public Radioactive(int x, int y) : base(x, y)
    {
        this.energy = -30;
        this.near_energy = -10;
    }

    /// <summary>
    /// Este método altera a representação de um elemento radioativo no mapa
    /// </summary>
    /// <returns>Retorna a representação de um elemento radioativo em string.</returns>
    public override string ToString() { return "!!"; }
}