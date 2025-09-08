using System.Runtime.CompilerServices;

namespace NagyzhPelda3;

internal class Purchase
{
    private List<Product>? products;

    public Purchase(string filename)
    {
        products = Utils.LoadFromJson<Product>(filename) ?? new List<Product>();
    }

    public void Print()
    {
        foreach (var product in products)
        {
            Console.WriteLine($" {product.Name} : {product.Quantity.Value} {product.Quantity.Unit}" +
                $" ({product.UnitPrice} Ft/{product.Quantity.Unit})");
        }
    }

    public double TotalCost()
    {
        return products.Sum(p => p.UnitPrice * p.Quantity.Value);
    }


    public double CostWithCoupons(List<Coupon> coupons)
    {
        double total = TotalCost();
        foreach (var coupon in coupons)
        {
            if (coupon.IsActive())
            {
                total -= coupon.Value;
            }   
        }
        return total;
    }


   // Mikor kell használni?

   //Ha a programod valós használatot szimulál, például:

   // vásárlás során felhasználod a kuponokat,

   // később már nem akarod újra alkalmazni őket.
    public double UseCoupons(List<Coupon> coupons)
    {
        double total = TotalCost();

        foreach (var coupon in coupons)
        {
            if (coupon.Use())
            {
                total -= coupon.Value;
            }
        }

        return total;
    }


}
