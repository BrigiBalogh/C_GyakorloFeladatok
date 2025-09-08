namespace NagyzhPelda;

class Chair : Product
{
    public string Style { get; set; } = string.Empty;

    public override string? ToString()
    {
        return $"Chair {base.ToString()}, {Style} style: {Price} HUF";
    }
}
