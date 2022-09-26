public class RedJewel : Jewel
{
    public RedJewel(int x, int y) : base (x, y) {
        this.value = 100;
        this.cor = "Red";
    }

    public override string ToString() {return "JR";}

}