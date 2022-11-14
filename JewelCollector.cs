/// <summary>
/// Essa classe representa o jogo.
/// </summary>
public class JewelCollector
{

    delegate void RoboMove(int x, int y);
    static event RoboMove OnRoboMove;

    /// <summary>
    /// Método responsável por iniciar o mapa e o robô.
    /// </summary>
    public static void Main()
    {
        int size = 10;
        int level = 1;
        Bag Bag = new Bag();
        bool GameRunning = true;

        while (GameRunning)
        {
            Map mapa = new Map(size, level);
            Robot Robo = new Robot(0, 0, mapa, Bag);
            Run(Robo);

            if (mapa.level_cleared)
            {
                if (size < 30)
                    size++;
                level++;
            }
            else
            {
                GameRunning = false;
            }
        }
    }

    private static void Run(Robot Robo)
    {
        OnRoboMove += Robo.RoboMove;
        do
        {
            Robo.Print();
            Console.Write("Enter the command: ");
            string? command = Console.ReadLine();
            Console.WriteLine();
            if (command.Equals("quit"))
            {
                Robo.Quit();
            }
            else if (command.Equals("w"))
            {
                OnRoboMove(-1, 0);
            }
            else if (command.Equals("a"))
            {
                OnRoboMove(0, -1);
            }
            else if (command.Equals("s"))
            {
                OnRoboMove(1, 0);
            }
            else if (command.Equals("d"))
            {
                OnRoboMove(0, 1);
            }
            else if (command.Equals("g"))
            {
                Robo.Check_Item();
            }
        } while (Robo.running);
    }
}