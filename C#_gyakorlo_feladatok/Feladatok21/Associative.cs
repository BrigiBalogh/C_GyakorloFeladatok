namespace _10_Associative10_Onallo;

public class Associative<TKey, TValue>
{
    private readonly List<KeyAndValue<TKey, TValue>> elements = new List<KeyAndValue<TKey, TValue>>();

    public int Count => elements.Count;

    private int Find(TKey key)
    {
        for (int i = 0; i < elements.Count; i++)
        {
            if (EqualityComparer<TKey>.Default.Equals(elements[i].Key, key))
            {
                return i;
            }
        }
        return -1;
    }


    public void Set(TKey key,TValue value)
    {
        int index = Find(key);
        if(index !=-1)
        {
            elements[index].Value = value;
        }
        else
        {
            elements.Add(new KeyAndValue<TKey, TValue>(key, value));
        }
    }

    public TKey KeyAt(int index)
    {
        return elements[index].Key;
    }

    public TValue ValueAt(int index)
    {
      return  elements[index].Value;
    }

    public bool Contains(TKey key)
    {
        return Find(key) != -1;
    }

    public TValue? Value(TKey key)
    {
        int index = Find(key);
        return index != -1 ? elements[index].Value : default;
    }

    public TValue ValueOrDefault(TKey key, TValue defaultValue)
    {
        int index = Find(key);
        if (index != -1)
        {
            return elements[index].Value;
        }
        return defaultValue;

        //  return index != -1 ? elements[index].Value : defaultValue;
    }
    public void Remove(TKey key)
    {
        int index = Find(key);
        if(index != -1)
        {
            elements.RemoveAt(index);
        }
    }
}
//• Készíts egy Associative osztályt, amely a tárolót valósítja meg.Az osztály kettő sablon paramétert
//várjon, és ilyen értékeket tartalmazó KeyAndValue objektumok listáját.A lista ne legyen kívülről
//elérhető.
//• Készítsd el az Associative osztályhoz a következő metódusokat(és egy property-t):
//o Count: Ez egy property, adja vissza a tárolt kulcs-érték párok számát(belső lista mérete).
//o Find: Ez nem kötelező, de egy ajánlott belső(privát) függvény, ami segíti majd a későbbi
//munkát.A függvény megkap paraméternek egy kulcsot (annak megfelelő típusú adatot), és
//visszaadja hogy a belső tömbnek melyik indexén szerepel ez a kulcs.Adjon vissza valami
//speciális értéket, ha nem találja (például a tömb mérete, vagy a -1).
//o Set: Paraméterül kap egy kulcsot és egy értéket.Ha a kulcs már szerepel a tömbben, akkor a
//hozzá tartozó értéket állítsa át a paraméterben kapottra.Ha még nem szerepel, akkor adjon
//hozzá a tárolóhoz egy új kulcs-érték párt a paraméterben kapott értékekkel.