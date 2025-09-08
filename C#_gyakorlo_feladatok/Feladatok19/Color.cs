namespace Color8;

internal abstract class Color : IEquatable<Color>
{
    public abstract int R();
    public abstract int G();
    public abstract int B();


    public static char NumberToHex(int number)
    {
        return number.ToString("x")[0];
    }

    public static int HexToNumber(char hex)
    {
        return Convert.ToInt32(hex.ToString(), 16);
    }

    public override string ToString()
    {
        return $"#{R():x2}{G():x2}{B():x2}";
    }

    public bool Equals(Color? other)
    {
        if (other is null) return false;
        return R() == other.R() && G() == other.G() && B() == other.B();
    }

    public override bool Equals(object? obj) => obj is Color other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(R(), G(), B());
    

}

//Készíts a Color osztályba három absztrakt metódust R, G, illetve B néven,
//ami majd a szín három komponensét adják vissza int típusként.
//Ezen értékek 0 és 255 között változnak.
//Készíts a Color osztályba egy statikus NumberToHex metódust, amely megkap egy egész értéket
//(0 és 15 között), és visszaadja az értéket hexa karakterré konvertálva(0-F). A metódus
//feltételezheti, hogy az érték tényleg 0 és 15 közötti.Készíts egy hasonló HexToNumber metódust
//is, amely a fordított átalakítást végzi el.
//• A Color osztály írja felül a ToString metódust úgy, hogy adja vissza a színt szövegesen,
//hexadecimális formában (pl. „#E4CB27”)