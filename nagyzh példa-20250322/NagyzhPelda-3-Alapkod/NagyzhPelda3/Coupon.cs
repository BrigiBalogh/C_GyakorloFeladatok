namespace NagyzhPelda3;

internal abstract class Coupon : IUsable
{

    public int Value { get; set; }
    public abstract bool IsActive();


    public abstract bool Use();
   
}
