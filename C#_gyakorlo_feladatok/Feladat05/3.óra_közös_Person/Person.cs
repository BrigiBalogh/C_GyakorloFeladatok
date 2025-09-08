using System;
using _3.óra_közös_Person;

namespace _3.óra_közös_Person
{
    class Person
    {
       
        //public string Name => name;
        //public int Age => age;
        public string Name { get; }


        public int Age { get; }


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
//}
//Feladat
//• A feladat elkezdéséhez a mellékelt projekt tartalmaz kódokat. A megoldás bizonyos feladatoknál
//ezekhez a kódokhoz is hozzá kell nyúlni, és a teszteléshez a Main függvényben a nem használt
//kódokat ki lehet kommentezni.
//• A megadott osztály a Person osztály, mely tárolja egy személy nevét, valamint életkorát, pár
//alapvető függvénnyel és property-vel.
//• Származtass egy Student osztályt a Person-ból. Az osztály tárolja még a hallgató Neptun-kódját
//és befejezett féléveinek számát. Ezeket is kapja meg a konstruktor, de a félévek száma legyen
//elhagyható, ekkor az értéke legyen 1. Getter property minden adathoz legyen, setter csak a
//félévek számához.
//• A Person osztályban van egy Write függvény, amely kiírja az adatait. Írd felül ezt a függvényt a
//Student-be, amely kiír minden adatot az ősosztály Write függvényét felhasználva.
//• Készíts a Student osztályba egy Strange függvényt. A függvény igazzal térjen vissza, ha a hallgató
//fiatalabb, mint ahogy a féléveinek száma sugallja, egyébként hamissal. (Egy hallgató általában
//legalább 18 éves, amikor az első félévét elkezdi.)
//• Készíts a Person osztályba egy Younger függvényt, ami paraméterben egy másik személyt vár. A
//függvény térjen vissza igaz értékkel, ha az adott személy fiatalabb, mint a paraméterben átadott.
//Egyébként térjen vissza hamissal.