using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.óra_önálló_NumberLine
{
    class NumberLine
    {
        protected int[] tomb;

        public NumberLine(int size)
        {
            tomb =  new int[size];
        } 
        
        public double Average()
        {
            if (tomb.Length == 0)
            {
                return 0;
            }
            double sum = 0;
            foreach(int num in tomb)
            {
                sum += num;
            }
            return sum / tomb.Length;
        }

        public void SetValues(int[] values)
        {
            if (values.Length == tomb.Length)
            {
                Array.Copy(values, tomb, values.Length);
            }
            else
            {
                Console.WriteLine("Hiba a megadott tömb mérete nem megfelelő");
            }
        }

        
       
    }
}

//public double Average()
//{
//    if (tomb.Length == 0)
//    {
//        return 0;
//    }
//    return tomb.Average();
//}