namespace IVehicle7_onallo;

internal class Program
{
    static async Task Main()
    {
        VehicleManager vehicleManager = new VehicleManager();

        // Testing adding cars and trucks to the VehicleManager list
        vehicleManager.AddVehicle(new Car("Toyota", 120));
        vehicleManager.AddVehicle(new Truck("Volvo", 5000));

        vehicleManager.Print();
        Console.WriteLine();

        // Testing movement
        vehicleManager.MoveVehicles();
        Console.WriteLine();
        

        // Testing file handling - save and load
        FileHandling.Save("vehicles.txt", vehicleManager.Vehicles);
        List<IVehicle> loadedVehicles = FileHandling.Load("vehicles.txt");
        foreach (var vehicle in loadedVehicles)
        {
            vehicleManager.AddVehicle(vehicle);
        }
        Console.WriteLine();
        vehicleManager.Print();
        Console.WriteLine();

        FileHandling2.SaveToJson(vehicleManager.Vehicles);
         loadedVehicles = FileHandling2.LoadFromJson();

        // await vehicleManager.Countdown(5); // 💡 Az `await` biztosítja, hogy a visszaszámlálás befejeződjön, mielőtt továbbmennénk
        vehicleManager.Countdown(5);
        vehicleManager.MoveVehicles();

        // Testing countdown
        vehicleManager.Countdown();
    }
}