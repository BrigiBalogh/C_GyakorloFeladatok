namespace IVehicle7_onallo;

internal class VehicleManager
{
    public List<IVehicle> Vehicles { get; } = new List<IVehicle>();

    public void Print()
    {
        Console.WriteLine("Vehicle list:");
        foreach (var vehicle in Vehicles)
        {
            Console.WriteLine(vehicle);
        }
    }

    public void AddVehicle(IVehicle vehicle)
    {
        Vehicles.Add(vehicle);
    }

    public void MoveVehicles()
    {
        foreach (var vehicle in Vehicles)
        {
            vehicle.Move();
        }
    }

    //public async Task Countdown(int seconds)
    //{
    //    Console.WriteLine("Visszaszámlálás indul...");
    //    for (int i  = seconds;  i > 0; i--)
    //    {
    //        Console.WriteLine($"Hátralévő idő: {i} másodperc");
    //        await Task.Delay(1000); //1 másodperces késleltetés   
    //    }
    //    Console.WriteLine("A visszazsámlálás véget ért! A járművek mozognak...");
    //}

    public  void Countdown(int seconds = 5)
    {
        Console.WriteLine("Visszaszámlálás indul...");

        char[] spinner = { '|', '/', '-', '\\' };
        for (int i = seconds; i > 0; i--)
        {
            foreach (char c in spinner)
            {
                Console.Write($"\rHátralévő idő: {i} másodperc. {c}");
                Thread.Sleep(250); // Negyed másodpercenként vált karaktert
            }
        }

        Console.WriteLine("\nA visszazsámlálás véget ért! A járművek mozognak...");
    }


    //public void Countdown()
    //{
    //    int seconds = 5; // Alapértelmezett visszaszámlálási idő
    //    Console.WriteLine("Visszaszámlálás indul...");

    //    for (int i = seconds; i > 0; i--)
    //    {
    //        Console.WriteLine($"Hátralévő idő: {i} másodperc");
    //        System.Threading.Thread.Sleep(1000); // Blokkolja a futást 1 másodpercig
    //    }

    //    Console.WriteLine("Visszaszámlálás véget ért!");
    //}

    public async Task Countdown()
    {
        int seconds = 5; // Alapértelmezett visszaszámlálási idő
        Console.WriteLine("Visszaszámlálás indul...");

        for (int i = seconds; i > 0; i--)
        {
            Console.WriteLine($"Hátralévő idő: {i} másodperc");
            await Task.Delay(1000);
        }

        Console.WriteLine("Visszaszámlálás véget ért!");
    }
}

//Írj egy metódust a VehicleManager osztályban, ami mozgatja a hozzáadott járműveket
//(MoveVehicles). A mozgatás során írd ki a konzolra a járművek márkáját és sebességét
//vagy teherbírását.Ehhez használja a járművek Move függvényét.
