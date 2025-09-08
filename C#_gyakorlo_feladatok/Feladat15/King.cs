namespace Chess6_onallo;

class King : Piece
{
    public King(string position) : base(position,'K')
    {
    }

    public override bool CanEnter(string position)
    {
        if (!Valid(position)) return false;
        if (Position == position)
        {
            return false;
        }

        int colDiff = Math.Abs(position[0] - Position[0]);
        int rowDiff = Math.Abs(position[1] - Position[1]);

        return colDiff <= 1 && rowDiff <= 1;
    }
}
