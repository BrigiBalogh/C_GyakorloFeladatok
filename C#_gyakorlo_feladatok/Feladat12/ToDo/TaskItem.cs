namespace ToDo;

public enum Importance
{
    Alacsony = 1,
    Kozepes = 2,
    Magas = 3
}

class TaskItem
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Name { get; set; }
    public DateOnly Deadline { get; set; }
    public Importance Importance { get; set; }
    public bool IsCompleted { get; set; } = false;
    public TaskItem(int id,string userName, string name, DateOnly deadline, Importance importance, bool isCompleted)
    {
        Id = id;
        UserName = userName;
        Name = name;
        Deadline = deadline;
        Importance = importance;
        IsCompleted = isCompleted;
    }

    public void Print()
    {
        string fontossag = Importance switch
        {
            Importance.Alacsony => "alacsony",
            Importance.Kozepes => "közepes",
            Importance.Magas => "magas",
            _ => "ismeretlen"
        };
        Console.WriteLine($"[{Id}] {Name} - Határidő: {Deadline:yyyy-MM-dd} - Fontosság: {fontossag} - Kész?: {(IsCompleted ? "kész" : "nincs kész")}");
    }

    public override string? ToString()
    {
        return $"{Id}: [{UserName}] {Name} | Határidő: {Deadline} | Fontosság: {Importance}";
    }
}
