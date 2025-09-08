using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3.óra_közös_Person;
using System.Xml.Linq;

namespace _3.óra_közös_Person
{
    class Student : Person
    {
        public string NeptunCode { get; }
        public int CompletedSemesters { get; set; }

        public Student(string name, int age, string neptunCode, int completedSemesters = 1)
            : base(name, age)
        {
            NeptunCode = neptunCode;
            CompletedSemesters = completedSemesters;
        }

        public override void Write()
        {
            base.Write();
            Console.WriteLine($"Neptun code: {NeptunCode}, Completed semester: {CompletedSemesters}");
        }




        public bool Strange()
        {
            return Age < (18 + (CompletedSemesters - 1) * 0.5);
        }

        //public string NeptunCode => neptunCode;
        //public int CompletedSemesters
        //{
        //    get => completedSemesters;
        //    set => completedSemesters = value;  
        //}
    }
}

