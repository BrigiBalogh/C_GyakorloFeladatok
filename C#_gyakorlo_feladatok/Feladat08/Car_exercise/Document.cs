namespace Car_exercise;

abstract class Document
{
    public string Details { get; protected set; } = string.Empty;

   public abstract void Print();

}
