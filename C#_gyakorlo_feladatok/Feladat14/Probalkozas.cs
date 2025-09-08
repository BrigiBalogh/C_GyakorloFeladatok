namespace Verseny5_kozos;

internal class Probalkozas
{
    public string Nev { get; set; }
    public double Tavolsag { get; set; }
    public bool Ervenyes { get; set; }

    public Probalkozas(string nev, double tavolsag, bool ervenyes)
    {
        Nev = nev;
        Tavolsag = tavolsag;
        Ervenyes = ervenyes;
    }

    public Probalkozas()
    {
        Nev = "ismeretlen";
        Tavolsag = 0;
        Ervenyes = false;
    }
}
