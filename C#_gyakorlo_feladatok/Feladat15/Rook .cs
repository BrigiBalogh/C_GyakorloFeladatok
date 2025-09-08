namespace Chess6_onallo;

class Rook : Piece
{
    public Rook(string position) : base(position,'R')
    {
    }

    public override bool CanEnter(string position)
    {
        if (!Valid(position)) return false;
        if (Position == position)
        {
            return false;
        }
        return position[0] == Position[0] || position[1] == Position[1];
    }
}

//Készíts a Piece osztályba egy függvényt Enter néven, amely megkap egy pozíciót, szintén
//szövegként, és amennyiben a pozíció érvényes, és a figura az adott pozícióra is léphet, akkor a
//figura pozícióját átállítja ide.A függvény térjen vissza egy logikai értékkel, amely azt jelzi, hogy a
//lépés végrehajtható volt-e vagy nem.
