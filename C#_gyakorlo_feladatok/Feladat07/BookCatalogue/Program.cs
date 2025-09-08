namespace BookCatalogue;

internal class Program
{
    static void Main()
    {
        var catalogue = new BookCatalogue();

       
        catalogue.ListAll();

        while (true)
        {
            Console.WriteLine("\n--könyvkatalógus--");
            Console.WriteLine("1 - új könyv hozzáadása");
            Console.WriteLine("2 - könyvek listázása:");
            Console.WriteLine("0 - kilépés");
            Console.Write("Válassóz: ");

            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Write("ID: ");
                    if(!int.TryParse(Console.ReadLine(), out int id))
                    {
                        Console.WriteLine("Hibás ID formátum.");
                        break;
                    }
                    Console.Write("Szerző: ");
                    string? author = Console.ReadLine();
                    if(string.IsNullOrWhiteSpace(author))
                    {
                        Console.WriteLine("A szerző megadása kötlező.");
                        break;
                    }

                    Console.Write("Cím: ");
                    string? title = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(title))
                    {
                        Console.WriteLine("A cím megadása kötelező.");
                        break;
                    }

                    Console.Write("Kiadás éve: ");
                   if(!int.TryParse(Console.ReadLine(), out int year))
                    {
                        Console.WriteLine("Hibás év formátum.");
                        break;
                    }
                    Console.Write("Kategória: ");
                    string? category = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(category))
                    {
                        Console.WriteLine("A kategória megadása kötlező.");
                        break;
                    }

                    Console.Write("Kölcsönzések száma: ");
                    if(!int.TryParse(Console.ReadLine(), out int borrowCount))
                    {
                        Console.WriteLine("Hibás a formátum.");
                        break;
                    }
                    
                    try
                    {
                        catalogue.Add(id, author, title, year, category, borrowCount);
                        Console.WriteLine("A könyv sikeresen hozzáadva!");
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"Hiba: {ex.Message}");

                    }
                    break;

                case "2":
                    catalogue.ListAll();
                    break;


                case "0":
                    return;

                default:
                    Console.WriteLine("Ismeretlen opció.");
                    break;


            }
        }
       
    }
}
