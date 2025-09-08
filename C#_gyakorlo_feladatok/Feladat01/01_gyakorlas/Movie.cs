namespace _01_gyakorlas;

class Movie
{
    public string Title { get; set; } = "";
    public string Director { get; set; } = "";
    public int Year { get; set; }
    public double Rating { get; set; }

    public bool IsRecommended() => Year >= 2010 && Rating >= 7.5;
    
}
