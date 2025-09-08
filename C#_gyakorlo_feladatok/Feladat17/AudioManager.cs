namespace IAudio7_kozos;

internal class AudioManager
{
    public List<IAudio> Audios { get; } = new List<IAudio>();
    

    public void AddAudio(IAudio audio)
    {
        Audios.Add(audio);
    }

    public void PlayAudio()
    {
        foreach (var audio in Audios)
        {
          audio.Play();     
        }
    }

    //public void Countdown(int seconds = 5)
    //{
    //    Console.WriteLine("Visszaszámlálás a lejátszás előtt...");
    //    for (int i = seconds; i > 0; i--)
    //    {
    //        Console.WriteLine($"Lejátszás kezdődik {i} másodperc múlva...");
    //        Thread.Sleep(1000);// 1 másodperces várakozás
    //    }
    //    Console.WriteLine("Lejátszás indul!");
    //}
    public void Countdown(int seconds = 5)
    {
        Console.WriteLine("Visszaszámlálás a lejátszás előtt...");

        char[] spinner = { '|', '/', '-', '\\' };
        for (int i = seconds; i > 0; i--)
        {
            foreach (char c in spinner)
            {
                Console.Write($"\rLejátszás kezdődik {i} másodperc múlva... {c}");
                Thread.Sleep(250); // Negyed másodpercenként vált karaktert
            }
        }

        Console.WriteLine("\nLejátszás indul!");
    }
} 
        
//Írj egy metódust az AudioManager osztályban, ami lejátsza a hozzáadott hangszereket
//(PlayAudio). A lejátszás során írd ki a konzolra a hangszerek címét és hosszát vagy
//oldalainakszámát.A kiíráshoz használd az interfész Play függvényét.