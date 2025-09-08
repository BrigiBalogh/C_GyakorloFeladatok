namespace _3.óra_közös_Person
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Person person1 = new Person("Anna", 22);
            Person person2 = new Person("Béla", 25);

          
            Student student1 = new Student("Kata", 19, "ABC123");
            Student student2 = new Student("Dávid", 21, "XYZ456", 4);

           
            Console.WriteLine("Person 1 adatai:");
            person1.Write();
            Console.WriteLine("\nPerson 2 adatai:");
            person2.Write();

            Console.WriteLine("\nStudent 1 adatai:");
            student1.Write();
            Console.WriteLine("\nStudent 2 adatai:");
            student2.Write();

           
            Console.WriteLine($"\n{person1.Name} fiatalabb, mint {person2.Name}? {person1.Younger(person2)}");
            Console.WriteLine($"{student1.Name} fiatalabb, mint {student2.Name}? {student1.Younger(student2)}");

            // Kiírás a Strange metódussal (fiatalabb-e, mint a félévei alapján várható)
            Console.WriteLine($"\n{student1.Name} furcsa eset? {student1.Strange()}");
            Console.WriteLine($"{student2.Name} furcsa eset? {student2.Strange()}");


            egesz = int.Parse(Console.ReadLine());
            e lebego = double.Parse(Console.ReadLine());
        }
    }
    
}


//Console.WriteLine("Kérlek, írj be valamit:");  // Felhasználói kérést jelenít meg
//string userInput = Console.ReadLine();  // Felhasználói bevitel tárolása
//Console.WriteLine("Ezt írtad be: " + userInput);  // Beírt szöveg visszajelzése
