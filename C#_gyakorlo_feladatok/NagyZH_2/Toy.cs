using System.Drawing;

namespace NagyZhPelda2;

class Toy : BabyProduct
{
    public int Age { get; set; }
    public Toy()
    {
    }

    public Toy(string id, string name, int price, int quantity, int age) 
        : base(id, name, price, quantity)
    {
        Age = age;
    }

    public override string? ToString()
    {
        return $"Toy - {base.ToString()} Age: {Age} ev";

    }
}
