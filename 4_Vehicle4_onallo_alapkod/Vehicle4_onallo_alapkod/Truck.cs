namespace Vehicle4_onallo;

class Truck : Vehicle
{
    public Truck(string type, int maximumTransportableMass) : base(type)
    {
        MaximumTransportableMass = maximumTransportableMass; // Nem kell a NumberOfWheels, mert az statikus
    }

    public int MaximumTransportableMass { get; }
    public static new int NumberOfWheels { get; set; } = 18;

    public void Write()
    {
        Console.WriteLine($"A kamion típusa: {Type}, kerekeinek a száma {NumberOfWheels}" +
            $"a maximálisan elszállítható súly {MaximumTransportableMass} tonna.");
    }
}







//Származtass egy Truck osztályt a Vehicle osztályból, ami egy kamion adatait tárolja.A
//kamionnak legyen egy adattagja, amely a maximálisan elszállítható tömeget tárolja.Ezt a
//konstruktor állítsa be és legyen publikusan lekérdezhető egy property-n keresztül.
//• A Truck osztályban is legyen egy statikus adattag a kerekek számának (NumberOfWheels).
//Lehessen a darabszámot beállítani és lekérdezni (get, set). Alapértelmezetten legyen az értéke
//18.
//• Készíts a Truck osztályba egy Write függvényt, amely megjeleníti az eltárolt kamion típusát,
//kerekeinek számát és a maximálisan elszállítható tömeget.
