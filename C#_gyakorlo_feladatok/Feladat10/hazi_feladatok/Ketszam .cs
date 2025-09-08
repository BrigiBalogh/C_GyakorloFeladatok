
namespace hazi_feladatok;

class Ketszam
{
    private int _x;
    private int _azonosito;

    public Ketszam()
    {
        _x = 466;
        _azonosito = 1358;
    }

    //public Ketszam() : this(466, 1358) { }
    public Ketszam(int x, int azonosito)
    {
        _x = x;
        _azonosito = azonosito;
    }

    public int GetX()
    {
        return _x;
    }

    public int GetAzonosito()
    {
        return _azonosito;
    }

    public int Lekerdez()
    {
        return _azonosito > _x ? _azonosito : _x;
    }

    //public int GetX() => _x;
    //public int GetAzonosito() => _azonosito;
    //public int Lekerdez() => _azonosito > _x ? _azonosito : _x;
}
