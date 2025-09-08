
namespace Vehicle6_kozos;

class Ship : Vehicle
{
    public int LoadCapacity { get; private set; }

    public Ship(int mass, int speed, int loadCapacity) : base(mass, speed)
    {
        LoadCapacity = loadCapacity;
    }

    public override  void Print()
    {
        Console.WriteLine($"Tömeg: {Mass}, Sebesség: {Speed}, teherbírás: {LoadCapacity}");
    }


    public override int GetNumberOfWheels()
    {
        return 0;
    }
}
