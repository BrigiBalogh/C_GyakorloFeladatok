using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Vehicle6_kozos;

internal abstract class Vehicle
{
    public int Mass { get; set; }
    public int Speed { get; set; }

    public Vehicle(int mass, int speed)
    {
        Mass = mass;
        Speed = speed;
    }

    public virtual void Print()
    {
        Console.WriteLine($"Tömeg: {Mass}, Sebesség: {Speed}");
    }

    public abstract int GetNumberOfWheels();
}
//A Vehicle osztályban van egy Print függvény, amely megjeleníti az adatokat.Ez a függvényt
//fejtsd ki a gyerekosztályokban is.
//• A Vehicle osztály Print függvényét tedd virtuálissá, a gyerekosztályokban használd az override
//kulcsszót a Print függvényeknél. Figyeld meg, milyen hatással van ez a példakód kimenetére.
//• A Vehicle osztályt tedd absztrakt osztállyá. (A Main függvényben ekkor a Vehicle osztályhoz
//tartozó részeket kommentbe kell tenni, hogy a kód forduljon.)
//• A Vehicle osztályba készíts egy absztrakt GetNumberOfWheels függvényt, amely majd az adott
//jármű kerekeinek a számával tér vissza.Figyeld meg mi történik a két gyerekosztályban és
//milyen hibaüzenetet ír ki a fejlesztőkörnyezet.
////A megadott osztály a Vehicle osztály, mely tárolja egy jármű sebességét és tömegét.A
//konstruktor mindkét értéket várja. Adott még egy Container osztály, amely járműveket tárol,
//listában.
