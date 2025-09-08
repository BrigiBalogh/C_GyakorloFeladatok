namespace NumberLine3
{
    internal class Program
    {
        public static void LowerAverage(NumberLine nl1, NumberLine nl2)
        {
            //double n1Average = Math.Round(n1.Array.Average(), 2);
            //double n2Average = Math.Round(n2.Array.Average(), 2);
            int sum1 = 0;
            int sum2 = 0;
            for (int i = 0; i < nl1.Array.Length; i++)
            {
                sum1 =+ nl1.Array[i];
            }
            double n1Average = (double)sum1 / nl1.Array.Length;
            for (int i = 0; i < nl2.Array.Length; i++)
            {
                sum2 =+ nl2.Array[i];
            }
            double n2Average = (double)sum2 / nl2.Array.Length;
            if (n1Average > n2Average)
            {
                Console.WriteLine($"Az 1. tömb átlaga a nagyobb, ami {n1Average:F2}");
            }
            else if (n2Average > n1Average)
            {
                Console.WriteLine($"A 2. tömb átlaga a nagyobb, ami {n2Average:F2}");
            }
            else
            {
                Console.WriteLine($"A két  tömb átlaga  egyenló, ami {n1Average:F2} és {n2Average:F2}");
            }
        }


//• Készíts a Program osztályba egy LowerAverage függvényt, amely paraméterben megkap két
//NumberLine -t. A függvény írja ki, hogy az első vagy a második paraméterben eltárolt számoknak
//nagyobb-e az átlaga, vagy esetleg azonos.
        static void Main(string[] args)
        {
            // NumberLine teszt: meglévő kódok
            NumberLine nl1 = new NumberLine(3);
            nl1.SetValue(0, 5);
            nl1.SetValue(1, 6);
            nl1.SetValue(2, 7);

            NumberLine nl2 = new NumberLine(8);
            nl2.SetValue(0, 3);
            nl2.SetValue(1, 1);
            nl2.SetValue(2, -9);
            nl2.SetValue(3, -1);
            nl2.SetValue(4, -4);
            nl2.SetValue(5, 1);
            nl2.SetValue(6, 10);
            nl2.SetValue(7, -5);

            WriteNumberLine(nl1);
            WriteNumberLine(nl2);

            // Event teszt: kiírás
            Console.WriteLine();
            Event e1 = new Event();
            Event e2 = new Event();
            e1.SetValue(0, 5);
            e1.SetValue(1, 6);
            e1.SetValue(2, 3);
            e1.SetValue(3, 7);
            e1.SetValue(4, 8);
            e1.SetValue(5, 4);
            e1.SetValue(6, 9);

            e2.SetValue(0, 1);
            e2.SetValue(1, 10);
            e2.SetValue(2, 2);
            e2.SetValue(3, 4);
            e2.SetValue(4, 5);
            e2.SetValue(5, 2);
            e2.SetValue(6, 6);
            e2.VIP = new Person("Vendeg Piroska", 30);

            e1.Write();
            e2.Write();

            // Event teszt: másoló konstruktor
            Console.WriteLine();
            Event copy = new Event(e2);
            copy.Write();
            copy.SetValue(4, 123);
            copy.SetValue(1, 222);
            copy.Write();

            // Event teszt: legjobb nap
            Console.WriteLine();
            e1.BestDay();
            e2.BestDay();

            // NumberLine teszt: kisebb átlag
            Console.WriteLine();
            Console.Write("Atlag osszehasonlitas: nl1 vs nl2: ");
            LowerAverage(nl1, nl2);
            Console.Write("Atlag osszehasonlitas: nl2 vs e1: ");
            LowerAverage(nl2, e1);
            Console.Write("Atlag osszehasonlitas: e1 vs e2: ");
            LowerAverage(e1, e2);
            Console.Write("Atlag osszehasonlitas: e2 vs nl1: ");
            LowerAverage(e2, nl1);
            Console.Write("Atlag osszehasonlitas: nl1 vs e1: ");
            LowerAverage(nl1, e1);
            Console.Write("Atlag osszehasonlitas: nl2 vs e2: ");
            LowerAverage(nl2, e2);
        }

        static void WriteNumberLine(NumberLine numberLine)
        {
            for (int i = 0; i < numberLine.Array.Length; i++)
            {
                if (i > 0)
                {
                    Console.WriteLine(", ");
                }
                Console.WriteLine($"{numberLine.GetValue(i)}");
            }
            Console.WriteLine();
        }
    }
}

