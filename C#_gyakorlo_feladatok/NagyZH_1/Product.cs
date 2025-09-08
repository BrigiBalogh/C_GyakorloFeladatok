using System.Globalization;

namespace NagyzhPelda;

class Product
{
    public string Id { get; set; } = string.Empty;
    public string WoodType { get; set; } = string.Empty;
    public double Weight { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public int Length { get; set; }
    public int Price { get; set; }

    public override string? ToString()
    {
        return $"{Id} – {WoodType}, {Weight.ToString(CultureInfo.InvariantCulture)} kg, {Width}x{Height}x{Length} cm";
    }
}
