
namespace Vehicle6_kozos;

class Airplane : Vehicle
{ 
    public int PassengerCount { get; private set; }
    public int Wheels { get; private set; }


    public Airplane(int mass, int speed, int passengerCount, int wheels) : base(mass, speed)
    {
        PassengerCount = passengerCount;
        Wheels = wheels;
    }



    public override void Print()
    {
        Console.WriteLine($"Tömeg: {Mass}, Sebesség: {Speed}, " +
            $"az utasok száma: {PassengerCount}, a kerekek száma: {Wheels}");
    }

    public override int GetNumberOfWheels()
    {
        return Wheels;
    }


}
//Származtass a Vehicle osztályból két másik osztályt: az Airplane osztály tároljon még egy utas
//létszámot és a repülő kerekeinek a számát, a Ship osztály pedig tároljon még egy teherbírás
//értéket. Mindkét osztály a konstruktorban várja az új értékeket is.