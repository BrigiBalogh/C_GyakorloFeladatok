using _3.óra_önálló_NumberLine;

namespace _3.óra_önálló_NumberLine
{
    internal class Program
    {
        public static void LowerAverage(NumberLine n1, NumberLine n2)
        {
            double avg1 = n1.Average();
            double avg2 = n2.Average();

            if (avg1 > avg2)
            {
                Console.WriteLine($"Az első tömb átlaga nagyobb");
            }
            else if (avg2 > avg1)
            {
                Console.WriteLine($"A második tömb átlaga nagyobb");
            }
            else
            {
                Console.WriteLine($"A két tömb átlaga egyenlő");
            }
        }
        static void Main(string[] args)
        {
            NumberLine n1 = new NumberLine(5);
            NumberLine n2 = new NumberLine(5);
            n1.SetValues(new int[] { 1, 2, 3, 4, 5 });
            n2.SetValues(new int[] { 5, 5, 5, 5, 5 });

            LowerAverage(n1, n2);
        }
           
    }
}





