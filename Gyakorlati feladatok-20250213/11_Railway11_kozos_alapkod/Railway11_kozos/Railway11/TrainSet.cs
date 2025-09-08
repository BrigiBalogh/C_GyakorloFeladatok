using System.Collections.Generic;
using Railway11;

namespace Railway11;

class TrainSet
{
    public List<Vehicle> Vehicles { get; }

    public TrainSet(List<Vehicle> vehicles)
    {
        int engineCount = 0;
        foreach (var vehicle in vehicles)
        {
            if(vehicle is Engine)
            {
                engineCount++;
            }    
        }
            if(engineCount != 1)
            {
                throw new ArgumentException("Több, mint egy mozdony van !");
            }
        Vehicles = vehicles;
    }

    public bool EngineCanTowed()
    {
        Engine? engine = null;
        double totalMass = 0.0;
        foreach (var vehicle in Vehicles)
        {
            if(vehicle is Engine eng)
            {
                engine = eng;
            }
            else
            {
                totalMass += vehicle.Mass;
            }
        }
       return engine != null && engine.TowableMass >= totalMass;
    }

    public string? GetEngineId()
    {
        var engine = GetEngine();
        return engine != null ? engine.Id : null;
    }

    public void Print()
    {
        Console.WriteLine("Train Set details: ");
        foreach (var vehicle in Vehicles)
        {
            vehicle.PrintDetails();
        }
    }

    private Engine? GetEngine()
    {
        foreach (var vehicle in Vehicles)
        {
            if (vehicle is Engine engine)
            {
                return engine;
            }
        }
        return null;
    }
}

 //Készíts egy TrainSet osztályt, amely egy szerelvényt reprezentál.A szerelvény járművekből
 //áll, ezeket egy listában tároljuk(Vehicles : List). Az osztálynak legyen egy konstruktora,
 //amely a járművek listáját várja paraméterben és ez alapján beállítja a szerelvény
 //járműveinek listáját.
 //• A TrainSet osztályba készíts egy EngineCanTowed függvényt, amely azzal tér vissza, hogy
 //a szerelvény mozdonya el tudja-e vontatni a vagonokat a tömegük alapján.A mozdony
 //saját tömegét nem kell ebbe beleszámolni.
 //• A TrainSet osztályba készíts egy GetEngineId függvényt, amely visszatér a szerelvény
 //mozdonyának azonosítójával (feltételezzük, hogy egy szerelvényben egy mozdony van).