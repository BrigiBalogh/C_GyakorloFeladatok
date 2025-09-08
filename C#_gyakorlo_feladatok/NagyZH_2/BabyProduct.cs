namespace NagyZhPelda2;

internal abstract class BabyProduct
{

    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int Price { get; set; }
    public int Quantity { get; set; }
   
    protected BabyProduct()
    {
    }

    protected BabyProduct(string id, string name, int price, int quantity)
    {
        Id = id;
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public override string? ToString()
    {
        return $"Id: {Id}, Name: {Name}, Price: {Price} Ft, Quantity: {Quantity} db,";
    }
}
//A feladat egy kisbaba termékekkel foglalkozó áruház árukezelésének megvalósítása.Az áruházban
//különböző kisbaba termékek(BabyProduct) érhetők el, a programnak ezek nyilvántartását kell tudnia
//kezelnie.Jelenleg háromfajta termékkörrel foglalkoznak, úgymint játékok, ruházat, etetőszékek.A
//kisbaba termékek esetén nyilvántartjuk az azonosítóját (szöveg), a nevét (szöveg), az árát (forintban,
//egész) és a készletmennyiséget (darab, egész). A játékok esetében ezen kívül még ismerjük, hogy hány
//éves gyerekeknek szánták azt (egész). A ruházatnál a ruha méretét ismerjük (szöveg). Az etetőszékek
//esetében még azt tudjuk, hogy a szék magassága állítható-e (bool). TIPP: ABSZTRAKT ŐSOSZTÁLY +
//GYEREKOSZTÁLYOK.