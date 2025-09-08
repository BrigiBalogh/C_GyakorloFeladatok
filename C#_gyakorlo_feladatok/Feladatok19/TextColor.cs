namespace Color8;

class TextColor : RGBColor
{
    
    
    private static readonly Dictionary<string, (int R, int G, int B)> ColorMap = new Dictionary<string, (int R, int G, int B)>()
    {
        {"black",(0,0,0) },
        {"white",(255,255,255) },
        {"blue",(0,0,255) },
        {"green",(0,255,0) },
        {"red",(255,0,0) },
        {"cyan",(0,255,255) },
        {"magenta",(255,0,255) },
        {"yellow",(255,255,0) },
    };

    public string ColorName { get; }


    public TextColor(string colorName) : base(0, 0, 0)
    {
        if (ColorMap.TryGetValue(colorName.ToLower(), out var colorRgb))
        {
            Red = colorRgb.R;
            Green = colorRgb.G;
            Blue = colorRgb.B;
            ColorName = colorName;
        }
        else if(colorName.StartsWith('#')&& colorName.Length == 7)
        {
            Red = Convert.ToInt32(colorName.Substring(1, 2), 16);
            Green = Convert.ToInt32(colorName.Substring(3, 2), 16);
            Blue = Convert.ToInt32(colorName.Substring(5, 2), 16);
            ColorName = colorName;
        }
        else
        {
            ColorName = "black";
        }
        
    }

   
    public override string ToString()
    {
        return ColorName;
    }
}
//Származtass egy TextColor osztályt az RGBColor osztályból.
//Ez tároljon még egy szöveget, ami a szín szöveges megnevezése
//(„black”, „green”, stb.). A konstruktora csak ezt a szöveget várja, és
//állítsa be a szín komponenseit a megfelelő értékre.
//Ha a megkapott szöveg nincs a lehetőségek
//között(lásd a táblázatot a feladat után) akkor a fekete színt tárolja el.
//• A TextColor osztály konstruktorát módosítsd úgy,
//hogy a hexadecimális kódban megadott színt
//is elfogadja (’#’ az első karaktere),
//és az alapján is be tudja állítani a komponenseket.
//• Írd felül a ToString metódust a TextColor osztályban úgy,
//hogy a hexadecimális forma helyett a
//szín eltárolt megnevezését adja vissza.
