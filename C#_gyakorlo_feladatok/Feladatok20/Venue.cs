using System.Text.Json;

namespace _9_Event9_Kozos;

class Venue
{
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public List<Event> Events { get; set; } = new List<Event>();


    public static Venue LoadFrom(string fileName)
    {
        try
        {

        string json = File.ReadAllText(fileName);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true, // Ha a JSON-ben más a kis-nagybetűzés
                Converters = {new System.Text.Json.Serialization.JsonStringEnumConverter() }// Időpontok felismerése
            };
        var venue = JsonSerializer.Deserialize<Venue>(json) ?? new Venue();
            if (venue == null)
            {
                Console.WriteLine("Figyelmeztetés: az érték null !");
                return new Venue();
            }
            return venue;
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Hiba történt a beolvasás közben:  {ex.Message}");
            return new Venue();
        }
    }

    public void Print()
    {
        Console.WriteLine($"Venue: {Name}, Address: {Address}");
        Console.WriteLine($"Events:");
        if (Events.Count == 0)
        {
            Console.WriteLine("No events !");
           
        }
        else
        {

           foreach (var e in Events)
           {
            Console.WriteLine($"- {e.Name}: {e.StartsAt.ToString("yyyy-MM-dd HH:mm")} to {e.EndsAt.ToString("yyyy-MM-dd HH:mm")}, Attendees: {e.GuestCount}");
           }
        }
    }
     
    public void ExportEventLengths(string fileName)
    {
        var eventLengths = new List<object>();
        foreach (var e in Events)
        {
            int duration = (int)(e.EndsAt - e.StartsAt).TotalMinutes;
            eventLengths.Add(new { e.Name, Duration = duration });
        }
        string json = JsonSerializer.Serialize(eventLengths, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(fileName, json);
    }
}


//Készíts egy Venue osztályt, ami egy rendezvény szervező helyszín adatait tárolja.Az
//osztályban tárolja a helyszín nevét és címét (szövegek), valamint az itt rendezett
//események listája.
//• A Venue osztálynak legyen egy statikus LoadFrom metódusa, amely paraméterben egy fájl nevét
//kapja, és egy helyszínnel (Venue) tér vissza.A paraméterben kapott fájl JSON formátumú, és
//tartalmaz minden adatot (név, cím, valamint események tömbje). A függvény olvassa be a fájlt,
//és térjen vissza egy újonnan létrehozott helyszínnel, amelyet a beolvasott adatokból épít fel.

//• Legyen a Venue osztálynak egy Print metódusa, amely megjeleníti az adatait a standard
//kimenetre a mintához hasonlóan.
//• Legyen a Venue osztálynak egy ExportEventLengths metódusa, amely paraméterben egy fájl
//nevet kap. A metódus a kapott fájlba JSON formátumban listázza ki, hogy melyik esemény
//milyen hosszú (hány percen keresztül tart, feltehetjük, hogy egész). A JSON fájl tartalma egy
//tömb legyen, melynek minden eleme egy esemény nevét és hosszát tárolja.
