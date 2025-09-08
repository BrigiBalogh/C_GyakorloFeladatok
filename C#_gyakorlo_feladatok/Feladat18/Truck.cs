namespace IVehicle7_onallo;

class Truck : IVehicle
{
    public string Brand { get; }
    public int LoadCapacity { get; }

    public Truck(string brand, int loadCapacity)
    {
        Brand = brand;
        LoadCapacity = loadCapacity;
    }

    public void Move()
    {
        Console.WriteLine($"Moving: {Brand} the load capacity {LoadCapacity} kg.");
    }

    public override string ToString()
    {
        return $"Truck: {Brand}, Load Capacity: {LoadCapacity} kg";
    }
}
//Hozz létre egy Truck osztályt, amely szintén megvalósítja az IVehicle interfészt.
//A teherautónak legyen egy Brand és egy LoadCapacity tulajdonsága.
//Mindkét tulajdonság értékét konstruktor állítsa be.

 //public override string ToString()
 //   {
 //       return $"Truck: {Brand}, Load Capacity: {LoadCapacity} kg";
 //   }