using Newtonsoft.Json;
namespace IVehicle7_onallo;

class FileHandling2
{
    private static string filePath = "vehicles.json";

    public static void SaveToJson(List<IVehicle> vehicles)
    {
        string json = JsonConvert.SerializeObject(vehicles, Formatting.Indented,
            new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });

        File.WriteAllText(filePath, json);
        Console.WriteLine("A mentés sikerült.{vehicles.Count} jármű betöltve. A járművek JSON fájlba mentve");
    }

    public static List<IVehicle> LoadFromJson()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<IVehicle>>(json,
                new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All }) ?? new List<IVehicle>();
        }
        return new List<IVehicle>();
    }
  
}
