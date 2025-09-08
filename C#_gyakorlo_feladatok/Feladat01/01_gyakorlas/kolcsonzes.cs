namespace _01_gyakorlas;

class Rental
{
    public string ReaderName { get; set; } = "";
    public string BookTitle { get; set; } = "";

    public Rental(string line)
    {
        var parts = line.Split(';');
        ReaderName = parts[0];
        BookTitle = parts[1];
    }

    public override string? ToString()
    {
        return $"Olvasó neve: {ReaderName},  a kölcsönzött könyv címe: {BookTitle}";
    }
}
