
using System.Reflection.Metadata;

namespace Color8;

class RGBColor : Color
{
     public int Red { get; protected set; }
     public int Green { get; protected set; }
     public int Blue { get; protected set; }

    public RGBColor(int red, int green, int blue)
    {
        Red = red;
        Green = green;
        Blue = blue;
    }

    //az alapértelmezett(paraméter nélküli) konstruktor meghívja egy másik konstruktort
    public RGBColor() : this(0,0,0) { }

    public RGBColor(Color color) : this(color.R(), color.G(), color.B()) { }

    public override int B() => Blue;


    public override int G() => Green;

    public override int R() => Red;
    
}
//Származtass a Color osztályból egy RGBColor osztályt, amely három int típusként tárolja
//a szín három(r, g, b) komponensét.A három adatot a konstruktor várja, és állítsa be.
//Legyen az osztályban egy paraméter nélküli konstruktor is, amely a fekete színt állítja be.
//• Fejtsd ki az R, G, és B metódusokat az RGBColor osztályban úgy, hogy visszaadják
//a tárolt értékeket
