using System.Text.Json;

namespace NagyzhPelda
{
    internal class Program
    {
        public static Order LoadOrder(string fileName)
        {
            try
            {
                string json = File.ReadAllText(fileName);
                JsonDocument doc = JsonDocument.Parse(json);
                JsonElement root = doc.RootElement;

                var order = new Order();

                foreach (var item in root.EnumerateArray())
                {
                    string productId = item.GetProperty("ProductId").GetString() ?? string.Empty;
                    int quantity = item.GetProperty("Quantity").GetInt32();

                    order.Items[productId] = quantity;
                }
                return order;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Hiba történt a fájl beolvasása során: {ex.Message}");
                return new Order(); // vagy akár null
            }
        }
        

        static void Main()
        {
            Store store = new Store();

            // Load products and stock
            store.LoadStock("stock.json");

            // Print all products
            Console.WriteLine();
            Console.WriteLine("---All products---");
            store.ListProducts();

            // Print all products with available stock
            Console.WriteLine();
            Console.WriteLine("---Current stock---");
            store.ListStock();

            // Load 3 orders
            Order o1 = LoadOrder("order1.json");
            Order o2 = LoadOrder("order2.json");
            Order o3 = LoadOrder("order3.json");

            // Price of an order
            Console.WriteLine();
            Console.WriteLine("Price of order 1: " + store.PriceOfOrder(o1));
            Console.WriteLine("Price of order 2: " + store.PriceOfOrder(o2));
            Console.WriteLine("Price of order 3: " + store.PriceOfOrder(o3));

            // Deliver some orders
            Console.WriteLine();
            bool success1 = store.DeliverOrder(o1);
            bool success2 = store.DeliverOrder(o2);
            bool success3 = store.DeliverOrder(o3);
            Console.WriteLine("Order 1 delivered? " + success1);
            Console.WriteLine("Order 2 delivered? " + success2);
            Console.WriteLine("Order 3 delivered? " + success3);
            Console.WriteLine("---Current stock after deliveries---");
            store.ListStock();

            // Produce some furniture
            Console.WriteLine();
            store.Produce("CH-oak-x321", 4);
            store.Produce("WR-mahogany-k4m6", 5);
            store.Produce("TB-cherry-234k", 2);
            Console.WriteLine("---Current stock after production---");
            store.ListStock();

            // Export stock
            store.ExportStock("stock-exported.json");

        }
    }
}
