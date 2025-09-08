using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3.óra_önálló_NumberLine;

namespace _3.óra_önálló_NumberLine
{
    class Event : NumberLine
    {
        private Person? specialGuest;

        public Person? SpecialGuest
        {
            get { return specialGuest; }
            set { specialGuest = value; }
        }


        public Event() : base(7)
        {
            this.specialGuest = null;
        }

        public Event(Event other) : base(7)
        {
            Array.Copy(other.tomb, this.tomb, 7);
            this.specialGuest = other.specialGuest;
        }

        public void Write()
        {
            for (int i = 0; i < tomb.Length; i++)
            {
             Console.WriteLine($"{i+1}. nap: {tomb[i]} fő");    
            } 
            if(specialGuest != null)
            {
                Console.WriteLine($"kiemelt vendég: {specialGuest.Name}, életkor: {specialGuest.Age}");
            }
        }


      
        
        public int BestDay()
        {
            int maxIndex = 0;
            for (int i = 1; i < tomb.Length; i++)
            { 
                if (tomb[i] > tomb[maxIndex])
                {
                    maxIndex = i;
                }
            }
            return maxIndex + 1; 
        }
    }
}




//public Person SpecialGuest //ha kötelező, hogy legyen vendég
//{
//    get { return specialGuest ?? new Person("Unknown", 0); }
//    set { specialGuest = value; }
//}

//Feladat
//• A feladat elkezdéséhez a mellékelt projekt tartalmaz kódokat.
//A megoldás bizonyos feladatoknál
//ezekhez a kódokhoz is hozzá kell nyúlni, és a teszteléshez a Main függvényben
//a nem használt
//kódokat ki lehet kommentezni.
//• A megadott osztály a NumberLine osztály, amely egy tömböt tárol egész számokból, pár
//alapvető függvénnyel. A tömb méretét a konstruktora adja meg. Szintén adott a közös
//feladatban is használt Person osztály.
//• Származtass egy Event osztályt a NumberLine osztályból,
//ami egy egyhetes rendezvény adatait tárolja.
// Ebben az ősosztály által létrehozott tömb mindenképpen 7 méretű lesz
//(egy-egy szám a
//hét minden napjához, ami az adott napi létszám).Ezen felül tároljon egy Person referenciát, ami
//a rendezvény kiemelt vendégének nevét tárolja (nem biztos, hogy van, így a konstruktor nem
//kap ilyen adatot). A kiemelt vendéget lehessen beállítani és lekérdezni.
//• Készíts az Event osztályba egy Write függvényt, amely kiírja az összes adatot.
//• Készíts másoló konstruktort az Event osztályhoz.
//• Készíts az Event-be egy BestDay függvényt, amely kiírja,
//hogy a rendezvény hanyadik napján volta legnagyobb a létszám.
//• Készíts a Program osztályba egy LowerAverage függvényt, amely paraméterben megkap két
//NumberLine -t. A függvény írja ki, hogy az első vagy a második paraméterben eltárolt számoknak
//nagyobb-e az átlaga, vagy esetleg azonos.