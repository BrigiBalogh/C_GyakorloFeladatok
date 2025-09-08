namespace _02_02hazi_feladat
{
    internal class Program
    {
        static void Main()
        {
            Szemely peldaSzemely = new Szemely();

            peldaSzemely.VezetekNev = Console.ReadLine();
            peldaSzemely.KeresztNev = Console.ReadLine();
            peldaSzemely.TelefonSzam = Console.ReadLine();





            Console.WriteLine($"név külön: {peldaSzemely.VezetekNev} {peldaSzemely.KeresztNev}");
            Console.WriteLine($"név egyben: {peldaSzemely.TeljesNev}");
            Console.WriteLine($"telefonszám: {peldaSzemely.TelefonSzam}");
            Console.WriteLine();
            peldaSzemely.VezetekNev = Console.ReadLine();
            peldaSzemely.KeresztNev = Console.ReadLine();
            Console.WriteLine($"név külön: {peldaSzemely.VezetekNev} {peldaSzemely.KeresztNev}");
            Console.WriteLine($"név egyben: {peldaSzemely.TeljesNev}");
            Console.WriteLine();
            peldaSzemely.TelefonSzam = Console.ReadLine();
            Console.WriteLine($"telefonszám: {peldaSzemely.TelefonSzam}");
            peldaSzemely.TelefonSzam = Console.ReadLine();
            Console.WriteLine($"telefonszám: {peldaSzemely.TelefonSzam}");
        }
    }
}
