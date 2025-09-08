using System.Text.Json;
using System.Text;

namespace ToDo;

class TaskManager
{
    private List<TaskItem> tasks = new List<TaskItem>();
    private List<User> users = new();
    private User? currentUser;
    private int nextId = 1;

    public void LoadFromFile(string filename)
    {
        try
        {
            string json = File.ReadAllText(filename);
            tasks = JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();

            nextId = tasks.Any() ? tasks.Max(t => t.Id) + 1 : 1;
            Console.WriteLine("A fájl sikeresen beolvasva!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Hiba történt a fájl beolvasáskor: {ex.Message}");
        }
    }

    public void SetCurrentUser(string userName)
    {
        currentUser = users.FirstOrDefault(u => u.UserName == userName);

        if (currentUser == null)
        {
            currentUser = new User { UserName = userName };
            users.Add(currentUser);
        }

        nextId = currentUser.Tasks.Any() ? currentUser.Tasks.Max(t => t.Id) + 1 : 1;
    }



    public void AddTask(string name, DateOnly deadline, Importance importance)
    {
        if (currentUser == null) return;
        var task = new TaskItem(nextId++, currentUser.UserName, name, deadline, importance, false);
        
        currentUser.Tasks.Add(task);
        //tasks.Add(new TaskItem(nextId++, userName, name, deadline, importance));
        Console.WriteLine("A feladat sikeresen hozzáadva.");

    }

    public void ListAll()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("Nincs egyetlen feladat sem.");
            return;
        }

        foreach (var task in tasks)
        {
            task.Print();
        }
    }

    public IEnumerable<TaskItem> ListAll2() => currentUser?.Tasks ?? Enumerable.Empty<TaskItem>();

    public IEnumerable<TaskItem> SearchTasks(int? id = null, string? name = null,
        DateOnly? deadline = null, Importance? importance = null)
    {
        if (currentUser == null) return Enumerable.Empty<TaskItem>();

        var query = currentUser.Tasks.AsQueryable();

        if (id.HasValue)
            query = query.Where(t => t.Id == id.Value);


        if (!string.IsNullOrWhiteSpace(name))
            query = query.Where(t => t.Name.Contains(name, StringComparison.OrdinalIgnoreCase));

        if (deadline.HasValue)
            query = query.Where(t => t.Deadline == deadline.Value);

        if (importance.HasValue)
            query = query.Where(t => t.Importance == importance.Value);

        return query;
    }

    public void SaveToFile(string filename)
    {
        try
        {

            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(tasks, options);

            File.WriteAllText(filename, json, new UTF8Encoding(false));
            Console.WriteLine("A fájl sikeresen elmentve.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Hiba a fájl mentéskor: {ex.Message}");
        }
    }

    public bool RemoveTask(int id)
    {
        if (currentUser == null) return false;
        var taskToRemove = currentUser.Tasks
            .FirstOrDefault(t => t.Id == id);
        if (taskToRemove != null)
        {
            currentUser.Tasks.Remove(taskToRemove);
           return true;
        }
        return false;
    }


    public void PrintimportanceStatistics()
    {
        var stat = tasks
            .GroupBy(t => t.Importance)
            .Select(g => new
            {
                Importance = g.Key,
                Count = g.Count()
            });
        Console.WriteLine("\nA feladatok száma fontosságszerint:");
        foreach (var item in stat)
        {
            Console.WriteLine($"-{item.Importance}: {item.Count} db");
        }
    }

    public void PrintMostBusyDay()
    {
        if (!tasks.Any())
        {
            Console.WriteLine("Nincs feladat az adatbázisban.");
            return;
        }
        var busiestDay = tasks
            .GroupBy(t => t.Deadline)
            .Select(g => new { Date = g.Key, Count = g.Count() })
            .OrderByDescending(g => g.Count)
            .First();

        Console.WriteLine($"\nA legtöbb feladat ({busiestDay.Count} db) erre a napra esik: {busiestDay.Date}");
    }

    public void ListSortedTasks(string sortBy)
    {
        IEnumerable<TaskItem> sorted = sortBy.ToLower() switch
        {
            "datum" => tasks.OrderBy(t => t.Deadline),
            "fontossag" => tasks.OrderByDescending(t => t.Importance),
            "nev" => tasks.OrderBy(t => t.Name),
            _ => tasks
        };
        Console.WriteLine($"\nFeladatlista {sortBy} szerint rendezve:");
        foreach (var task in sorted)
        {
            Console.WriteLine($"{task.Id}: {task.Name}, {task.Deadline}, {task.Importance}");
        }
    }

    public bool EditTask(int id, string? newName, DateOnly? newDeadline, Importance? newImportance)
    {
        var task = tasks.FirstOrDefault(t => t.Id == id);
        if (task == null)
            return false;

        if (!string.IsNullOrWhiteSpace(newName))
            task.Name = newName;

        if (newDeadline.HasValue)
            task.Deadline = newDeadline.Value;

        if (newImportance.HasValue)
            task.Importance = newImportance.Value;

        return true;
    }

    public bool ToggleCompleteStatus(int id)
    {
        var task = tasks.FirstOrDefault(t => t.Id == id);
        if (task == null)
            return false;

        task.IsCompleted = !task.IsCompleted;
        return true;
    }

    public IEnumerable<TaskItem> GetOverdueTasks()
    {
        DateOnly today = DateOnly.FromDateTime(DateTime.Today);
        return tasks.Where(t => t.Deadline < today && !t.IsCompleted);
    }

    public IEnumerable<TaskItem> GetUpcomingTasks(int daysAhead)
    {
        DateOnly today = DateOnly.FromDateTime(DateTime.Today);
        DateOnly limit = today.AddDays(daysAhead);
        return tasks.Where(t => t.Deadline >= today && t.Deadline <= limit && !t.IsCompleted);
    }

    public IEnumerable<TaskItem> GetTasksByUser(string userName)
    {
        return tasks
            .Where(t => t.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }


} 