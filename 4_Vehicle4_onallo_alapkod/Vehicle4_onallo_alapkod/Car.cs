namespace Vehicle4_onallo;

class Car : Vehicle
{
    public Car(string type, int numberOfTransportedPersons = 4) : base(type)
    {
        NumberOfTransportedPersons = numberOfTransportedPersons;
    }

    public int NumberOfTransportedPersons { get; set; }

    public void Write()
    {
        Console.WriteLine($"Az autó típusa: {Type}, " +
            $"kerekeinek száma: {NumberOfWheels}," +
            $" a szállítható személyek száma: {NumberOfTransportedPersons}");
    }

   

}
//Készíts a Car osztályba egy Write függvényt, amely megjeleníti az eltárolt autó típusát,
//kerekeinek számát és a szállítható személyek számát.

//Származtass a Vehicle osztályból egy Car osztályt, ami tárolja még a szállítható személyek
//számát.Készítsd el a megfelelő konstruktort(Main függvény alapján), illetve az új adattaghoz a
//setter és getter függvényeket.

