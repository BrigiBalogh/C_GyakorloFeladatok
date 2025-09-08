namespace IAudio7_kozos;

public class Cassette : IAudio
{
    public Cassette(string title, int numberOfSides)
    {
        Title = title;
        NumberOfSides = numberOfSides;
    }

    public string Title { get; }
    public int NumberOfSides { get; }

    public void Play()
    {
        Console.WriteLine($"Playback: {Title}, Sides: {NumberOfSides}");
    }
}
//Hozz létre egy Cassette osztályt, amely szintén megvalósítja az IAudio interfészt.
//A kazettánaklegyen egy Title tulajdonsága és egy NumberOfSides tulajdonsága.
//A tulajdonságokat a konstruktor állítsa be.
//• Mindkét osztály a Play függvény megvalósításában írja ki a „Playback: ”
//szót és az osztály adatait.
