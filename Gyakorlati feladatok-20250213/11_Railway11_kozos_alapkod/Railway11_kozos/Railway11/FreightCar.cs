namespace Railway11;

class FreightCar : Vehicle
{

    public double Capacity { get; }

    public override string Type => "FreightCar";
    public FreightCar(string id, double mass, int speed, double capacity)
        : base(id, mass, speed)
    {
        Capacity = capacity;
    }

    public override void PrintDetails()
    {
        Console.WriteLine($"FreightCar - ID: {Id} mass: {Mass} kg, speed: {Speed} km/h, capacity: {Capacity} kg");
    }
}
//o FreightCar: a tehervagonokat írja le, legyen egy plusz tulajdonsága, amely a
//tehervagonban szállítható termékek mennyiségét adja meg(Capacity : double). A
//típusának gettere a FreightCar értékkel térjen vissza.
