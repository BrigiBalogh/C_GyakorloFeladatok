using System.Text.Json;

namespace NagyzhPelda;

class Store
{
    private readonly Dictionary<string, Product> products = new();
    private readonly Dictionary<string, int> stock = new();

    private int handlingFee = 1000;
    public int HandlingFee
    {
        get => handlingFee;
        set => handlingFee = value >= 0 ? value : 0;
    }

    public void LoadStock(string fileName)
    {
        try
        {
            string json = File.ReadAllText(fileName);
            JsonDocument doc = JsonDocument.Parse(json);
            JsonElement root = doc.RootElement;

            LoadProducts(root.GetProperty("Products"));
            LoadStockQuantities(root.GetProperty("Stock"));
           
               
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Hiba történt a beolvasás során: {ex.Message} ");
        }
    }

    private void LoadProducts(JsonElement productsElement)
    {

      foreach (var item in productsElement.EnumerateArray())
      {
        Product? p = CreateProduct(item);
        if (p != null)
        {
            products[p.Id] = p;
        }
      }
    }

    private Product? CreateProduct(JsonElement item)
    {
        string type = item.GetProperty("Type").GetString() ?? string.Empty;
        string id = item.GetProperty("Id").GetString() ?? string.Empty;
        string wood = item.GetProperty("WoodType").GetString() ?? string.Empty;
        double weight = item.GetProperty("Weight").GetDouble();
        int width = item.GetProperty("Dimensions").GetProperty("Width").GetInt32();
        int height = item.GetProperty("Dimensions").GetProperty("Height").GetInt32();
        int length = item.GetProperty("Dimensions").GetProperty("Length").GetInt32();
        int price = item.GetProperty("Price").GetInt32();


        return type switch
        {
            "Chair" => new Chair
            {
                Id = id,
                WoodType = wood,
                Weight = weight,
                Width = width,
                Height = height,
                Length = length,
                Price = price,
                Style = item.GetProperty("Style").GetString() ?? string.Empty
            },

            "Table" => new Table
            {
                Id = id,
                WoodType = wood,
                Weight = weight,
                Width = width,
                Height = height,
                Length = length,
                Price = price,
                LegCount = item.GetProperty("LegCount").GetInt32(),
                LegsAdjustable = item.GetProperty("LegsAdjustable").GetBoolean()
            },
            "Wardrobe" => new Wardrobe
            {

                Id = id,
                WoodType = wood,
                Weight=weight,
                Width = width,
                Height = height,
                Length = length,
                Price = price,
                DoorCount = item.GetProperty("DoorCount").GetInt32(),
                HasMirror = item.GetProperty("HasMirror").GetBoolean()
            },

            _ => null
        };
    }


    private void LoadStockQuantities(JsonElement stockElement)
    {
        foreach (var item in stockElement.EnumerateArray())
        {
            string id = item.GetProperty("ProductId").GetString() ?? string.Empty;
            int quantity = item.GetProperty("Quantity").GetInt32();
            stock[id] = quantity;
        }
    } 

    public void ListProducts()
    {
        foreach (var item in products.Values)
        {
            Console.WriteLine(item); 
        }
    } 

    //public void ListProducts()
    //{
    //    foreach (var item in products)
    //    {
    //        Console.WriteLine($"Id: {item.Key}, Type: {item.Value.GetType().Name}," +
    //            $"Wood: {item.Value.WoodType}, Weight: {item.Value.Weight} kg, Dimensions:" +
    //            $"{item.Value.Width}x{item.Value.Height}x{item.Value.Length} mm, Price: {item.Value.Price} Ft");
    //    }
    //}
    public void ListStock()
    {
        foreach (var entry in stock)
        {
            string id = entry.Key;
            int quantity = entry.Value;

            if(products.TryGetValue(id, out Product? product))
            {
                Console.WriteLine($"{product} ({quantity} available)");
            }
            else
            {
                Console.WriteLine($"[HIBA] Ismeretlen termék ID: {id} (stock: {quantity})");
            }
        }
    }

    public int PriceOfOrder(Order order)
    {
        int total = 0;
        foreach (var kvp in order.Items)
        {
            string productId = kvp.Key;
            int quantity = kvp.Value;
            if(products.TryGetValue(productId, out Product? product))
            {
                total += product.Price * quantity;
            }
        }
        total += handlingFee;
        return total;
    }

    public bool DeliverOrder(Order order)
    {
        foreach (var kvp in order.Items)
        {
            if(!stock.TryGetValue(kvp.Key,out int available) || available < kvp.Value)
            {
                return false;
            }
        }
        foreach (var kvp in order.Items)
        {
            stock[kvp.Key] -= kvp.Value;
        }
        return true;
    }

    public void Produce( string productId, int quantity)
    {
        if (stock.ContainsKey(productId))
        {
            stock[productId] += quantity;
        }
        else
        {
            stock[productId] = quantity;
        }
    }


    public void ExportStock(string fileName)
    {
        var stockList = new List<StockItem>();
        foreach (var kvp in stock)
        {
            stockList.Add(new StockItem
            {
                ProductId = kvp.Key,
                Quantity = kvp.Value
            });
        }
        string json = JsonSerializer.Serialize(stockList, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(fileName, json);
    }
}

////Az átfogó működést a Store osztályon keresztül kell megoldani.Legyen egy LoadStock metódusa, amely
//egy Json fájl nevét kapja, és onnan betölti az üzlet kínálatát.A Json két részre van osztva.A Products
//kulcs alatt vannak a termékek leírásai, míg a Stock kulcs alatti lista megadja, hogy melyik termékből (az
//egyedi azonosítót felhasználva) mennyi darab van aktuálisan raktáron.Feltehetjük, hogy helyesek az
//adatok, és minden termékhez van pontosan egy bejegyzés a raktár készletben, de a sorrend eltérhet.
//A Store osztálynak kell egy ListProducts metódus, amely megjeleníti az összes terméket, valamint egy
//ListStock metódus, amely megjeleníti a termékeket az elérhető mennyiséggel együtt.

 //var stockList = stock
 //       .Select(kvp => new StockItem
 //       {
 //           ProductId = kvp.Key,
 //           Quantity = kvp.Value
 //       })
 //       .ToList();