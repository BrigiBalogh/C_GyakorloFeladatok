using System.Diagnostics;

namespace ToDo;

internal class Program
{
    static void Main()
    {
        TaskManager manager = new TaskManager();

        manager.LoadFromFile("adatok.json");

        Console.Write("Add meg a felhasználó neved: ");
        string userName = Console.ReadLine() ?? "ismeretlen";
        manager.SetCurrentUser(userName);
        while (true)
        {
            PrintMenu();
            string? input = Console.ReadLine();
           
            switch (input)
            {
                case "1":
                    HandleAdd(manager);
                    break;
                case "2":
                    HandleList(manager);
                    break;
                   
                case "3":
                    HandleSearch(manager);
                    break;

                case "4":
                    HandleDelete(manager);
                    break;

                case "5":
                    manager.PrintimportanceStatistics();
                    break;

                case "6":
                    manager.PrintMostBusyDay();
                    break;

                case "7":
                    HandleListSortedTasks(manager);
                     break;

                case "8":
                    HandleEdit(manager);
                    break;

                case "9":
                    HandleToggleCompleteStatus(manager);
                    break;

                case "10":
                    HandleOverdueTasks(manager);
                    HandleUpcomingTasks(manager);
                    break;
                case "11":
                    HandleListByUser(manager);
                    break;
                case "0":
                    return;

                default:
                    Console.WriteLine("Érvénytelen opció.");
                    break;
            }
        }
    }

static void PrintMenu()
    {
        Console.WriteLine("\n--- FELADATKEZELŐ ---");
        Console.WriteLine("1 - Új feladat hozzáadás");
        Console.WriteLine("2 - Összes feladat listázása");
        Console.WriteLine("3 - A feladat(ok) keresése");
        Console.WriteLine("4 - A feladat törlése id alapján");
        Console.WriteLine("5 - statisztika fontosság alapján");
        Console.WriteLine("6 - a legelfoglaltabb nap megjelenítése");
        Console.WriteLine("7 - a feladatok rendezett listázása");
        Console.WriteLine("8 - a feladatok szerkesztése");
        Console.WriteLine("9 - a feladat állapotának a módosítása (kész/ nem kész");
        Console.WriteLine("10 - Lejárt és közelgő határidejű feladatok");
        Console.WriteLine("11 - Felhasználó feladatainak listázása");
        Console.WriteLine("0 - kilépés");
        Console.Write("Választás: ");
    }

    static void HandleAdd(TaskManager manager)
    {
        Console.WriteLine("\n---ÚJ FELADAT HOZZÁADÁSA---");
        Console.Write("Felhasználónév: ");
        string? user = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(user))
        {
            Console.WriteLine("A felhasználónév nem lehet üres.");
            return;
        }
        Console.Write("A feladat neve: ");
        string? name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("A név nem lehet üres.");
            return;
        }


        Console.Write("Határidő (YYYY-MM-DD): ");
        if (!DateOnly.TryParse(Console.ReadLine(), out DateOnly deadline))
        {
            Console.WriteLine("Hibás dátum.");
            return;
        }

        Console.Write("Fontosság (1 = alacsony, 2 = közepes, 3 = magas): ");
        if (!int.TryParse(Console.ReadLine(), out int rawImp) || !Enum.IsDefined(typeof(Importance), rawImp))
        {
            Console.WriteLine("Érvénytelen a fontosság.");
            return;
        }
        Importance imp = (Importance)rawImp;

        manager.AddTask(name, deadline, imp);

    }

    static void HandleList(TaskManager manager)
    {
        manager.ListAll();
    }

    static void HandleSearch(TaskManager manager)
    {
        Console.WriteLine("Keresés a feladatok között (Enter = nem szűrünk):");

        Console.Write("A feladat neve: ");
        string? nameInput = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(nameInput))
            nameInput = null;

        Console.Write("Határidő (YYYY-MM-DD): ");
        string? dateInput = Console.ReadLine();
        DateOnly? parsedDeadline = null;
        if (!string.IsNullOrWhiteSpace(dateInput) && DateOnly.TryParse(dateInput, out var parseDate))
        {
          parsedDeadline = parseDate;
        }

        else if(!string.IsNullOrWhiteSpace(dateInput))
        {
            Console.WriteLine("Hibás dátumformátum.");
            return;
        }
        

        Console.Write("Fontosság (1 = alacsony, 2 = közepes, 3 = magas): ");
        string? impInput = Console.ReadLine();
        Importance? importance = null;
        if (!string.IsNullOrWhiteSpace(impInput))
        {
            if (int.TryParse(impInput, out int impRaw) && Enum.IsDefined(typeof(Importance), impRaw))
                importance = (Importance)impRaw;
            else
            {
                Console.WriteLine(" A fontosság érvénytelen.");
                return;
            }
        }
        var foundTasks = manager.SearchTasks(null, nameInput, parsedDeadline, importance);
        if (!foundTasks.Any())
        {
            Console.WriteLine("Nincs a feltételeknek megfelelő feladat.");
        }
        else
        {
            Console.WriteLine("\n---Találatok---");
            foreach (var task in foundTasks)
            {
                Console.WriteLine($"{task.Id}: {task.Name}, {task.Deadline}, {task.Importance}");
            }
        }
    }

    static void HandleDelete(TaskManager manager)
    {
        Console.Write("A törlendő feladat id-ja: ");
        if(!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Érvénytelen id formátum.");
            return;
        }
        if(manager.RemoveTask(id))
        {
            Console.WriteLine("A feladat sikeresen törölve.");
        }
        else
        {
            Console.WriteLine("Nem található ilyen id-jű feladat.");
        }
    }
    static void HandleListSortedTasks(TaskManager manager)
    {
        Console.Write("Rendezés dátum, fontosság,név szerint: ");
        string? sortKey = Console.ReadLine()?.Trim().ToLower();

        if (sortKey == "dátum" || sortKey == "fontosság" || sortKey == "név")
        {
            manager.ListSortedTasks(sortKey);
        }
        else
        {
            Console.WriteLine("Érvénytelen rendezési kulcs.");
        }
    }


    static void HandleEdit(TaskManager manager)
    {
        Console.Write("A feladat id-ja: ");
        if(!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Hibás id formátum.");
            return;
        }

        Console.Write("Új név (Enter = nem változik): ");
        string? newName = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(newName))
            newName = null;

        Console.Write("Új határidő (YYYY-MM-DD, Enter = nem változik): ");
        string? deadlineInput = Console.ReadLine();
        DateOnly? newDeadline = null;
        if (!string.IsNullOrWhiteSpace(deadlineInput))
        {
            if (DateOnly.TryParse(deadlineInput, out var parsed))
                newDeadline = parsed;
            else
            {
                Console.WriteLine("Hibás dátumformátum.");
                return;
            }
        }

        Console.Write("Új fontosság beállítása (1 = alacsony, 2 = közepes, 3 = magas, Enter = nem változik): ");
        string? impInput = Console.ReadLine();
        Importance? newImportance = null;
        if (!string.IsNullOrWhiteSpace(impInput))
        {
            if (int.TryParse(impInput, out int raw) && Enum.IsDefined(typeof(Importance), raw))
                newImportance = (Importance)raw;
            else
            {
                Console.WriteLine("A fontosság érvénytelen.");
                return;
            }

        }

        if (manager.EditTask(id, newName, newDeadline, newImportance))
            Console.WriteLine("A feladat frissítve.");
        else
            Console.WriteLine("Nem található ilyen id-jű feladat.");
    }

    static void HandleToggleCompleteStatus(TaskManager manager)
    {
        Console.Write("A módosítandó feladat id-ja: ");
        if (int.TryParse(Console.ReadLine(), out int completeId))
        {
            var success = manager.ToggleCompleteStatus(completeId);
            if (success)
                Console.WriteLine("Állapot módosítva.");
            else
                Console.WriteLine("Nem található ilyen id-jű feladat.");
        }
        else
        {
            Console.WriteLine("Hibás id formátum.");
        }
    }

    static void HandleOverdueTasks(TaskManager manager)
    {
        var expiredTasks = manager.GetOverdueTasks();

        Console.WriteLine("\n--- Lejárt feladatok ---");
        if (!expiredTasks.Any())
            Console.WriteLine("Nincs lejárt feladat.");
        else
            foreach (var task in expiredTasks)
            {
                Console.WriteLine($"{task.Id}: {task.Name}, {task.Deadline}, {task.Importance}");
            }
    }

    static void HandleUpcomingTasks(TaskManager manager)
    {
        
        var upcomingTasks = manager.GetUpcomingTasks(3);

        Console.WriteLine("\n--- Lejárat közeli feladatok ---");
        if (!upcomingTasks.Any())
            Console.WriteLine("Nincs hamarosan lejáró feladat.");
        else
            foreach (var task in upcomingTasks)
            {
                Console.WriteLine($"{task.Id}: {task.Name}, {task.Deadline}, {task.Importance}");
            }
    }

    static void HandleListByUser(TaskManager manager)
    {
        Console.Write("Felhasználónév: ");
        string? user = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(user))
        {
            Console.WriteLine("A felhasználónév nem lehet üres.");
            return;
        }
        var userTasks = manager.GetTasksByUser(user);

        if (!userTasks.Any())
        {
            Console.WriteLine("Ennek a felhasználónak nincs feladata.");
            return;
        }
        Console.WriteLine($"\n---{user} feladatai---");
        foreach(var task in userTasks)
        {
            Console.WriteLine(task);
        }
    }

}
