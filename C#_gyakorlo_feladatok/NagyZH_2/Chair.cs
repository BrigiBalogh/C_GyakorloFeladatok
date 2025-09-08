namespace NagyZhPelda2;

class Chair : BabyProduct
{

    public bool CanBeSet { get; set; }
    public Chair()
    {
    }

    public Chair(string id, string name, int price, int quantity, bool canBeSet)
        : base(id, name, price, quantity)
    {
        CanBeSet = canBeSet;
    }

    public override string? ToString()
    {
        return $"Chair - {base.ToString()} CanBeSet: {(CanBeSet ? "True" : "False")}";
    }
}
