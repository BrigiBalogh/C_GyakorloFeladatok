namespace hazi_feladatok
{
    internal class Program
    {
        public static void Main()
        {
            int x1, x2;
            x1 = int.Parse(Console.ReadLine());
            x2 = int.Parse(Console.ReadLine());
            Ketszam elso = new Ketszam(x1, x2);
            Console.WriteLine(elso.GetX());
            Console.WriteLine(elso.GetAzonosito());
            Console.WriteLine(elso.Lekerdez());
            Ketszam masodik = new Ketszam();
            Console.WriteLine(masodik.GetX());
            Console.WriteLine(masodik.GetAzonosito());
            Console.WriteLine(masodik.Lekerdez());
        }
    }
}

