namespace NumberLine3;

internal class NumberLine
{
    public int[] Array { get; private set; }

    public NumberLine(int numberCount)
    {
        Array = new int[numberCount];
    }

    public NumberLine(NumberLine other)
    {
        Array = new int[other.Array.Length];
        for (int i = 0; i < other.Array.Length; i++)
        {
            Array[i] = other.Array[i];
        }
        //Array = other.Array.ToArray();
    }

    public int GetValue(int index)
    {
        return Array[index];
    }

    public void SetValue(int index, int value)
    {
        if (index < Array.Length)
        {
            Array[index] = value;
        }
    }
}
