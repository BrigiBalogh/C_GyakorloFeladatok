namespace Car_exercise;

class Car : Vehicle, IRegistrable
{
    public static int Counter = 0;


    public string Model { get; set; } = string.Empty;
    public string LicensePlate { get; set; } = string.Empty;
    public int Year { get; set; }
    public Car()
    {
        Counter++;
    }

    public override string GetInfo()
    {
        return $"{Brand} {Model} ({LicensePlate}), évjarat: {Year}";
    }

    public string GetLicensePlate()
    {
        return LicensePlate;
    }
}
