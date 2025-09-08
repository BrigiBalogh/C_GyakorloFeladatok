namespace _01_gyakorlas;

internal class Program
{
    static void Main()
    {
        List<string> towns = new List<string> { "Budapest", "Győr", "Szolnok", 
            "Szombathely", "Nagymaros", "Nagyvázsony" };
        var filteredTowns = towns
            .Where(town => town.Length > 6 && town.Contains("a")).ToList();
        foreach (var town in filteredTowns)
        {
            Console.WriteLine(town);
        }
        var filteredAndSorted = towns
            .Where(t => t.Contains('e'))
            .OrderBy(t => t.Length)
            .ToList();
        foreach (var t in filteredAndSorted)
        {
            Console.WriteLine(t); 
        }
        List<string> fruits = new List<string> { "banana", "strawberry","raspberry", "mango", "fig", "orange" };

        var filteredFruits = fruits
            .Where(f => f.Contains('o'))
            .OrderByDescending(f => f.Length)
            .ToList();
        foreach (var f in filteredFruits)
        {
            Console.WriteLine(f);
        }

        List<Book> books = new List<Book>
        {
             new Book { Title = "Clean Code", Author = "Robert Martin", Year = 2008 },
         new Book { Title = "The Pragmatic Programmer", Author = "Andrew Hunt", Year = 1999 },
         new Book { Title = "Refactoring", Author = "Martin Fowler", Year = 2018 },
        new Book { Title = "Design Patterns", Author = "Erich Gamma", Year = 1994 }
        };

        var filteredBooks = books
            .Where(b => b.Year > 2000 && b.Author.Contains('a'))
            .ToList();

        foreach (var book in filteredBooks)
        {
            Console.WriteLine($"{book.Title} {book.Author} {book.Year}");
        }

        List<Movie> movies = new List<Movie>
        {
            new Movie { Title = "Inception", Director = "Christopher Nolan", Year = 2010, Rating = 8.8 },
            new Movie { Title = "The Matrix", Director = "Wachowskis", Year = 1999, Rating = 8.7 },
            new Movie { Title = "Interstellar", Director = "Christopher Nolan", Year = 2014, Rating = 8.6 },
            new Movie { Title = "Avatar", Director = "James Cameron", Year = 2009, Rating = 7.8 }
        };

        var filteredMovie = movies.Where(m => m.IsRecommended()).ToList();

        foreach (var movie in filteredMovie)
        {
            Console.WriteLine($"{movie.Title} {movie.Director} {movie.Year}-{movie.Rating}");
        }

        List<Student> students = new List<Student>
        {
            new Student {Name = "Anna", Grade = 5},
            new Student {Name = "Bence", Grade = 4},
            new Student {Name = "Csilla", Grade= 3 }
        };

        File.WriteAllLines("students.txt", students.Select(s => $"{s.Name};{s.Grade}"));

        var lines = File.ReadAllLines("students.txt");
        List<Student> loaded = new List<Student>();

        foreach (var line in lines)
        {
            var parts = line.Split(';');
            var student = new Student
            {
                Name = parts[0],
                Grade = int.Parse(parts[1])
            };
            loaded.Add(student);
        }

        List<Product> products = new List<Product>
        {
            new Product{Name = "labda", Price = 1200},
            new Product{Name = "kosár", Price = 1800},
            new Product{ Name = "tea", Price = 200},
            new Product{Name = "labda", Price = 1200},
            new Product{Name = "korcsolya", Price = 11000}
        };

        File.WriteAllLines("products.txt", products.Select(p => $"{p.Name}; {p.Price}"));

        var linesOfProducts = File.ReadAllLines("products.txt");
        List<Product> loadedOfProducts = new List<Product>();

        foreach (var line in linesOfProducts)
        {
            var partsOfProducts = line.Split(';');
            var product = new Product
            {
                Name = partsOfProducts[0],
                Price = double.Parse(partsOfProducts[1])

            };
        }

        foreach (var product in loadedOfProducts)
        {
            Console.WriteLine($"Név: {product.Name} ár: {product.Price} Ft.");
            
        }

        List<Rental> rentals = new List<Rental>();

        foreach(var line in  File.ReadAllLines("rentals.txt"))
        {
            rentals.Add(new Rental(line));
        }

        Console.WriteLine("Beolvasott kölcsönzések: ");
        foreach (var rental in rentals)
        {
            Console.WriteLine(rental); 
        }

        var numberOfDifferentBooks = rentals
            .Select(r => r.BookTitle)
            .Distinct()
            .Count();
        Console.WriteLine($"A különböző könyvek száma: {numberOfDifferentBooks}");

        var mostBorrowed = rentals
            .GroupBy(r => r.BookTitle)
            .OrderByDescending(g => g.Count())
            .First();

        Console.WriteLine($"Legtöbbet kölcsönzött könyv: {mostBorrowed.Key} {mostBorrowed.Count()} alkalommal");

        var mostActiveReader = rentals
            .GroupBy(r => r.ReaderName)
            .OrderByDescending(g => g.Count())
            .First();

        Console.WriteLine($"Legaktívabb olvasó: {mostActiveReader.Key} ({mostActiveReader.Count()} kölcsönzés)");




    }
    
}
