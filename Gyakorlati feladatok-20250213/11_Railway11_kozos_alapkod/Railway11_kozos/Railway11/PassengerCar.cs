namespace Railway11;

class PassengerCar : Vehicle
{

    public int PassengerNumber { get; }

    public override string Type => "PassengerCar";
    public PassengerCar(string id, double mass, int speed, int passengerNumber) 
        : base(id, mass, speed)
    {
        PassengerNumber = passengerNumber;
    }

    public override void PrintDetails()
    {
        Console.WriteLine($"PassengerCar - ID: {Id} mass: {Mass} kg, speed: {Speed} km/h, passenger number: {PassengerNumber}");
    }
}
//PassengerCar: a személykocsikat írja le, legyen egy plusz tulajdonsága, amely a
//szállítható utasok számát adja meg(PassengerNumber : int). A típusának
//gettere a PassengerCar értékkel térjen vissza