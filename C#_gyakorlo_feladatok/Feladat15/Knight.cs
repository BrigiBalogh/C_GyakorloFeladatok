namespace Chess6_onallo;

class Knight : Piece
{
    public Knight(string position) : base(position, 'N')
    {
    }

    public override bool CanEnter(string position)
    {
        if (!Valid(position)) return false;
        if (Position == position) return false;

        // Az átlós mozgás feltétele: abs(oszlop különbség) == abs(sor különbség)
        int colDiff = Math.Abs(position[0] - Position[0]);
        int rowDiff = Math.Abs(position[1] - Position[1]);

        return (colDiff == 2 && rowDiff == 1) || (colDiff == 1 && rowDiff == 2);
    }
}
