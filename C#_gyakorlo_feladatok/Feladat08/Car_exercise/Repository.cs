namespace Car_exercise;

class Repository<T>
{
    private List<T> items = new List<T>();

    public void Add(T item)
    {
        items.Add(item);
    }

    public T? FindByLicensePlate(string licensePlate)
    {
        foreach (T item in items)
        {
           if(item is Car car && car.LicensePlate == licensePlate)
            {
                return item;
            } 
        }
        return default(T);
    }

    public List<T> GetAll()
    {
        return items;
    }
}
//public class Repository<T> where T : IRegistrable
//{
//    private List<T> items = new List<T>();

//    public void Add(T item)
//    {
//        items.Add(item);
//    }

//    public T FindByLicensePlate(string licensePlate)
//    {
//        foreach (T item in items)
//        {
//            if (item.GetLicensePlate() == licensePlate)
//            {
//                return item;
//            }
//        }
//        return default(T);
//    }

//    public List<T> GetAll()
//    {
//        return items;
//    }
//}

//✅ Mit értünk el ezzel?
//Nem kell típust ellenőrizni(nincs is Car név).

//Bármilyen típus kereshető, ha megvalósítja az IRegistrable interfészt.