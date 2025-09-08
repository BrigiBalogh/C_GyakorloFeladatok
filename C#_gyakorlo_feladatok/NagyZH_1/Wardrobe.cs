namespace NagyzhPelda;

class Wardrobe :Product
{
    public  int DoorCount { get; set; }
    public bool HasMirror { get; set; }

    public override string? ToString()
    {
        return $"Wardrobe {base.ToString()}, {DoorCount} {(HasMirror ? "doors with mirror:" : "doors:")} {Price} HUF";
    }
}
