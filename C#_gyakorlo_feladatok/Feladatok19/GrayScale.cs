namespace Color8;

class GrayScale : Color
{
    private readonly double brightness;

    public GrayScale(double brightness)
    {
        this.brightness = Math.Clamp(brightness, 0.0, 1.0);
    }

    public override int B() => (int)(brightness * 255);


    public override int G() => (int)(brightness * 255);


    public override int R() => (int)(brightness * 255);
    
}
//• Származtass egy GrayScale osztályt a Color osztályból, amely lebegőpontos értéket tárol, 0 és 1
//között.Ez azt mondja meg, hogy a szürke szín mennyire világos(0-teljesen fekete, 1-teljesen
//fehér, közte egyenletesen változik). Fejtsd ki az R, G, és B függvényeket az osztályban.

