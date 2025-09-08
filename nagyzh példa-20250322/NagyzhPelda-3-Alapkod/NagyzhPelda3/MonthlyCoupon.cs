namespace NagyzhPelda3;

class MonthlyCoupon : Coupon
{

    public int Month { get; set; }
    public int Year { get; set; }
    public MonthlyCoupon(int value,int year, int month)
    {
        Value = value;
        Year = year;
        Month = month;
    }

    public static DateTime CurrentDate { get; set; } = new DateTime(2024, 5, 1);
    public override bool IsActive()
    {
        return CurrentDate.Year == Year && CurrentDate.Month == Month;
    }

    public override bool Use()
    {
        return IsActive();
    }
}
