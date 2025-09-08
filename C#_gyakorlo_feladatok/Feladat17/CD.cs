namespace IAudio7_kozos;

public  class CD : IAudio
{
    public CD(string title, int length)
    {
        Title = title;
        Length = length;
    }

    public string Title { get; }
    public int Length { get; }

    public void Play()
    {
        Console.WriteLine($"Playback: {Title}, length: {Length} min");
    }
}
