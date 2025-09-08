namespace Vehicle4_onallo;

internal class Vehicle
{
    public string Type { get; }
    public static int NumberOfWheels { get; set; } = 4;

   
    public Vehicle(string type)
    {
        Type = type;
    }
}

//A Vehicle osztályban legyen egy statikus adattag, ami a program minden részén számon tartja,
//hogy hány kereke van a járműnek(NumberOfWheels). Lehessen a darabszámot beállítani és
//lekérdezni(get, set). Alapértelmezetten legyen az értéke 4.
