namespace _02_3_homework;

class MyClass
{
    private int taroltSzam;
    public int Ujszam()
    { 
        int szam = int.Parse(Console.ReadLine());
        return szam;
    }

    public void Beallit(int szam)
    {
        taroltSzam = szam;
    }

    public void Kiir()
    {
        Console.WriteLine($"A szam : {taroltSzam}");

    }
}
