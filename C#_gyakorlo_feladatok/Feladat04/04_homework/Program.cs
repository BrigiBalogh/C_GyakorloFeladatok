namespace _02_3_homework
{
    internal class Program
    {
        static void Main()
        {
            MyClass testvar = new MyClass();
            int i = testvar.Ujszam();
            Console.WriteLine(i);
            i = int.Parse(Console.ReadLine());
            testvar.Beallit(i);
            testvar.Kiir();
        }
    }
}
