using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Warehouse_10_kozos;

class Warehouse<T> where T : struct
{
    private List<WarehouseItem<T>> items;

    public Warehouse()
    {
        items = new List<WarehouseItem<T>>();
    }

    public void LoadWarehouseFromFile(string fileName)
    {
        try
        {
            string json = File.ReadAllText(fileName);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            items = JsonSerializer.Deserialize<List<WarehouseItem<T>>>(json,options)
                ?? new List<WarehouseItem<T>>();
            if (items.Count == 0)
            {
                Console.WriteLine("Figyelmeztetés: az érték null !");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Hiba történt a beolvasás közben: {ex.Message}");
            items = new List<WarehouseItem<T>>();
        }
    }

    public void SaveWarehouseToFile(string fileName)
    {
        string json = JsonSerializer.Serialize(items, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(fileName, json);
    }





   
    public void PrintInventory()
    {
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }

    public WarehouseItem<T>? CheckItem(string id)
    {
        foreach (var item in items)
        {
            if(item.Id== id)
            {
                return item;
            }
        }
        return null;
    }

    public void IncreaseItem(string id, string name, T quantity)
    {
        var existingItem = CheckItem(id);
        if(existingItem is not null)
        {
            existingItem.Quantity = (dynamic)existingItem.Quantity + quantity;
        }
        else
        {
            items.Add(new WarehouseItem<T>(id, name, quantity));
        }
    }

    public bool DecreaseItem(string id, T quantity)
    {
        var existingItem = CheckItem(id);
        if (existingItem is not null)
        {
            dynamic currentQuantity = existingItem.Quantity;
            if(currentQuantity-(dynamic)quantity >= 0)
            {
                existingItem.Quantity = currentQuantity - (dynamic)quantity;
                return true;
            }
        }
        return false;
    }

    public T TotalItemCount()
    {
        dynamic total = default(T);
        foreach (var item in items)
        {
            total += (dynamic)item.Quantity;
        }
        return total;
    }
}


//////Készíts egy PrintInventory metódust a Warehouse<T> osztályban, ami kiírja a raktárban lévő
//összes terméket az azonosítójukkal, nevükkel és mennyiségükkel.
//• Készíts egy CheckItem metódust a Warehouse<T> osztályban, ami ellenőrzi, hogy egy adott
//azonosítójú termék megtalálható-e a raktárban.A függvény térjen vissza a talált elemmel, ha
//nincs találat akkor null értékkel.

//Implementálj egy IncreaseItem metódust a Warehouse<T> osztályban, ami növeli egy
//WarehouseItem<T> termék mennyiségét a raktárban. Ha nem található meg a termék a
//raktárban, akkor hozzáadja. A függvény paraméterben várja az új termék azonosítóját, nevét és
//mennyiségét, visszatérési értéke ne legyen. (Tipp: CheckItem, dymanic)

//   Implementálj egy DecreaseItem metódust a Warehouse<T> osztályban, ami csökkenti egy
//termék (WarehouseItem<T>) mennyiségét a raktárban. A függvény paraméterben kapja meg a
//termék azonosítóját és az értéket, hogy mennyivel kell csökkenteni a termék mennyiségét.A
//mennyiséget csak akkor csökkentse, ha a csökkentés után nem megy át negatív értékbe a
//termék mennyisége, ekkor térjen vissza igaz értékkel.Ha a csökkentés után negatív értékű lenne
//a termék mennyisége, akkor ne csökkentse a termék mennyiségét, hanem térjen vissza hamis
//értékkel. (Tipp: CheckItem, dymanic)

//Készíts egy TotalItemCount függvényt a Warehouse<T> osztályban, ami visszaadja az összes
//termék összmennyiségét a raktárban. (Tipp: dymanic)
//• Készíts egy SaveWarehouseToFile függvényt a Warehouse<T> osztályban, ami paraméterben
//megkap egy fájlnevet és ebbe a fájlba kimenti a raktár tartalmát JSON formátumban.