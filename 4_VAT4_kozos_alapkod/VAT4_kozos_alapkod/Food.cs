namespace VAT4_kozos;

class Food : Goods
{
    public Food(string name, int netPrice, DateTime expiryDate) : base(name, netPrice)
    {
        ExpiryDate = expiryDate;
    }
    

    public DateTime ExpiryDate { get; }

    public static new double VAT { get; set; } = 15;


    public override int GrossPrice()
    {
        return (int)Math.Round(NetPrice * (1 + VAT / 100), 0);
    }
}


//Származtass a Goods osztályból egy Food osztályt.Az osztály tárol még egy dátumot, ami a
//szavatosság lejártát jelöli.Ezt dátum formájában tárolja (lásd Main). A szavatossági időt a
//konstruktor kapja meg, és legyen hozzá getter property.
//• Ennek az osztálynak legyen egy saját statikus VAT property-je, ami különbözhet az ősosztályétól,
//alapértelmezett értéke legyen 15%. A property értékét lehessen lekérdezni és beállítani is (get
//és set).
//• Írd felül a GrossPrice függvényt a Food osztályban, hogy az ehhez az osztályhoz tartozó ÁFA
//értékkel számoljon.
