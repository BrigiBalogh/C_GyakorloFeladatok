namespace IVehicle7_onallo;

class Car : IVehicle
{
    public Car(string brand, int speed)
    {
        Brand = brand;
        Speed = speed;
    }

    public string Brand { get; }
    public int Speed { get; }

    public void Move()
    {
        Console.WriteLine($"Moving: {Brand} the speed {Speed} km/h.");
    }

    public override string ToString()
    {
        return $"Car: {Brand}, Speed: {Speed} km/h";
    }
}

//Az interfészben található Move függvény megvalósítása mindkét osztály esetében írja ki
//azt, hogy „Moving: ” és az adott jármű adatait.

//• Mindkét osztályban írd felül a ToString virtuális függvényt úgy, hogy a Car illetve a
//Truck adataival térjen vissza.

//Hozz létre egy Car osztályt, amely megvalósítja az IVehicle interfészt.Az autónak legyen egy
//Brand és egy Speed tulajdonsága.Mindkét tulajdonság értékét konstruktor állítsa be.

