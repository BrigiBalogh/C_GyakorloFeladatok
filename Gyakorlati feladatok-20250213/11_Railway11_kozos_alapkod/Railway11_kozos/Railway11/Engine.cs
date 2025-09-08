namespace Railway11;

class Engine : Vehicle
{

    public double TowableMass { get;}
    public override string Type => "Engine";
    public Engine(string id, double mass, int speed, double towableMass)
        : base(id, mass, speed)
    {
        TowableMass = towableMass;
    }



    public override void PrintDetails()
    {
        Console.WriteLine($"Engine-ID: {Id} mass: {Mass} kg, speed: {Speed} km/h,towable mass: {TowableMass} kg");
    }
}
//Engine: a mozdonyt reprezentálja, legyen egy plusz tulajdonsága, amely a
//mozdony által elvontatható tömeget adja meg(TowableMass : double). A
//típusának gettere az Engine értékkel térjen vissza.