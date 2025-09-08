using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.óra_önálló_NumberLine
{
    class Person
    {
        //public string Name => name;
        //public int Age => age;
        public string Name { get; }


        public int Age { get; } 

        public Person()
        {
            Name = "ismeretlen";
            Age = 0;

        }


        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public virtual void Write()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}");
        }

        public bool Younger(Person person)
        {
            return this.Age < person.Age;
        }
    }
}



      

       
