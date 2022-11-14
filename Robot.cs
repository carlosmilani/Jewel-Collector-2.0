/// <summary>
/// Essa classe representa um robô.
/// </summary>
public class Robot : Objeto
{

    private int new_pos_x, new_pos_y;

    private Bag Bag;

    private int energy;

    private Map mapa;

    /// <summary>
    /// Esse campo diz se o robô está se movendo ou não.
    /// </summary>
    /// <value>true caso esteja se movendo, false caso tenha ficado sem energia.</value>
    public bool running { get; private set; }

    /// <summary>
    /// Construtor da classe Robot
    /// </summary>
    /// <param name="x">Posição horizontal do robô</param>
    /// <param name="y">Posição vertical do robô</param>
    /// <param name="mapa">Mapa das jóias e obstáculos</param>
    /// <param name="Bag">Sacola do robô, guarda os itens coletados.</param>
    public Robot(int x, int y, Map mapa, Bag Bag) : base(x, y)
    {
        this.mapa = mapa;
        this.running = true;
        this.mapa.Insere_objeto(this);
        this.Bag = Bag;
        this.energy = mapa.size / 2;
    }

    /// <summary>
    /// Se o robô estiver adjacente a um item, este item é removido do mapa e adicionado na Bag.
    /// </summary>
    /// <param name="x">Posição horizontal</param>
    /// <param name="y">Posição vertical</param>
    public void Collect_items(int x, int y)
    {
        if (mapa.Matriz[x, y] is Jewel)
        {
            Jewel joia = (Jewel)mapa.Matriz[x, y];
            this.Bag.value += joia.value;
            this.Bag.items += 1;
            this.energy += joia.energy;
            mapa.Matriz[x, y] = new Vazio(x, y);
            mapa.collection.Remove(joia);
        }
        else if (mapa.Matriz[x, y] is Tree)
        {
            Tree tree = (Tree)mapa.Matriz[x, y];
            this.energy += tree.energy;
            tree.energy = 0;
        }
        else if (mapa.Matriz[x, y] is Radioactive)
        {
            Radioactive radioativo = (Radioactive)mapa.Matriz[x, y];
            this.energy += radioativo.energy;
            mapa.Matriz[x, y] = new Vazio(x, y);
        }
    }

    /// <summary>
    /// Imprime o mapa, a Bag e a energia do robô.
    /// </summary>
    public void Print()
    {
        mapa.Print();
        Console.WriteLine($"Bag total items: {this.Bag.items} | Bag total value: {this.Bag.value} | Robot Energy: {this.energy}");
    }

    /// <summary>
    /// Este método checa se o robô tentará se mover para uma posição válida.
    /// </summary>
    /// <param name="x">Posição horizontal do robô</param>
    /// <param name="y">Posição vertical do robô</param>
    public void Check_ValidMove(int x, int y)
    {
        int i, j;
        if (x < 0 || x >= mapa.size || y < 0 || y >= mapa.size)
            throw new SaiuDoMapaException();
        if (mapa.Matriz[x, y] is Vazio)
        {
            for (i = -1; i <= 1; i++)
                for (j = -1; j <= 1; j++)
                {
                    try
                    {
                        if (mapa.Matriz[x + i, y + j] is Radioactive)
                        {
                            Radioactive radioativo = (Radioactive)mapa.Matriz[x + i, y + j];
                            this.energy += radioativo.near_energy;
                        }
                    }
                    catch (IndexOutOfRangeException) { }
                }
        }
        else if (mapa.Matriz[x, y] is Radioactive)
        {
            Radioactive radioativo = (Radioactive)mapa.Matriz[x, y];
            this.energy += radioativo.energy;
        }
        else
        {
            throw new IntransponivelException();
        }
    }

    /// <summary>
    /// Esse método checa se o robô está adjacente a algum item.
    /// </summary>
    public void Check_Item()
    {
        int i, j, x, y;
        for (i = -1; i <= 1; i++)
        {
            x = this.pos_x + i;
            for (j = -1; j <= 1; j++)
            {
                y = this.pos_y + j;
                try
                {
                    Collect_items(x, y);
                }
                catch (IndexOutOfRangeException) { }
            }
        }
        Phase_Clear();
    }

    /// <summary>
    ///  Este método é responsável por fazer o robô se mover.
    /// </summary>
    /// <param name="x">Deslocamento horizontal do robô</param>
    /// <param name="y">Deslocamento vertical do robô</param>
    public void RoboMove(int x, int y)
    {
        this.new_pos_x = this.pos_x + x;
        this.new_pos_y = this.pos_y + y;
        try
        {
            Check_ValidMove(this.new_pos_x, this.new_pos_y);
            mapa.Matriz[this.pos_x, this.pos_y] = new Vazio(this.pos_x, this.pos_y);
            this.pos_x = this.new_pos_x;
            this.pos_y = this.new_pos_y;
            this.energy--;
            mapa.Insere_objeto(this);
            if (this.energy <= 0)
                throw new RoboSemEnergiaException();
        }
        catch (SaiuDoMapaException) { }

        catch (IntransponivelException) { }

        catch (RoboSemEnergiaException)
        {
            this.running = false;
            mapa.level_cleared = false;
            Print();
        }
    }

    /// <summary>
    /// Esse método encerra o jogo.
    /// </summary>
    public void Quit()
    {
        this.running = false;
        mapa.level_cleared = false;
    }

    /// <summary>
    /// Esse método encerra o mapa atual.
    /// </summary>
    public void Phase_Clear()
    {
        if (mapa.collection.Count() <= 0)
        {
            this.running = false;
            mapa.level_cleared = true;
            Print();
        }
    }

    /// <summary>
    /// Este método altera a representação do robô no mapa. 
    /// </summary>
    /// <returns> Retorna a representação de um robô em string </returns>
    public override string ToString() { return "ME"; }
}