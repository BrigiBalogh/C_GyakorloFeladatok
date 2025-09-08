namespace Verseny5_kozos
{
    internal class Program
    {
        static void KiirProbalkozasList(List<Probalkozas> probalkozasok)
        {
            for (int i = 0; i < probalkozasok.Count; i++)
            {
                Console.WriteLine($"Név: {probalkozasok[i].Nev} Távolság: {probalkozasok[i].Tavolsag} Érvényes: {probalkozasok[i].Ervenyes}");
            }
        }

        static void Main()
        {  
            Console.WriteLine("Main függvény eleje");

            //2.A Main függvény elején, a jelölt helyen hajtsd végre az alábbi műveleteket:
            //• Hozz létre egy List<Probalkozas> tárolót és töltsd fel tetszőleges értékekkel (pl.ami a main-ben van).
            //• Írasd ki a tartalmát a Main mellett lévő KiirProbalkozasList függvény meghívásával.


            
                // ide keruljon a List<Problakozas>-os feladat megoldasa:
                // (...)
                List<Probalkozas> probalkozasok = new List<Probalkozas>
                {
                    new Probalkozas("Sandor", 29.9, true),
                    new Probalkozas("József", 31.8, false),
                    new Probalkozas("Benedek", 2.7, false)

                };

            KiirProbalkozasList(probalkozasok);



            // Név: Sandor Távolság: 29.9 Érvényes: True
            // Név: Jozsef Távolság: 31.8 Érvényes: False
            // Név: Benedek Távolság: 2.7 Érvényes: False

            // konstruktor teszt (egyelore nincs output)
            Verseny v1 = new Verseny("verseny1.txt");
            Verseny v2 = new Verseny("verseny1.txt");
           // Verseny v2 = v1;

            // Kiir() 1. verzio teszt
            v1.Kiir();
            Console.WriteLine();
            // Verseny1
            // Anita 35.91 True
            // Bea 40.17 True
            // Csilla 39.93 True
            // Diana 36.98 True
            // Emma 37.11 True
            // Emma 39.22 False
            // Diana 37.12 True
            // Anita 38.88 False
            // Anita 35.92 True
            // Csilla 38.5 False

            // Kiir() 2. verzio teszt (lasd a keletkezett fajl tartalmat!)
            v2.Kiir("verseny1-masolat1.txt");

            // Uj() teszt
            v1.Uj("Diana", 40.31, false);
            v1.Uj("Diana", 40.29, true);
            v1.Kiir();
            Console.WriteLine();
            // Verseny1
            // Anita 35.91 True
            // Bea 40.17 True
            // Csilla 39.93 True
            // Diana 36.98 True
            // Emma 37.11 True
            // Emma 39.22 False
            // Diana 37.12 True
            // Anita 38.88 False
            // Anita 35.92 True
            // Csilla 38.5 False
            // Diana 40.31 False
            // Diana 40.29 True

            // ErvenyesDobasok() teszt
            {
                Console.WriteLine("Ervenyes dobasok listaja:");
                // itt kerdezd le es ird ki az ervenyes dobasokat:
                // (...)
                Console.WriteLine();
                List<double> ervenyesek = v1.ErvenyesDobasok();
                Console.WriteLine(string.Join(" ", ervenyesek));
            }
            // Ervenyes dobasok listaja:
            // 35.91 40.17 39.93 36.98 37.11 37.12 35.92 40.29
            //9. A Main függvényben a megadott helyen kérdezd le az v1 változóban tárolt Verseny-ből az érvényes
            //dobásokat az előző függvénnyel, majd írd is ki azokat.
;
            // NevSzerint() teszt
            List<Probalkozas> prob = new List<Probalkozas>();
            prob.Add(new Probalkozas("Torlendo1", 9999.99, false));
            prob.Add(new Probalkozas("Torlendo2", 9999.99, false));
            prob.Add(new Probalkozas("Torlendo3", 9999.99, false));
            KiirProbalkozasList(prob);
            Console.WriteLine();

            v2.NevSzerint("Anita", prob);
            KiirProbalkozasList(prob);
            Console.WriteLine();
            // Anita 35.91 True
            // Anita 38.88 False
            // Anita 35.92 True

            Console.WriteLine("Main függvény vége");
        }
    }
}