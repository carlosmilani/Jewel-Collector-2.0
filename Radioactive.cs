public class Radioactive : Objeto {
    public int energy {get; private set;}
    public int near_energy {get; private set;}

    public Radioactive(int x, int y) : base(x, y) {
        this.energy = -30;
        this.near_energy = -10;
    }
    public override string ToString() {return "!!";}
}