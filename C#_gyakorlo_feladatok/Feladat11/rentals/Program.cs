using System.Text.Json;

namespace rentals;

internal class Program
{
    static void Main(string[] args)
    {
        bool run = true;
        List<Rental> rentals = new();

        while (run)
        {
            Console.WriteLine("\n==== KÖLCSÖNZÉSI ALKALMAZÁS ====");
            Console.WriteLine("1. Adatok beolvasása fájlból");
            Console.WriteLine("2. Kategóriánkénti statisztika");
            Console.WriteLine("3. Új kölcsönzés rögzítése");
            Console.WriteLine("4. Kölcsönzések kilistázása");
            Console.WriteLine("5. Kilépés");
            Console.Write("Válassz: ");

            string answer = Console.ReadLine();

            switch (answer)
            {
                case "1":
                    // ide jön a beolvasás
                    rentals.Clear();
                    foreach (var line in File.ReadAllLines("rentals.txt"))
                    {
                        var parts = line.Split(';');
                        var rental = new Rental
                        {
                            Name = parts[0],
                            Category = parts[1],
                            Date = DateTime.Parse(parts[2])
                        };
                        rentals.Add(rental);
                    }
                    Console.WriteLine("Beolvasott kölcsönzések: ");
                    foreach (var r in rentals)
                    {
                        Console.WriteLine($"Név: {r.Name}, Kategória: {r.Category} dátum: {r.Date.ToShortDateString()}");

                    }
                    break;
                case "2":
                    // ide jön a statisztika
                    var categories = rentals
                        .GroupBy(r => r.Category)
                        .OrderBy(g => g.Key)
                        .ToList();

                    foreach (var group in categories)
                    {
                        Console.WriteLine($"\nKategória: {group.Key} ({group.Count()} kölcsönzés)");
                        foreach (var r in group)
                        {
                            Console.WriteLine($"  -{r.Name} ({r.Date.ToShortDateString()})");
                        }
                    }
                    break;
                case "3":
                    // ide jön az új kölcsönzés

                    Console.WriteLine("\nÚj kölcsönzés hozzáadása:");

                    Console.Write("Név: ");
                    string? newName = Console.ReadLine();

                    Console.Write("Kategória: ");
                    string? newCategory = Console.ReadLine();

                    Console.Write("Dátum: ");
                    string? newDateText = Console.ReadLine();
                    bool successfulDate = DateTime.TryParse(newDateText, out DateTime newDate);
                    if (successfulDate)
                    {

                        string newLine = $" {newName};{newCategory};{newDate:yyyy-MM-dd}";

                        File.AppendAllText("rentals.txt", newLine + Environment.NewLine);

                        Console.WriteLine("A kölcsönzés sikeresen hozzáadva a fájlhoz!");
                    }
                    else
                    {
                        Console.WriteLine("Hibás! A kölcsönzés nem került rögzítésre.");
                    }
                    break;
                case "4":
                    // ide jön az összesítés, kilistázás
                    var statistics = rentals
           .GroupBy(r => r.Category)
           .Select(g => new
           {
               Category = g.Key,
               piece = g.Count()
           });

                    foreach (var item in statistics)
                    {
                        Console.WriteLine($"{item.Category}: {item.piece} kölcsönzés");
                    }

                    Console.WriteLine("\nKezdő dátum: ");
                    DateTime.TryParse(Console.ReadLine(), out DateTime from);

                    Console.WriteLine("Záró dátum: ");
                    DateTime.TryParse(Console.ReadLine(), out DateTime to);

                    var filtered = rentals
                        .Where(r => r.Date >= from && r.Date <= to)
                        .OrderBy(r => r.Date);

                    Console.WriteLine($"Kölcsönzések {from:yyyy-MM-dd} és {to:yyyy-MM-dd} között: ");

                    foreach (var r in filtered)
                    {
                        Console.WriteLine($"{r.Name} {r.Category} {r.Date.ToShortDateString()}");
                    }

                    var mostRental = rentals
                        .GroupBy(r => r.Name)
                        .Select(g => new
                        {
                            Name = g.Key,
                            Count = g.Count()
                        })
                    .OrderByDescending(g => g.Count)
                    .FirstOrDefault();

                    if (mostRental != null)
                    {
                        Console.WriteLine($"\nLegtöbbet kölcsönző: {mostRental.Name} ({mostRental.Count} alkalommal)");
                    }
                    else
                    {
                        Console.WriteLine("Nincs adat a kölcsönzésekről.");
                    }

                    break;
                case "5":
                    run = false;
                    Console.WriteLine("Kilépés...");
                    break;
                default:
                    Console.WriteLine("Érvénytelen választás.");
                    break;


            }
        }
                    var topDay = rentals
                        .GroupBy(r => r.Date)
                        .Select(g => new { Date = g.Key, Count = g.Count() })
                        .OrderByDescending(g => g.Count)
                        .FirstOrDefault();
                    if(topDay != null)
                    {
                        Console.WriteLine($"\nLegforgalmassabb nap: {topDay.Date:yyyy-MM-dd} ({topDay.Count} kölcsönzés) ");

                    }

                    Console.WriteLine("\nTörlendő név: ");
                    string? delete = Console.ReadLine();

                    var newLines = File.ReadLines("rentals.txt")
                        .Where(line => !line.StartsWith(delete + ";", StringComparison.OrdinalIgnoreCase));

                    File.WriteAllLines("rentals.txt", newLines);
                    Console.WriteLine(" A törlés megtörtént a fájlban.");


        string json = JsonSerializer.Serialize(rentals, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("rentals.json", json);
        Console.WriteLine("A mentés a JSON formátumban megtörtént (rentals.json)");
    }
}
