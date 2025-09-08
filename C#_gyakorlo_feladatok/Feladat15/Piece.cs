
namespace Chess6_onallo;

internal abstract class Piece
{
    protected readonly char mark;
    public string Position { get; set; }

    public Piece(string position, char mark)
    {
        Position = position;
        this.mark = mark;
    }


    public static bool Valid(string position)
    {
        if (string.IsNullOrEmpty(position)||position.Length != 2)
        {
            return false;
        }

  
        char column = position[0];
        char row = position[1];
        return column >= 'A' && column <= 'H' && row >= '1' && row <= '8';
    }

    public abstract bool CanEnter(string position);


    public virtual bool Enter(string position)
    {
        if (!Valid(position)) return false;
        if (!CanEnter(position)) return false;

        Position = position;
        return true;
    }
    public virtual char Mark()
    {
        return mark;
    }


}

//Készíts a Piece osztályba egy függvényt Enter néven, amely megkap egy pozíciót, szintén
//szövegként, és amennyiben a pozíció érvényes, és a figura az adott pozícióra is léphet, akkor a
//figura pozícióját átállítja ide.A függvény térjen vissza egy logikai értékkel, amely azt jelzi, hogy a
//lépés végrehajtható volt-e vagy nem.
//• Készíts a Piece osztályba egy virtuális Mark függvényt, amely egy karaktert ad vissza.Ezt a
//gyerekosztályokban fejtsd ki úgy, hogy adja vissza a figurához tartozó egy karakteres jelölést
//(Rook: ’R’, King: ’K’).
       
//if (column >= 'A' && column <= 'H' &&
//    row >= '1' && row <= '8')
//{
//    return true;
//}
//else
//{
//    return false;
//}

//A megadott osztály a Piece osztály, mely egy sakkfigura adatait tárolja:
//az oszlop és a sor, ahol a figura van (egy darab szöveg, két karakterrel,
//pl „A5” vagy „G2”). A pozíciót a konstruktorban várja.
//• Készíts a Piece osztályba egy statikus Valid függvényt,
//amely megkap egy pozíciót, szintén
//szövegként, és visszaadja hogy a pozíció érvényes-e.
//A pozíció érvényes, ha két karakterből áll,
//melyből az első nagybetű (A-H), a második számjegy (1-8).
//• A Piece osztályba készíts egy virtuális CanEnter függvényt
//, amely megkap egy pozíciót, szintén
//szövegként, és visszaadja, hogy a figura léphet-e arra a mezőre.
//A függvény feltételezi, hogy a
//pozíció érvényes, nem kell ellenőriznie.

