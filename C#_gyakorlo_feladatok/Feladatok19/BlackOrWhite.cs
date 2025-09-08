
namespace Color8;

class BlackOrWhite : Color
{
    private bool isBlack;

    public BlackOrWhite(bool isBlack)
    {
        this.isBlack = isBlack;
    }

    // black (0,0,0) or white (255,255,255)
    public override int B() => isBlack ? 0 : 255;

    public override int G() => isBlack ? 0 : 255;

    public override int R() => isBlack ? 0 : 255;
    
}

//Származtass egy BlackOrWhite osztályt a Color osztályból, ami egy logikai értéket tárol.
//Az érték igaz, ha a szín fekete, illetve hamis, hogyha fehér.
//Az osztály konstruktora is ezt az értéket várja.
//Fejtsd ki az R, G, és B metódusokat az osztályban.
