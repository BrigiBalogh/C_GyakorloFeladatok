namespace NagyzhPelda3;

class SingleUseCoupon : Coupon
{

    private bool used = false;

    public SingleUseCoupon(int value)
    {
        Value = value;
    }

    public override bool IsActive() => !used;
    


    public override bool Use()
    {
        if (!used)
        {
            used = true;
            return true;
        }
        return false;
    }
}
