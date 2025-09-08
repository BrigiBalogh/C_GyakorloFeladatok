namespace Warehouse_10_kozos;

class WarehouseItem<T>
{
    public string Id { get; }
    public string Name { get; }
    public T Quantity { get; set; }

    public WarehouseItem()
    {
        Id = string.Empty;
        Name = String.Empty;
        Quantity = default!;
    }

    public WarehouseItem(string id, string name, T quantity)
    {
        Id = id;
        Name = name;
        Quantity = quantity;
    }

    public override string ToString()
    {
        return $"ID: {Id}, Name: {Name}, Quantity: {Quantity}";
    }

    //Definiáld felül a WarehouseItem<T> osztályban a ToString függvényt úgy,
    //hogy visszaadja a termék azonosítójából, nevéből és mennyiségéből képzett stringet.
}
