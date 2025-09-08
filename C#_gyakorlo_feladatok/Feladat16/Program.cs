
namespace Vehicle6_kozos
{
    internal class Program
    {
        static void PrintVehicle(Vehicle vehicle)
        {
            vehicle.Print();
        }

        static void PrintNumberOfWheels(Vehicle vehicle)
        {
            Console.WriteLine($"A jármű kerekeinek száma: {vehicle.GetNumberOfWheels()}");
        }

        static void Main(string[] args)
        {
            Container c1 = new Container();

             //Vehicle osztály teszt
            //Console.WriteLine("Vehicle teszt");
            //Vehicle v1 = new Vehicle(5, 6);
            //v1.Print();

            // Container osztály teszt
            Console.WriteLine();
            Console.WriteLine("Container teszt");
            c1.Print();
            c1.Set(2, new Ship(3, 7, 100));
            c1.Set(4, new Airplane(8, 1, 50, 3));
            c1.Print();
            c1.Set(6, new Ship(1, 2, 150));
            c1.Print();
            c1.Set(2, new Ship(1, 9, 75));
            c1.Print();
           
            // Airplane és Ship teszt
            Console.WriteLine();
            Console.WriteLine("Airplane es Ship teszt");
            Airplane a1 = new Airplane(12, 13, 14, 16);
            Ship s1 = new Ship(65, 54, 43);
            a1.Print();
            s1.Print();
            c1.Set(0, new Ship(32, 33, 34));
            c1.Set(1, new Airplane(76, 86, 96, 20));
            c1.Print();

            // virtuális Print függvény teszt
            Console.WriteLine();
            Console.WriteLine("virtualis Print teszt");
            PrintVehicle(s1);
            PrintVehicle(a1);

            //GetNumberOfWheels függvény teszt
            Console.WriteLine();
            Console.WriteLine("GetNumberOfWheels függvény teszt");
            PrintNumberOfWheels(s1);
            PrintNumberOfWheels(a1);
        }
    }
}