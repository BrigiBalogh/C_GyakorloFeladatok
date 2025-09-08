#region megoldott_feladatok
//#define PART1_2_3   // Kupon osztályok, Interfész, Main-beli létrehozás
//#define PART4_5     // Purchase osztály, Print
//#define PART6       // Purchase.TotalCost()
//#define PART7       // Purchase.CostWithCoupons()
//#define PART8       // LoadCoupons()
//#define PART9       // CountCoupons()
//#define PART10      // ExportCounts()
#endregion

using System.Text.Json;
using System.Text.Json.Nodes;

namespace NagyzhPelda3;

internal class Program
{

    static void Main()
    {
        List<Coupon> coupons = new List<Coupon>();
#if PART1_2_3
        // Itt kell létrehozni a 3 féle kuponból egyet-egyet, és hozzáadni a listához
#endif

#if PART4_5
        Console.WriteLine("Total purchase:");
        Purchase purchase = new Purchase("purchases.json");
        purchase.Print();
        Console.WriteLine();
#endif

#if PART6
        Console.WriteLine($"Total cost without coupons: {purchase.TotalCost()} Ft");
#endif
#if PART7
        Console.WriteLine($"Total cost with new coupons: {purchase.CostWithCoupons(coupons)} Ft");
        Console.WriteLine($"After 1 use: {purchase.CostWithCoupons(coupons)} Ft");
#endif

#if PART8
        Console.WriteLine();
        Console.WriteLine("Loading two sets of coupons");
        List<Coupon> list1 = LoadCoupons("coupons1.json");
        List<Coupon> list2 = LoadCoupons("coupons2.json");
        Console.WriteLine($"Total cost of purchase with list1 (new): {purchase.CostWithCoupons(list1)} Ft");
        Console.WriteLine($"Total cost of purchase with list2 (new): {purchase.CostWithCoupons(list2)} Ft");
        Console.WriteLine($"Total cost of purchase with list1 (after 1 use): {purchase.CostWithCoupons(list1)} Ft");
        Console.WriteLine($"Total cost of purchase with list2 (after 1 use): {purchase.CostWithCoupons(list2)} Ft");
        Console.WriteLine($"Total cost of purchase with list1 (after 2 uses): {purchase.CostWithCoupons(list1)} Ft");
        Console.WriteLine($"Total cost of purchase with list2 (after 2 uses): {purchase.CostWithCoupons(list2)} Ft");
        Console.WriteLine($"Total cost of purchase with list1 (after 3 uses): {purchase.CostWithCoupons(list1)} Ft");
        Console.WriteLine($"Total cost of purchase with list2 (after 3 uses): {purchase.CostWithCoupons(list2)} Ft");
#endif

#if PART9
        // Ezeknél a függvényhívásoknál kell a megfelelő osztályt átadni
        Console.WriteLine();
        Console.WriteLine("Number of Coupons:");
        Console.WriteLine($"list1, single use, all: {CountCoupons<>(list1, false)}");
        Console.WriteLine($"list1, single use, valid: {CountCoupons<>(list1, true)}");
        Console.WriteLine($"list1, multiple use, all: {CountCoupons<>(list1, false)}");
        Console.WriteLine($"list1, multiple use, valid: {CountCoupons<>(list1, true)}");
        Console.WriteLine($"list1, monthly, all: {CountCoupons<>(list1, false)}");
        Console.WriteLine($"list1, monthly, valid: {CountCoupons<>(list1, true)}");
        Console.WriteLine("#########:");
        Console.WriteLine($"list2, single use, all: {CountCoupons<>(list2, false)}");
        Console.WriteLine($"list2, single use, valid: {CountCoupons<>(list2, true)}");
        Console.WriteLine($"list2, multiple use, all: {CountCoupons<>(list2, false)}");
        Console.WriteLine($"list2, multiple use, valid: {CountCoupons<>(list2, true)}");
        Console.WriteLine($"list2, monthly, all: {CountCoupons<>(list2, false)}");
        Console.WriteLine($"list2, monthly, valid: {CountCoupons<>(list2, true)}");
#endif

#if PART10
        Console.WriteLine();
        Console.WriteLine("Exporting counts");
        ExportCounts(list1, "export1.json");
        ExportCounts(list2, "export2.json");
#endif
    }
}
