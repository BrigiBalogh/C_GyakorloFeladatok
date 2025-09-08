namespace Car_exercise;

class Vehicle
{
    public string Brand { get; set; } = string.Empty;

    public virtual string GetInfo()
    {
        return $"Brand: {Brand}";
    }
}
