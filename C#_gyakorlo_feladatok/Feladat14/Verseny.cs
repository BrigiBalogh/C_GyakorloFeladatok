using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
namespace Verseny5_kozos;

internal class Verseny
{
    public string Megnevezes { get; private set; } = "ismeretlen";
    public List<Probalkozas> Probalkozasok { get; private set; }

    public Verseny(string fajlnev)
    {
        //Console.WriteLine($"A fájl teljes elérési útja: {Path.GetFullPath(fajlnev)}");
        Probalkozasok = new List<Probalkozas>();

        try
        {
            using(StreamReader sr = new StreamReader(fajlnev))
            {
                string? elsoSor = sr.ReadLine();
                if (!string.IsNullOrEmpty(elsoSor))
                {

                    Megnevezes = elsoSor;
                }

                string? sor;

                while ((sor = sr.ReadLine()) != null)
                {
                    //Console.WriteLine($"Beolvasott sor: {sor}");
                    string[] adatok = sor.Split(' ');
                    if (adatok.Length == 3)
                    {
                        string nev = adatok[0];
                        //if (double.TryParse(adatok[1], out double tavolsag) &&
                        //    bool.TryParse(adatok[2], out bool ervenyes))
                        //{ 
                        //   Probalkozasok.Add(new Probalkozas(nev, tavolsag, ervenyes));
                        //    Console.WriteLine($"Hozzáadva: {nev} {tavolsag} {ervenyes}");
                        //}
                        bool sikeresTavolsag = double.TryParse(adatok[1], NumberStyles.Any, CultureInfo.InvariantCulture, out double tavolsag);
                        bool sikeresErvenyes = bool.TryParse(adatok[2], out bool ervenyes);

                        //Console.WriteLine($"Ellenőrzés: '{adatok[1]}' -> {sikeresTavolsag}, '{adatok[2]}' -> {sikeresErvenyes}");

                        if (sikeresTavolsag && sikeresErvenyes)
                        {
                            Probalkozasok.Add(new Probalkozas(nev, tavolsag, ervenyes));
                           // Console.WriteLine($"Hozzáadva: {nev} {tavolsag} {ervenyes}"); // ✅ Ellenőrzés
                        }

                       
                    }

                }

            }

            Console.WriteLine($"A Probalkozasok lista végleges mérete: {Probalkozasok.Count}");
            foreach (var p in Probalkozasok)
            {
                Console.WriteLine($"Lista eleme: {p.Nev} {p.Tavolsag} {p.Ervenyes}");
            }

        }
        catch (Exception e)
        { 
            Console.WriteLine($"Hiba történt a fájl beolvasásakor: {e.Message}");
        }
    }
    //5. Legyen a Verseny osztályban egy Kiir függvény, ami kiírja egy sorba
    //a verseny megnevezését, ezután
    //soronként az egyes próbálkozások adatait, mindent szóközzel elválasztva.


    public void Kiir()
    {
        Console.WriteLine(Megnevezes);
        foreach (var probalkozas in Probalkozasok)
        {
            Console.WriteLine($"{probalkozas.Nev} {probalkozas.Tavolsag}" +
                $" {probalkozas.Ervenyes}");
        }
    }
    //6. Legyen a Kiir függvénynek egy olyan második változata,
    //ami egyetlen paraméterben egy fájl elérési útját
    //kapja meg (string), és az adott nevű fájlba végzi el a kiírást,
    //annak tartalmát felülírva.


    public void Kiir(string fajlnev)
    {
        //Console.WriteLine($"A Probalkozasok lista elemeinek száma: {Probalkozasok.Count}");
        try
        {
            using(StreamWriter sw=new StreamWriter(fajlnev, false)) //A false paraméter azt jelenti, hogy felülírjuk a fájl meglévő tartalmát.
            {
                sw.WriteLine(Megnevezes); // Kiírjuk a verseny nevét az első sorba
                Console.WriteLine($"A Probalkozasok lista elemeinek száma: {Probalkozasok.Count}");

                foreach (var probalkozas in Probalkozasok)
                {
                    sw.WriteLine($"{probalkozas.Nev} {probalkozas.Tavolsag} {probalkozas.Ervenyes}");
                }
            }
            Console.WriteLine($"A verseny adatai sikeresen kiírva a következő fájlba: {fajlnev}");

        }
        catch(Exception e)
        {
            Console.WriteLine($"Hiba történt a fájlba írás közben: {e.Message}");
        }
    }


    
        
    //7. Legyen a Verseny osztályban egy Uj függvény, ami három paraméterben egy új próbálkozás adatait kapja
    //meg. Szúrja be a próbálkozást a tároló lista végére.
    public void Uj(string nev, double tavolsag, bool ervenyes)
    {
        Probalkozasok.Add(new Probalkozas(nev, tavolsag, ervenyes));

    }


    //8. Legyen a Verseny osztályban egy ErvenyesDobasok függvény, ami egy List<double> formájában visszaadja
    //az összes érvényesen dobott távolságot.
    public List<double> ErvenyesDobasok()
    {
        List<double> ervenyesLista = new List<double>();
        foreach (var probalkozas in Probalkozasok)
        {
            if(probalkozas.Ervenyes)
            {
                ervenyesLista.Add(probalkozas.Tavolsag);   
            }
        }
        return ervenyesLista;
    }
    //10. Legyen a Verseny osztályban egy NevSzerint függvény,
    //ami két paraméterben megkapja egy versenyző
    //nevét (string), és egy List<Probalkozas> tárolót.
    //Törölje a kapott tároló tartalmát, majd töltse fel a
    //versenyen az adott nevű versenyzőhöz tartozó próbálkozásokkal.
    public void NevSzerint(string nev, List<Probalkozas> prob)
    {
        prob.Clear(); // Az összes elem törlése a listából
        foreach (var probalkozas in Probalkozasok)
        {
            if (probalkozas.Nev == nev)
            {
             prob.Add(probalkozas);
            }
        }

    }

}






//Verseny osztály
//3. Legyen egy Verseny osztály az alábbi két adattaggal: megnevezés(string), és a próbálkozásokat tároló lista
//(List<Probalkozas>).
//4. A Verseny osztálynak legyen konstruktora, ami egy paramétert várjon: egy fájl elérési útját (string), amiből
//az objektum adatait fel kell tölteni. A fájl elején a verseny megnevezése van, majd az egyes próbálkozások
//adatai a fent megadott sorrendben a fájl végéig. Sem a megnevezés, sem a versenyzők neve nem tartalmaz
//whitespace-t.




