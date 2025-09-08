namespace NagyZhPelda2;

internal interface IStock
{
    void Load<TProduct>(string filename) where TProduct : BabyProduct;

    void Save<TProduct>(string filename) where TProduct : BabyProduct;

    List<BabyProduct> List();

    List<TProduct> List<TProduct>() where TProduct : BabyProduct;

    BabyProduct ? Get(string id);
    void Add(BabyProduct product);
    void Remove(string id);
    int Payment(Order order);
    bool Sale(Order order);
    void Upload(string id, int quantity);
}
