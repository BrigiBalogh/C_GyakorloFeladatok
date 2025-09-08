namespace NagyZhPelda2;

class Clothes : BabyProduct
{
    public string Size { get; set; } = string.Empty;
    public Clothes()
    {
    }

    public Clothes(string id, string name, int price, int quantity, string size)
        : base(id, name, price, quantity)
    {
        Size = size;
    }

    public override string? ToString()
    {
        return $"Clothes - {base.ToString()} Size: {Size}";

    }
}


