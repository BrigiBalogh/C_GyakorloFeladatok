namespace VAT4_kozos;

internal class Goods
{
    public string Name { get;}
    public int NetPrice { get;}
    public static double VAT { get; set; } = 27.5;



    public Goods(string name, int netPrice)
    {
        Name = name;
        NetPrice = netPrice;
    }
    public virtual int GrossPrice()
    {
        return (int)Math.Round(NetPrice * (1 + VAT / 100), 0);
    }
}

//• A megadott osztály a Goods osztály, mely tárolja egy termék nevét és nettó árát, pár alapvető
//függvénnyel.
//• Legyen az osztálynak egy lebegőpontos, statikus property-je, amely az ÁFA (VAT) értékét tárolja,
//kezdetben legyen 27,5%. A property értékét lehessen lekérdezni és beállítani is (get és set).
//• Készíts az osztályba egy GrossPrice függvényt, amely visszaadja a termék bruttó, azaz ÁFÁval
//növelt árát. A függvény nyugodtan visszatérhet egész számmal, ami a matematikailag kerekített 
