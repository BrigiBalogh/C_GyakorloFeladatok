namespace _10_Associative10_Onallo;

public class KeyAndValue<TKey, TValue>
{
    public TKey Key { get; }
    public TValue Value { get; set; }
    public KeyAndValue(TKey key, TValue value)
    {
        Key = key;
        Value = value;
    }




}
