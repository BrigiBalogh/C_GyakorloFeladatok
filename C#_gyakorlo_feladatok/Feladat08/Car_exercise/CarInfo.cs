namespace Car_exercise;

class CarInfo : Document
{
    private Car car;
    public CarInfo(Car car)
    {
        this.car = car;
        Details = $"Részletek: {car.GetInfo()}";

    }

    public override void Print()
    {
        Console.WriteLine(Details);
        Console.WriteLine($"Évjárat: {car.Year}");

    }
}
