namespace BookCatalogue;

class Book
{
    public int Id { get; set; }
    public string Author { get; }
    public string Title { get; }
    public int Year { get; set; }

    public string Category { get; set; }
    public int BorrowCount { get; set; }

    public DateTime LastBorrowedDate { get; set; }
    public Book(int id,string author, string title, int year, string category, int borrowCount, DateTime lastBorrowedDate)
    {
        if (string.IsNullOrWhiteSpace(author))
        {
            throw new ArgumentException("A szerző nem lehet üres!");
        }

        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("A könyv címe nem lehet üres!");
        }
        Id = id;
        Title = title;
        Author = author;
        Year = year;
        Category = category;
        BorrowCount = borrowCount;
        LastBorrowedDate = lastBorrowedDate;
    }  
    
    public void Print()
    {
        Console.WriteLine($"Cím: {Title}, Szerző: {Author}, Év: {Year}, Kategória: {Category}, Kölcsönzések száma: {BorrowCount}, Utolsó kölcsönzés: {LastBorrowedDate:yyy-MM-dd}");
    }
}
