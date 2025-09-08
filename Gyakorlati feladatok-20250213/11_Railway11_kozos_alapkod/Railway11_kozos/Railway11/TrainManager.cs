
namespace Railway11;

class TrainManager
{
    public List<Vehicle> Vehicles { get; }
    public List<TrainSet> Sets { get; }

    public TrainManager()
    {
        Vehicles = new List<Vehicle>();
        Sets = new List<TrainSet>();
    }

    public void AddVehicle(Vehicle vehicle)
    {
        Vehicles.Add(vehicle);
    }
    public void RemoveVehicle(Vehicle vehicle)
    {
        Vehicles.Remove(vehicle);
    } 

    public void Print()
    {
        foreach (var vehicle in Vehicles)
        {
            vehicle.PrintDetails();
        }
    }

    public bool CoupleSet(List<Vehicle> vehicles)
    {
        Engine? engine = GetEngine(vehicles);
        int engineCount = 0;
        foreach (var vehicle in vehicles)
        {
            if (vehicle is Engine)
            {
                engineCount++;
            }
        }
        if (engine != null && engineCount == 1 && vehicles.Count > 1)
        {
            var set = new TrainSet(vehicles);
            if (set.EngineCanTowed())
            {
                Sets.Add(set);
                return true;
            }
        }
        return false;
    }

    public void DecoupleSet(TrainSet set)
    {
        Sets.Remove(set);
    }

    public TrainSet? SearchSet(string engineId)
    {
        foreach (var set in Sets)
        {
            if(set.GetEngineId()== engineId)
             return set;   
        }
        return null;
    }

    public void PrintTrainSets()
    {
        foreach (var set in Sets)
            set.Print();   
    }

    private Engine? GetEngine(List<Vehicle> vehicles)
    {
        foreach (var vehicle in vehicles)
        {
            if(vehicle is Engine engine)
            {
                return engine;
            }
        }
        return null;
    }

}
 
////Hozz létre egy TrainManager nevű osztályt, amely a vasúti járműveink kezelését valósítja
//meg.Az osztály egy listában tárolja a járműveinket (Vehicles : List). Ezt a listát a
//konstruktora hozza létre üresen
//• A TrainManager osztályba hozd létre az AddVehicle függvényt, amely paraméterben egy
//járművet vár és hozzáadja a listánkhoz.Ennek párjaként hozd létre a RemoveVehicle
//függvényt, amely a paraméterben kapott járművet törli a nyilvántartásból.
//• A TrainManager osztályba hozz létre egy Print függvényt, amely kiírja a járművek adatait.
//Ehhez használd a PrintDetails függvényét a járműveknek.

//• A TrainManager osztályt módosítsd úgy, hogy szerelvények listáját is tudja tárolni, amit
//szintén a konstruktora hoz létre üresen(Sets : List).
//• A TrainManager osztály tartalmazzon egy CoupleSet függvényt, amely paraméterben vár
//járműlistát és azzal tér vissza, hogy abból sikerül-e egy szerelvényt összeállítani.Egy
//szerelvény akkor állítható össze, ha pontosan 1 mozdony és legalább 1 vagon van benne
//és a mozdony képes elvontatni a vagonokat.

//• A TrainManager osztály tartalmazzon egy DecoupleSet függvényt, amely egy szerelvényt
//vár paraméterben, és eltávolítja azt a szerelvényeink listájából.
//• A TrainManager osztályban valósíts meg egy SearchSet függvényt, amely paraméterben
//egy mozdony azonosítóját kapja meg, és ez alapján visszaadja a teljes szerelvényt.Ha nem
//találja a szerelvényt, akkor null értékkel térjen vissza.
//• A TrainManager osztály tartalmazzon továbbá egy PrintTrainSets függvényt, amely kiírja a
//tárolt szerelvények adatait. Ehhez használd a TrainSet Print metódusát.