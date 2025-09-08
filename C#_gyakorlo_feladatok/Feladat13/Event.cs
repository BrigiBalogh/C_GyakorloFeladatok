namespace NumberLine3;

class Event : NumberLine
{
    public Person? VIP { get; set; }

    public  Event() : base(7)
    {

    }

    public Event(Event other) : base(7)
    {
        for (int i = 0; i < Array.Length; i++)
        {
            SetValue(i, other.GetValue(i));
        }
        VIP = other.VIP != null ? new Person(other.VIP.Name, other.VIP.Age) : null;

    }

    public void Write()
    {
        Console.WriteLine("A létszám: ");
        for (int i = 0; i < Array.Length; i++)
        {
            Console.Write($"{Array[i]} ");
        }
        Console.WriteLine();
        if(VIP != null)
        {
            Console.WriteLine($"VIP vendég: {VIP.Name}, életkor: {VIP.Age}");
        }
        else
        {
            Console.WriteLine("Nincs VIP vendég.");
        }
    } 

    public void BestDay()
    {
        int bestDayIndex = 0;
        for (int i = 1; i < Array.Length; i++)
        {
            if (Array[i]> Array[bestDayIndex])
            {
                bestDayIndex = i;
            }
        }
        Console.WriteLine($"A legnagyobb létszám a(z) {bestDayIndex + 1}. napon volt:" +
            $" {Array[bestDayIndex]} fő.");
    }


}
//• Készíts az Event-be egy BestDay függvényt, amely kiírja, hogy a rendezvény hanyadik napján volt
//a legnagyobb a létszám.

//Származtass egy Event osztályt a NumberLine osztályból, ami egy egyhetes rendezvény adatait
//tárolja.Ebben az ősosztály által létrehozott tömb mindenképpen 7 méretű lesz (egy-egy szám a
//hét minden napjához, ami az adott napi létszám). Ezen felül tároljon egy Person referenciát, ami
//a rendezvény kiemelt vendégének nevét tárolja(nem biztos, hogy van, így a konstruktor nem
//kap ilyen adatot). A kiemelt vendéget lehessen beállítani és lekérdezni.