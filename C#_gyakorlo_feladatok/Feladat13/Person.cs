namespace NumberLine3;

internal class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

   
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public void Write()
    {
        Console.WriteLine($"{Name}: {Age}");
    }
}
