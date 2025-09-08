namespace NagyzhPelda3;

class MultipleUseCoupon : Coupon
{
    public int TotalUses { get; set; }
    private int usedCount = 0;

    public MultipleUseCoupon(int value,int totalUses)
    {
        Value = value;
        TotalUses = totalUses;
    }

    public override bool IsActive()
    {
       return usedCount < TotalUses;
    }

    public override bool Use()
    {
        if (IsActive())
        {
            usedCount++;
            return true;
        }
        return false;
    }
}
