namespace Chess6_onallo;

class Bishop : Piece
{
    public Bishop(string position) : base(position, 'B')
    {
    }

    public override bool CanEnter(string position)
    {
        if (!Valid(position)) return false;
        if (Position == position) return false;

        // Az átlós mozgás feltétele: abs(oszlop különbség) == abs(sor különbség)
        int colDiff = Math.Abs(position[0] - Position[0]);
        int rowDiff = Math.Abs(position[1] - Position[1]);

        return colDiff == rowDiff;

    }
}
 
 