using System.Runtime.CompilerServices;
using System.Text.Json;
using IAudio7_kozos;
//using Newtonsoft.Json;
namespace IAudio7_kozos;
   

public static class FileHandling
{
//    private static string filePath = "audio.json";

//    public static void SaveToJson(List<IAudio> audioList)
//    {
//        string json = JsonConvert.SerializeObject(audioList, Formatting.Indented,
//            new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });

//        File.WriteAllText(filePath, json);
//        Console.WriteLine("Hangszerek JSON fájlba mentve.");
//    }

//    public static List<IAudio> LoadFromJson()
//    {
//        if (File.Exists(filePath))
//        {
//            string json = File.ReadAllText(filePath);
//            return JsonConvert.DeserializeObject<List<IAudio>>(json,
//                new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All }) ?? new List<IAudio>();
//        }
//        return new List<IAudio>();
//    }
//}






    public static void Save(string filePath, List<IAudio> audios)
    {
        using(StreamWriter writer= new StreamWriter(filePath))
        {
            foreach (var audio in audios)
            {
                if(audio is CD cd)
                {
                    writer.WriteLine($"CD;{cd.Title};{cd.Length}");
                }
                else if(audio is Cassette cassette)
                {
                    writer.WriteLine($"Cassette;{cassette.Title};{cassette.NumberOfSides}");
                }    
            }
        }
        Console.WriteLine("Az adatok sikeresen elmentve a fájlba!");
    }



    public static List<IAudio> Load(string filePath)
    {
        List<IAudio> audios = new List<IAudio>();
        if (!File.Exists(filePath))
        {
            Console.WriteLine("A fájl nem található! A lista üres.");
            return audios;
        }
        using(StreamReader reader= new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) !=null)
            {
                string[] parts = line.Split(';');
                if (parts.Length < 3) continue; // Ha hibás a sor, kihagyjuk
                string type = parts[0];
                string title = parts[1];
                if(type=="CD" && int.TryParse(parts[2], out int length))
                {
                    audios.Add(new CD(title, length));
                }
                else if(type=="Cassette" && int.TryParse(parts[2], out int numberOfSides))
                {
                    audios.Add(new Cassette(title, numberOfSides));
                }
            }
        }
        Console.WriteLine("Az adatok sikeresen betöltve a fájlból!");
        return audios;

    }

}
                
