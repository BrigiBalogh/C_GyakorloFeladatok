
using System;

namespace _10_Associative10_Onallo
{
    internal class Program
    {
        static void PrintAssoc<KeyType, ValueType>(Associative<KeyType, ValueType> assoc)
        {
            for (int i = 0; i < assoc.Count; i++)
            {
                Console.WriteLine($"{assoc.KeyAt(i)} : {assoc.ValueAt(i)}");
            }
        }
        static void Main()
        {
            Console.WriteLine("\n\nKeyAndValue test");
            KeyAndValue<int, double> kv1 = new KeyAndValue<int, double>(1, 9.8);
            KeyAndValue<int, double> kv2 = new KeyAndValue<int, double>(3, 4.6);
            Console.WriteLine($"{kv1.Key} : {kv1.Value}"); // 1 : 9.8
            Console.WriteLine($"{kv2.Key} : {kv2.Value}"); // 3 : 4.6
            kv1.Value = 1.3;
            kv2.Value = 6.5;
            Console.WriteLine($"{kv1.Key} : {kv1.Value}"); // 1 : 1.3
            Console.WriteLine($"{kv2.Key} : {kv2.Value}"); // 3 : 6.5
            KeyAndValue<string, char> kv3 = new KeyAndValue<string, char>("alma", 'z');
            Console.WriteLine($"{kv3.Key} : {kv3.Value}"); // alma : z

            Console.WriteLine("\n\nAssociative test: Count");
            Associative<int, double> assoc1 = new Associative<int, double>();
            Associative<string, int> assoc2 = new Associative<string, int>();
            Console.WriteLine(assoc1.Count); // 0
            Console.WriteLine(assoc2.Count); // 0

            Console.WriteLine("\n\nAssociative test: Set, KeyAt, ValueAt");
            assoc1.Set(1, 32.65);
            assoc1.Set(7, 2.32);
            assoc1.Set(6, -786.6);
            assoc1.Set(9, 0);
            assoc1.Set(3, 123.565);
            assoc2.Set("valami kulcs", 43);
            assoc2.Set("ezaz", 12);
            assoc2.Set("May the force be with you", 1);
            assoc2.Set("The answer", 42);
            Console.WriteLine("--assoc1--");
            PrintAssoc(assoc1);
            Console.WriteLine("--assoc2--");
            PrintAssoc(assoc2);
            //--assoc1--
            //1 : 32.65
            //7 : 2.32
            //6 : -786.6
            //9 : 0
            //3 : 123.565
            //--assoc2--
            //valami kulcs : 43
            //ezaz: 12
            //May the force be with you : 1
            //The answer : 42

            assoc1.Set(7, 123.5); // létező kulcs, átállít
            assoc1.Set(9, -213.444); // létező kulcs, átállít
            assoc1.Set(65, 111.111);
            assoc2.Set("ezaz", 987); // létező kulcs, átállít
            assoc2.Set("hurra", 11111);
            Console.WriteLine("UJRA:");
            Console.WriteLine("--assoc1--");
            PrintAssoc(assoc1);
            Console.WriteLine("--assoc2--");
            PrintAssoc(assoc2);
            //UJRA:
            //--assoc1--
            //1 : 32.65
            //7 : 123.5
            //6 : -786.6
            //9 : -213.444
            //3 : 123.565
            //65 : 111.111
            //--assoc2--
            //valami kulcs : 43
            //ezaz: 987
            //May the force be with you : 1
            //The answer : 42
            //hurra: 11111

            Console.WriteLine("\n\nAssociative test: Contains");
            Console.WriteLine("--assoc1--");
            Console.WriteLine(assoc1.Contains(3)); // True
            Console.WriteLine(assoc1.Contains(7)); // True
            Console.WriteLine(assoc1.Contains(8)); // False
            Console.WriteLine(assoc1.Contains(12)); // False
            Console.WriteLine(assoc1.Contains(0)); // False
            Console.WriteLine("--assoc2--");
            Console.WriteLine(assoc2.Contains("valami")); // False
            Console.WriteLine(assoc2.Contains("valami kulcs")); // True
            Console.WriteLine(assoc2.Contains("hurra")); // True
            Console.WriteLine(assoc2.Contains("The answer")); // True
            Console.WriteLine(assoc2.Contains("the answer")); // False

            Console.WriteLine("\n\nAssociative test: Value");
            Console.WriteLine("--assoc1--");
            Console.WriteLine(assoc1.Value(3)); // 123.565
            Console.WriteLine(assoc1.Value(7)); // 123.5
            Console.WriteLine(assoc1.Value(8)); // 0
            Console.WriteLine(assoc1.Value(12)); // 0
            Console.WriteLine(assoc1.Value(0)); // 0
            Console.WriteLine("--assoc2--");
            Console.WriteLine(assoc2.Value("valami")); // 0
            Console.WriteLine(assoc2.Value("valami kulcs")); // 43
            Console.WriteLine(assoc2.Value("hurra")); // 11111
            Console.WriteLine(assoc2.Value("The answer")); // 42
            Console.WriteLine(assoc2.Value("the answer")); // 0

            Console.WriteLine("\n\nAssociative test: ValueOrDefault");
            Console.WriteLine("--assoc1--");
            Console.WriteLine(assoc1.ValueOrDefault(3, -12.34)); // 123.565
            Console.WriteLine(assoc1.ValueOrDefault(7, -12.34)); // 123.5
            Console.WriteLine(assoc1.ValueOrDefault(8, -12.34)); // -12.34
            Console.WriteLine(assoc1.ValueOrDefault(12, -12.34)); // -12.34
            Console.WriteLine(assoc1.ValueOrDefault(0, -12.34)); // -12.34
            Console.WriteLine("--assoc2--");
            Console.WriteLine(assoc2.ValueOrDefault("valami", -1)); // -1
            Console.WriteLine(assoc2.ValueOrDefault("valami kulcs", -1)); // 43
            Console.WriteLine(assoc2.ValueOrDefault("hurra", -1)); // 11111
            Console.WriteLine(assoc2.ValueOrDefault("The answer", -1)); // 42
            Console.WriteLine(assoc2.ValueOrDefault("the answer", -1)); // -1

            Console.WriteLine("\n\nAssociative test: Remove");
            assoc1.Remove(3);
            assoc1.Remove(7);
            assoc1.Remove(987); // ilyen nincs
            assoc2.Remove("valami kulcs");
            assoc2.Remove("valami"); // ilyen nincs
            assoc2.Remove("hurra");
            Console.WriteLine("--assoc1--");
            PrintAssoc(assoc1);
            Console.WriteLine("--assoc2--");
            PrintAssoc(assoc2);
            //--assoc1--
            //1 : 32.65
            //6 : -786.6
            //9 : -213.444
            //65 : 111.111
            //--assoc2--
            //ezaz: 987
            //May the force be with you : 1
            //The answer : 42
        }
    }
}
