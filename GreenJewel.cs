public class GreenJewel : Jewel
{
    public GreenJewel(int x, int y) : base (x, y) {
        this.value = 50;
        this.cor = "Green";
    }

    public override string ToString() {return "JG";}
}