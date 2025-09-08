using System;
using System.Diagnostics.CodeAnalysis;
using static System.Net.Mime.MediaTypeNames;
//using System.Globalization;

namespace gyakorlas
{
    class Teglalap
    {
        public int szelesseg;
        public int magassag;
    }

    class Szemely
    {        
        public string nev;
        public int eletkor;
    }

    class Varos
    {
       public string nev;
       public int lakosok;
    }



      class Program
    { 
        public static void bekeres(Teglalap teglalap)
        {
           teglalap.szelesseg = int.Parse(Console.ReadLine());
           teglalap.magassag = int.Parse(Console.ReadLine());
        }

        public static void Megjelenit(Szemely szemely)
        {
            Console.WriteLine($"nev: {szemely.nev}, eletkor: {szemely.eletkor}");
        }

        public int ParosokOsszege(int[] tomb)
        {
            int osszeg = 0;
            for (int i = 0; i < tomb.Length; i++)
            {
                if (tomb[i] % 2 == 0)
                {
                    osszeg += tomb[i];
                }
            }
            return osszeg;
        } 

        public static void melyikKisebb(Varos v1,Varos v2)
        {
            if(v1.lakosok < v2.lakosok)
            {
                Console.WriteLine(v1.nev);
            }
            else
            {
                Console.WriteLine(v2.nev);
            }
        }


        public static void Main(string[] args)
        {
            int a, b;
            double c;
            string s;


            a = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());
            c = double.Parse(Console.ReadLine().Replace(',', '.'));
            //c = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
            s = Console.ReadLine();
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
            Console.WriteLine(s); 
        }

       
    }    
}


//Készíts egy melyikKisebb függvényt, amely paraméterben kettő várost kap,
//és kiírja annak a nevét, amelyikben kevesebben laknak!

//For example:

//Input Result
//Veszprem
//59738
//Szeged
//161879
//Veszprem
//Answer:(penalty regime: 0 %)
//using System;

//namespace HomeWork
//{
//    class Varos
//    {
//        public string nev;
//        public int lakosok;
//    }

//    class Program
//    {



//        public static void Main(string[] args)
//        {
//            Varos v1 = new Varos();
//            Varos v2 = new Varos();
//            v1.nev = Console.ReadLine();
//            v1.lakosok = int.Parse(Console.ReadLine());
//            v2.nev = Console.ReadLine();
//            v2.lakosok = int.Parse(Console.ReadLine());
//            melyikKisebb(v1, v2);
//        }
//    }
//}

//Készíts egy függvényt ParosokOsszege néven,
//amely paraméterül egész számok tömbjét kapja,
//és visszaadja a páros elemek összegét!

//For example:

//Test Result
//int[] tomb = { 8,4,1,4,6,8,4,2,8}
//;
//int osszeg = ParosokOsszege(tomb);
//Console.WriteLine(osszeg);
//44


//Készíts egy megjelenit függvényt, amely paraméterben egy Szemely objektumot kap,
//és megjeleníti az adatait a minta szerint!

//For example:

//Input Result
//Gabor
//34
//Anna
//29
//nev: Gabor, eletkor: 34
//nev: Anna, eletkor: 29
//Answer: (penalty regime: 0 %)
//using System;

//namespace HomeWork
//{
//    class Szemely
//    {
//        public string nev;
//        public int eletkor;
//    }

//    class Program
//    {



//        public static void Main(string[] args)
//        {
//            Szemely sz1 = new Szemely();
//            Szemely sz2 = new Szemely();
//            sz1.nev = Console.ReadLine();
//            sz1.eletkor = int.Parse(Console.ReadLine());
//            sz2.nev = Console.ReadLine();
//            sz2.eletkor = int.Parse(Console.ReadLine());
//            megjelenit(sz1);
//            megjelenit(sz2);
//        }
//    }
//}









//   Készíts egy bekeres nevű függvényt, amely megkap egy Teglalap objektumot,
//   és bekéri az adatait!

//For example:

//Input Result
//43
//67
//23
//66
//sz: 43, m: 67
//sz: 23, m: 66
//Answer: (penalty regime: 0 %)
//using System;

//namespace HomeWork
//{
//    class Teglalap
//    {
//        public int szelesseg;
//        public int magassag;
//    }

//    class Program
//    {



//        public static void Main(string[] args)
//        {
//            Teglalap t1 = new Teglalap();
//            Teglalap t2 = new Teglalap();
//            bekeres(t1);
//            bekeres(t2);
//            Console.WriteLine($"sz: {t1.szelesseg}, m: {t1.magassag}");
//            Console.WriteLine($"sz: {t2.szelesseg}, m: {t2.magassag}");
//        }
//    }
//}




//egesz = int.Parse(Console.ReadLine());
//e lebego = double.Parse(Console.ReadLine());



//Console.WriteLine("Kérlek, írj be valamit:");  // Felhasználói kérést jelenít meg
//string userInput = Console.ReadLine();  // Felhasználói bevitel tárolása
//Console.WriteLine("Ezt írtad be: " + userInput);  // Beírt szöveg visszajelzése


//static void Main()
//{
//    // Első szám bekérése
//    Console.Write("Enter the first number: ");
//    string input1 = Console.ReadLine();
//    int number1 = Convert.ToInt32(input1);

//    // Második szám bekérése
//    Console.Write("Enter the second number: ");
//    string input2 = Console.ReadLine();
//    int number2 = Convert.ToInt32(input2);

//    // Összegzés
//    int sum = number1 + number2;

//    // Eredmény kiírása
//    Console.WriteLine($"The sum of {number1} and {number2} is {sum}");

//    // Konzol nyitva tartása
//    Console.ReadKey();
//}
//}
//int number = int.Parse(Console.ReadLine());
//int number;
//bool isValid = int.TryParse(Console.ReadLine(), out number);
//if (!isValid)
//{
//    Console.WriteLine("Invalid input! Please enter a number.");
//}
//using System;

//class Program
//{
//    static void Main()
//    {
//        Console.Write("Enter a number: ");
//        int myNumber = Convert.ToInt32(Console.ReadLine());

//        Console.WriteLine($"You entered: {myNumber}");

//        Console.ReadKey(); // Megakadályozza a konzol azonnali bezárását
//    }
//}


//Kérd be a mellékelt programban létrehozott változók értékeit
//    (olyan sorrendben, ahogy létrehozzuk őket), majd jelenítsd is meg őket,
//    mindet külön sorba!

//For example:

//Input Result
//5
//6
//2.4
//alma
//5
//6
//2.4
//alma
//Answer:(penalty regime: 0 %)
//using System;

//namespace HomeWork
//{
//    class Program
//    {
//        public static void Main(string[] args)
//        {
//            int a, b;
//            double c;
//            string s;



