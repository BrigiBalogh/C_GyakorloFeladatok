namespace IVehicle7_onallo;

static class FileHandling
{
    // private static string filePath = "vehicles.txt";

    //public static void Save(List<IVehicle> vehicles)
    //{
    //    using (StreamWriter writer = new StreamWriter(filePath))
    //    {
    //        foreach (var vehicle in vehicles)
    //        {
    //            if(vehicle is Car car )
    //            {
    //                writer.WriteLine($"Car,{car.Brand},{car.Speed}");
    //            }
    //            else if(vehicle is Truck truck)
    //            {
    //                writer.WriteLine($"Truck,{truck.Brand},{truck.LoadCapacity}");
    //            }

    //        }
    //    }
    //    Console.WriteLine("A mentés sikeres volt");
    //}
    public static void Save(string filePath, List<IVehicle> vehicles)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var vehicle in vehicles)
            {
                if (vehicle is Car car)
                {
                    writer.WriteLine($"Car,{car.Brand},{car.Speed}");
                }
                else if (vehicle is Truck truck)
                {
                    writer.WriteLine($"Truck,{truck.Brand},{truck.LoadCapacity}");
                }
            }
        }
        Console.WriteLine($"A mentés sikeres volt. {vehicles.Count} jármű mentve a {filePath} fájlba.");
    }




    //    public static List<IVehicle> Load()
    //    {
    //        List<IVehicle> vehicles = new List<IVehicle>();
    //        if (File.Exists(filePath))
    //        {
    //            using(StreamReader reader=new StreamReader(filePath))
    //            {
    //                string line;
    //                while((line = reader.ReadLine()) != null)
    //                {
    //                    string[] parts = line.Split(',');
    //                    if (parts.Length > 2)
    //                    {
    //                        string type = parts[0];
    //                        string brand = parts[1];

    //                    if(type=="Car" && int.TryParse(parts[2], out int speed))
    //                        {
    //                            vehicles.Add(new Car(brand, speed));
    //                        }
    //                        else if (type=="Truck" && int.TryParse(parts[2], out int loadCapacity))
    //                        {
    //                            vehicles.Add(new Truck(brand, loadCapacity));
    //                        }
    //                    }
    //                }
    //            }
    //            Console.WriteLine("A fájl betöltése sikeres.");
    //        }
    //        return vehicles;
    //    }


    public static List<IVehicle> Load(string filePath)
    {
        List<IVehicle> vehicles = new List<IVehicle>();

        if (File.Exists(filePath))
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                string[] parts;
                while ((line = reader.ReadLine()) != null)
                {
                    if (!string.IsNullOrEmpty(line))
                    {

                     parts = line.Split(',');
                    }
                    else
                    {
                        parts = new string[0];// 💡 Ha üres a sor, akkor üres tömböt adunk neki, hogy elkerüljük a hibát
                    }

                    if (parts.Length > 2)
                    {
                        string type = parts[0];
                        string brand = parts[1];

                        if (type == "Car" && int.TryParse(parts[2], out int speed))
                        {
                            vehicles.Add(new Car(brand, speed));
                        }
                        else if (type == "Truck" && int.TryParse(parts[2], out int loadCapacity))
                        {
                            vehicles.Add(new Truck(brand, loadCapacity));
                        }
                    }
                }
            }
            Console.WriteLine($"A fájl betöltése sikeres. {vehicles.Count} jármű betöltve a {filePath} fájlból.");
        }

        return vehicles;
    }


}
