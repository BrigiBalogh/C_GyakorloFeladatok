namespace ToDo;

class User
{
    public string UserName { get; set; } = string.Empty;
    public List<TaskItem> Tasks { get; set; } = new();
}
