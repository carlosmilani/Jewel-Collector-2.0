public class BlueJewel : Jewel
{
    public BlueJewel(int x, int y) : base (x, y) {
        this.value = 10;
        this.cor = "Blue";
        this.energy = 5;
    }

    public override string ToString() {return "JB";}
}