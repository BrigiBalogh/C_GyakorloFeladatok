

namespace _9_Event9_Kozos;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\n\nVenue.LoadFrom() test\n");
        Venue v = Venue.LoadFrom("venue.json");

        Console.WriteLine("\n\nVenue.Print() test\n");
        v.Print();
    //Venue: Varosi rendezveny kozpont(3214, Valami Varos, xy utca 10)
    //      szinhazi eloadas(140 guests)
    //        from 2023 - 06 - 20 19:15
    //        until 2023 - 06 - 20 22:40
    //      unnepi vacsora(80 guests)
    //        from 2023 - 05 - 19 20:00
    //        until 2023 - 05 - 19 23:00
    //      szerepjatek est(25 guests)
    //        from 2023 - 07 - 28 16:00
    //        until 2023 - 07 - 29 06:30
    //      festeszeti kiallitas(583 guests)
    //        from 2023 - 05 - 30 08:30
    //        until 2023 - 05 - 30 19:00
    //      virag vasar(319 guests)
    //        from 2023 - 06 - 03 10:00
    //        until 2023 - 06 - 03 20:00
    //      zenei est(89 guests)
    //        from 2023 - 06 - 11 18:00
    //        until 2023 - 06 - 12 02:00

        Console.WriteLine("\n\nVenue.ExportEventLengths() test\n");
        v.ExportEventLengths("event_lengths.json");
        string outputJson = File.ReadAllText("event_lengths.json");// ez fontos +sor 
        Console.WriteLine("Exported JSON Content:\n" + outputJson);//ez is 

        Console.WriteLine("Press any key to exit...");// ez nem
        Console.ReadLine(); //ez sem
//        [
//          {
//            "EventName": "szinhazi eloadas",
//            "LengthInMinutes": 205
//          },
//          {
//            "EventName": "unnepi vacsora",
//            "LengthInMinutes": 180
//          },
//{
//            "EventName": "szerepjatek est",
//            //"LengthInMinutes": 870
//          },
//          {
//            "EventName": "festeszeti kiallitas",
//            "LengthInMinutes": 630
//          },
//          {
//            "EventName": "virag vasar",
//            "LengthInMinutes": 600
//          },
//          {
//            "EventName": "zenei est",
//            "LengthInMinutes": 480
//          }
//        ]
    }
}
