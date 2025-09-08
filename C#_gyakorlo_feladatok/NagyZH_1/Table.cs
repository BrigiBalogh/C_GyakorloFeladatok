namespace NagyzhPelda;

class Table : Product

{
    public int LegCount { get; set; }
    public bool LegsAdjustable { get; set; }

    public override string? ToString()
    {
        return $"Table {base.ToString()}, {LegCount} {(LegsAdjustable ?"Adjustable legs:" :"legs: ")} {Price} HUF";    
    }
}

