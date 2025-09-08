using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vehicle6_kozos;

namespace Vehicle6_kozos
{
    internal class Container
    {
        public List<Vehicle> Vehicles { get; set; }

        public Container()
        {
            Vehicles = new List<Vehicle>();
        }

        public void Set(int index, Vehicle vehicle)
        {
            if (Vehicles == null)
            {
                return;
            }

            if (Vehicles.Count > index)
            {
                Vehicles[index] = vehicle;
            }
            else
            {
                while (Vehicles.Count < index)
                {
                    Vehicles.Add(new Ship(0, 0, 0));   
                }
                Vehicles.Add(vehicle);
            }
        } 
        

public void Print()
        {
            Console.WriteLine("Járművek:");

            if (Vehicles == null)
            {
                Console.WriteLine("üres");
                return;
            }

            for (int i = 0; i < Vehicles.Count; i++)
            {
                Console.Write($"{i}. jármű: ");
                Vehicles[i].Print();
            }
            Console.WriteLine();
        }
    }
}
