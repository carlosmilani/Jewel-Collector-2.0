public class Tree : Obstacle
{
    public int energy = 3;
    public Tree(int x, int y) : base(x, y) {}
    public override string ToString() {return "$$";}
}