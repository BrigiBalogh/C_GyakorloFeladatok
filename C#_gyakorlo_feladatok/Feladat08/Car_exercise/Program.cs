using System.Text.Json;

namespace Car_exercise;

internal class Program
{
    static void Main()
    {
         List<Car>cars = LoadCars();



        // Repository példány
        var repo = new Repository<Car>();

        // Feltöltés a repóba
        foreach (var car in cars)
        {
            repo.Add(car);
        }

        // Keresés a megadott rendszám alapján
        var found = repo.FindByLicensePlate("XYZ-789");

        if (found != null)
        {
            Console.WriteLine("\nTalált autó:");
            Console.WriteLine(found.GetInfo());
        }
        else
        {
            Console.WriteLine("\nNem található ilyen rendszámú autó.");
        }

        var filteredCars = cars.Where(c => c.Year > 2019)
                                    .OrderBy(C => C.Brand)
                                    .ThenBy(C => C.Year);
        foreach(var car in filteredCars)
        {
            Console.WriteLine($"{car.Brand} {car.Model}-{car.Year}");

        }
    }

    static List<Car> LoadCars()
    {
        string json = File.ReadAllText("cars.json");
        List<Car>? cars = JsonSerializer.Deserialize<List<Car>>(json);
        if (cars != null)
        {
            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Brand} {car.Model} ({car.LicensePlate})");
            }

            Console.WriteLine($"Counter: {Car.Counter}");
            return cars;
        }
        else
        {
            Console.WriteLine("A JSON beolvasása nem sikerült vagy üres.");
            return new List<Car>();
        }
    }
}
