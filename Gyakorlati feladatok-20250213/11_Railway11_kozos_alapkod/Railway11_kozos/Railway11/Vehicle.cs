namespace Railway11;

 public abstract class Vehicle
{
    public string Id { get; }
    public double Mass { get; } 
    public int Speed { get; }
    public abstract string Type { get; }
    protected Vehicle(string id, double mass, int speed)
    {
        Id = id;
        Mass = mass;
        Speed = speed;
    }

    public abstract void PrintDetails();

}
//Készíts egy absztrakt osztályt, amely vasúti járműveket reprezentál, a neve legyen Vehicle.A
//járműveknek legyen egy azonosítója (Id : string), egy tömege(Mass : double),
//egy sebessége(Speed : int) és egy absztrakt típusa(Type : string), amely
//csak getterrel rendelkezik.Az osztálynak legyen egy konstruktora, amely a
//típuson kívül minden más tulajdonságot megkap paraméterben és beállítja
//azokat.
//Készíts a Vehicle osztályba egy absztrakt PrintDetails metódust.A metódusnak ne legyen
//visszatérési értéke és ne várjon semmit paraméterben. A függvény az egyes járművek
//tulajdonságait írja ki a konzolra. Valósítsd meg a PrintDetails függvényt a
//gyerekosztályokban