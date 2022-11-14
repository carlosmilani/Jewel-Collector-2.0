/// <summary>
/// Essa classe representa o mapa onde ocorre o jogo.
/// </summary>
public class Map
{
    /// <summary>
    /// Esse membro representa a dimensão do mapa.
    /// </summary>
    /// <value></value>
    public int size { get; private set; }

    /// <summary>
    /// Esse membro representa a fase atual do jogo.
    /// </summary>
    /// <value></value>
    public int level { get; private set; }

    /// <summary>
    /// Esse membro representa uma lista de joias que estão no mapa.
    /// </summary>
    /// <typeparam name="Jewel"></typeparam>
    /// <returns></returns>
    public List<Jewel> collection = new List<Jewel>();

    /// <summary>
    /// Esse membro guarda se a fase foi concluída.
    /// </summary>
    public bool level_cleared = false;

    /// <summary>
    /// Esse membro é uma matriz bi-dimensional que representa um mapa.
    /// </summary>
    public Objeto[,] Matriz;

    /// <summary>
    /// Construtor da classe Map.
    /// </summary>
    /// <param name="size">Tamanho do mapa</param>
    /// <param name="level">Fase atual</param>
    public Map(int size, int level)
    {
        this.size = size;
        this.level = level;

        Matriz = new Objeto[size, size];
        for (int i = 0; i < Matriz.GetLength(0); i++)
        {
            for (int j = 0; j < Matriz.GetLength(1); j++)
                Matriz[i, j] = new Vazio(i, j);
        }

        if (level == 1)
            First_Map();
        else
            Random_Map();
    }

    /// <summary>
    /// Esse método insere um novo objeto no mapa.
    /// </summary>
    /// <param name="objeto"></param>
    public void Insere_objeto(Objeto objeto)
    {
        if (objeto is Jewel)
        {
            collection.Add((Jewel)objeto);
        }
        Matriz[objeto.pos_x, objeto.pos_y] = objeto;
    }

    /// <summary>
    /// Esse método imprime cada uma das posições do mapa.
    /// </summary>
    public void Print()
    {
        Console.WriteLine($"Level: {this.level}");
        for (int i = 0; i < Matriz.GetLength(0); i++)
        {
            for (int j = 0; j < Matriz.GetLength(1); j++)
            {
                Console.Write(Matriz[i, j]);
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }

    /// <summary>
    /// Esse método insere todos os elementos de forma pré-definida na primeira fase do jogo.
    /// </summary>
    public void First_Map()
    {
        this.Insere_objeto(new RedJewel(1, 9));
        this.Insere_objeto(new RedJewel(8, 8));
        this.Insere_objeto(new GreenJewel(9, 1));
        this.Insere_objeto(new GreenJewel(7, 6));
        this.Insere_objeto(new BlueJewel(3, 4));
        this.Insere_objeto(new BlueJewel(2, 1));

        this.Insere_objeto(new Water(5, 0));
        this.Insere_objeto(new Water(5, 1));
        this.Insere_objeto(new Water(5, 2));
        this.Insere_objeto(new Water(5, 3));
        this.Insere_objeto(new Water(5, 4));
        this.Insere_objeto(new Water(5, 5));
        this.Insere_objeto(new Water(5, 6));
        this.Insere_objeto(new Tree(5, 9));
        this.Insere_objeto(new Tree(3, 9));
        this.Insere_objeto(new Tree(8, 3));
        this.Insere_objeto(new Tree(2, 5));
        this.Insere_objeto(new Tree(1, 4));
    }

    /// <summary>
    /// Esse método gera um novo mapa com elementos distribuídos aleatoriamente, a partir da segunda fase do jogo.
    /// </summary>
    public void Random_Map()
    {
        Random r = new Random(1);
        int xRandom, yRandom;
        decimal qtd_jewel, qtd_tree, qtd_water;
        decimal proportion = size * size / 100;
        qtd_jewel = 2 * proportion;
        qtd_tree = 5 * proportion;
        qtd_water = 7 * proportion;
        qtd_jewel = (int)Math.Round(qtd_jewel);
        qtd_water = (int)Math.Round(qtd_water);
        qtd_tree = (int)Math.Round(qtd_tree);

        for (int i = 0; i <= qtd_jewel; i++)
        {
            xRandom = r.Next(0, size);
            yRandom = r.Next(0, size);
            if (Matriz[xRandom, yRandom] is Vazio && xRandom + yRandom != 0)
                this.Insere_objeto(new BlueJewel(xRandom, yRandom));
            else { i--; }
        }

        for (int i = 0; i <= qtd_jewel; i++)
        {
            xRandom = r.Next(0, size);
            yRandom = r.Next(0, size);
            if (Matriz[xRandom, yRandom] is Vazio && xRandom + yRandom != 0)
                this.Insere_objeto(new GreenJewel(xRandom, yRandom));
            else { i--; }
        }

        for (int i = 0; i <= qtd_jewel; i++)
        {
            xRandom = r.Next(0, size);
            yRandom = r.Next(0, size);
            if (Matriz[xRandom, yRandom] is Vazio && xRandom + yRandom != 0)
                this.Insere_objeto(new RedJewel(xRandom, yRandom));
            else { i--; }
        }

        for (int i = 0; i <= qtd_water; i++)
        {
            xRandom = r.Next(0, size);
            yRandom = r.Next(0, size);
            if (Matriz[xRandom, yRandom] is Vazio && xRandom + yRandom != 0)
                this.Insere_objeto(new Water(xRandom, yRandom));
            else { i--; }
        }

        for (int i = 0; i <= qtd_tree; i++)
        {
            xRandom = r.Next(0, size);
            yRandom = r.Next(0, size);
            if (Matriz[xRandom, yRandom] is Vazio && xRandom + yRandom != 0)
                this.Insere_objeto(new Tree(xRandom, yRandom));
            else { i--; }
        }
        bool radioactive = false;
        do
        {
            xRandom = r.Next(0, size);
            yRandom = r.Next(0, size);
            if (Matriz[xRandom, yRandom] is Vazio && xRandom + yRandom != 0)
            {
                this.Insere_objeto(new Radioactive(xRandom, yRandom));
                radioactive = true;
            }
        } while (!radioactive);
    }
}