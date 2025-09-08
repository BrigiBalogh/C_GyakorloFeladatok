namespace _02_02hazi_feladat;

class Szemely
{
    private string? telefonSzam;
    public string? VezetekNev { get; set; }
    public string? KeresztNev { get; set; }
    public string? TeljesNev
    {
        get { return $"{VezetekNev} {KeresztNev}"; }

    }

    public string? TelefonSzam
    {
        get { return telefonSzam; }
        set
        {
            if(value != null && value.Length==10 && value[2] == '/')
            {
                telefonSzam = value;
            }
            else
            {
                telefonSzam = "ERROR";
            }
        }
    }
}
