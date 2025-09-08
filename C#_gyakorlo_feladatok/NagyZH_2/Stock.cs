
using System.Text.Json;

namespace NagyZhPelda2;

class Stock : IStock
{
    private Dictionary<string, BabyProduct> products;

    public Stock()
    {
        products = new Dictionary<string, BabyProduct>();
    }

    public void Add(BabyProduct product)
    {
        if(products.TryGetValue(product.Id, out var existingProduct))
        {
            existingProduct.Quantity += product.Quantity;
            if(product.Price > 0)
            {
                existingProduct.Price = product.Price;
            }
        }
        else
        {
        products[product.Id] = product;

        }

    }

   
  

    public BabyProduct? Get(string id)
    {
        products.TryGetValue(id, out BabyProduct? product);
        return product;
    }

    public List<BabyProduct> List()
    {
        return products.Values.ToList();
    }

    public List<TProduct> List<TProduct>() where TProduct : BabyProduct
    {
        return products.Values.OfType<TProduct>().ToList();
    }

    public void Load<TProduct>(string filename) where TProduct : BabyProduct
    {
        try {
            string json = File.ReadAllText(filename);
            var productList = JsonSerializer.Deserialize<List<TProduct>>(json);
            if (productList != null)
            {
                foreach (var product in productList)
                {
                    products[product.Id] = product;
                }
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Hiba történt a beolvasás során: {ex.Message}");
        }
    }
    public int Payment(Order order)
    {
        const double VAT = 1.27;
        const int convenienceFee = 320;

        int totalNet = 0;
        foreach (var item in order.OrderItems)
        {
            if (products.TryGetValue(item.ProductId, out var product))
            {
                totalNet += product.Price * item.Quantity;
            }
        }
        int totalGross = (int)Math.Round(totalNet * VAT) + convenienceFee;
        return totalGross;
    }

    public void Remove(string id)
    {
        products.Remove(id);
    }

    public bool Sale(Order order)
    {
        foreach (var item in order.OrderItems)
        {
            if(!products.TryGetValue(item.ProductId, out var product) ||
                product.Quantity <item.Quantity)
            {
                return false;
            }
        }
        foreach (var item in order.OrderItems)
        {
            products[item.ProductId].Quantity -= item.Quantity;
        }
        return true;
    }

    public void Save<TProduct>(string filename) where TProduct : BabyProduct
    {
        var selectedProducts = products.Values.OfType<TProduct>().ToList();

        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(selectedProducts, options);

        File.WriteAllText(filename, json);
    }

    public void Upload(string id, int quantity)
    {
        if(products.TryGetValue(id, out var product))
        {
            product.Quantity += quantity;
        }
    }
}
