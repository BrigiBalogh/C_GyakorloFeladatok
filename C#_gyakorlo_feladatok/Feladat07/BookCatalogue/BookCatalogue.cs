using System.Text.Json;

namespace BookCatalogue;

class BookCatalogue
{

     private   List<Book> books = new();

    public void LoadFromFile(string filename)
    {
        try
        {
            string json = File.ReadAllText(filename);
            books = JsonSerializer.Deserialize<List<Book>>(json) ?? new List<Book>();
            Console.WriteLine("A fájl sikeresen beolvasva!");
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Hiba történt a fájl beolvasásakor: {ex.Message}");
        }
    }


    
    public void Add(int id, string author, string title, int year, string category, int borrowCount, DateTime lastBorrowedDate)
    {
        var newBook = new Book(id,author, title,year, category, borrowCount,lastBorrowedDate);
        books.Add(newBook);
        Console.WriteLine("A könyv sikeresen hozzáadva!");
    }

    public void ListAll()
    {
        if(books.Count == 0)
        {
            Console.WriteLine("A katalógus jelenleg üres.");
            return;
        }
        Console.WriteLine("Könyvek a katalógusban: ");
        foreach (var book in books)
        {
            Console.WriteLine($"- {book.Author}: {book.Title}");
        }
    }

    public void SaveToFile(string filename)
    {
        
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(books, options);

        File.WriteAllText(filename, json);
    }

    public void AverageBorrowCountByCategory()
    {
        Console.WriteLine("Kérem adja meg a kategória nevét: ");
        string? category = Console.ReadLine();

        var booksInCategory = books.Where(b => b.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();

        if(booksInCategory.Count == 0)
        {
            Console.WriteLine("Ebben a kategóriában nincs könyv.");
            return;
        }

        double average = booksInCategory.Average(b => b.BorrowCount);
        Console.WriteLine($"Átlagos kölcsönzés száma a(z) \"{category}\" kategóriában: {average:F2}");
    }

    public void MostFrequentBorrowDay()
    {
       if(books.Count == 0)
        {
            Console.WriteLine("Nincs adat a könyvekről.");
            return;
        }

        var mostCommonDay = books
             .GroupBy(b => b.LastBorrowedDate.DayOfWeek)
             .Select(g => new { Day = g.Key, Count = g.Count() })
             .OrderByDescending(g => g.Count)
             .FirstOrDefault();
        if(mostCommonDay != null)
        {
            Console.WriteLine($"A legtöbb kölcsönzés a(z) {mostCommonDay.Day} napon történt ({mostCommonDay.Count} könyv esetén).");
        }
        else
        {
            Console.WriteLine("Nincs kölcsönzési adat.");
        }
    }

    public void DeleteBook()
    {
        Console.WriteLine("Add meg a könyv címét (vagy ID-jét): ");
        string? input = Console.ReadLine();

        var bookToRemove = books.FirstOrDefault(b => b.Title.Equals(input, StringComparison.OrdinalIgnoreCase)
        || b.Id.ToString() == input);

        if(bookToRemove != null)
        {
            books.Remove(bookToRemove);
            Console.WriteLine("A könyv sikeresen törölve.");
        }
        else
        {
            Console.WriteLine("Nem található ilyen könyv.");
        }
    }

    public void SearchByAuthorOrTitle()
    {
        Console.WriteLine("Adj meg egy szerzőt vagy egy könyv címet:");
        string? keyword = Console.ReadLine();

        var foundBooks = books.Where(b =>
         b.Author.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
         b.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
        
        if(foundBooks.Count == 0)
        {
            Console.WriteLine("Nincs találat.");
        }
        else
        {
            Console.WriteLine("Találatok:");
            foreach (var book in foundBooks)
            {
                Console.WriteLine($"- {book.Title} (szerző: {book.Author})");
            }
        }
    }

    public void FilteredByBorrowDate()
    {
        Console.Write("Add meg a kezdődátumot (pl. 2025-01-01): ");
        if(!DateTime.TryParse(Console.ReadLine(), out DateTime startDate))
        {
            Console.WriteLine("Hibás dátumformátum.");
            return;
        }

        Console.Write("Add meg a kölcsönzés végét (pl. 2025-12-31):");
        if(!DateTime.TryParse(Console.ReadLine(), out DateTime endDate))
        {
            Console.WriteLine("Hibás dátumformátum.");
            return;

        }
        var results = books
            .Where(b => b.LastBorrowedDate >= startDate && b.LastBorrowedDate <= endDate)
            .ToList();

        if(results.Count == 0)
        {
            Console.WriteLine("Nincs a megadott időszakban kölcsönzött könyv.");
            return;
        }

        Console.WriteLine($"Könyvek a megadott időszakból ({startDate:yyyy-MM-dd} - {endDate:yyyy-MM-dd}):");
        foreach (var book in results)
        {
            book.Print();
        }
    }
}
      
