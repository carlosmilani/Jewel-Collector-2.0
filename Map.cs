public class Map
{
    public int size {get; private set;}
    public int level {get; private set;}
    public List<Jewel> collection = new List<Jewel>();
    public bool level_cleared = false;
    public Objeto[,] Matriz;

    public Map(int size, int level) {
        this.size = size;
        this.level = level;

        Matriz = new Objeto[size,size];
        for (int i = 0; i < Matriz.GetLength(0); i++) {
            for (int j = 0; j < Matriz.GetLength(1); j++)
                Matriz[i,j] = new Vazio(i,j);
        }

        if (level == 1)
            First_Map();
        else 
            Random_Map();
    }

    public void Insere_objeto(Objeto objeto) {
        if (objeto is Jewel) {
            collection.Add((Jewel)objeto);
        }
        Matriz[objeto.pos_x, objeto.pos_y] = objeto;
    }

    public void Print() {
        Console.WriteLine($"Level: {this.level}");
        for (int i = 0; i < Matriz.GetLength(0); i++) {
            for (int j = 0; j < Matriz.GetLength(1); j++) {
                Console.Write(Matriz[i,j]);
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }

    public void First_Map() {
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

    public void Random_Map() {
        Random r = new Random(1);
        int xRandom, yRandom;
        decimal qtd_jewel, qtd_tree, qtd_water;
        decimal proportion = size * size / 100;
        qtd_jewel = 2 * proportion;
        qtd_tree = 5 * proportion;
        qtd_water = 7 * proportion;
        qtd_jewel = (int)Math.Round(qtd_jewel);
        qtd_water = (int)Math.Round(qtd_water);
        qtd_tree = (int)Math.Round (qtd_tree);

        for(int i = 0; i <= qtd_jewel; i++) {
            xRandom = r.Next(0, size);
            yRandom = r.Next(0, size);
            if (Matriz[xRandom, yRandom] is Vazio && xRandom + yRandom != 0)
                this.Insere_objeto(new BlueJewel(xRandom, yRandom));
            else {i--;}
        }

        for(int i = 0; i <= qtd_jewel; i++) {
            xRandom = r.Next(0, size);
            yRandom = r.Next(0, size);
            if (Matriz[xRandom, yRandom] is Vazio && xRandom + yRandom != 0)
                this.Insere_objeto(new GreenJewel(xRandom, yRandom));
            else {i--;}
        }

        for(int i = 0; i <= qtd_jewel; i++) {
            xRandom = r.Next(0, size);
            yRandom = r.Next(0, size);
            if (Matriz[xRandom, yRandom] is Vazio && xRandom + yRandom != 0)
                this.Insere_objeto(new RedJewel(xRandom, yRandom));
            else {i--;}
        }

        for(int i = 0; i <= qtd_water; i++) {
            xRandom = r.Next(0, size);
            yRandom = r.Next(0, size);
            if (Matriz[xRandom, yRandom] is Vazio && xRandom + yRandom != 0)
                this.Insere_objeto(new Water(xRandom, yRandom));
            else {i--;}
        }

        for(int i = 0; i <= qtd_tree; i++) {
            xRandom = r.Next(0, size);
            yRandom = r.Next(0, size);
            if (Matriz[xRandom, yRandom] is Vazio && xRandom + yRandom != 0)
                this.Insere_objeto(new Tree(xRandom, yRandom));
            else {i--;}
        }
        bool radioactive = false;
        do {
            xRandom = r.Next(0, size);
            yRandom = r.Next(0, size);
            if (Matriz[xRandom, yRandom] is Vazio && xRandom + yRandom != 0) {
                this.Insere_objeto(new Radioactive(xRandom, yRandom));
                radioactive = true;
            }
        } while(!radioactive);
    }
}