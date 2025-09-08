using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_ora_gyakorlas_subject
{
    public class Subject
    {
       

            private string subjectCode;
            private uint[] grades;


        public Subject(string subjectCode, uint[] grades)
        {
            this.subjectCode = subjectCode;
            this.grades = grades;
        }

        public string GetSubjectCode()
            {
                return subjectCode;
            }

            //public string SubjectCode => subjectCode;

          

            public string GetFormattedData()
            {
                return $"Subject Code: {subjectCode}, Grades: {string.Join(", ", grades)}";
            } 

        public double GetAverageGrade()
        {
            return grades.Select(g => (double)g).Average();
        } 

        public double GetAverageGradeOther()
        {
            uint sum = 0;
            for (int i = 0; i < grades.Length; i++)
            {
                sum += grades[i]; 
            }
            return (double)sum / grades.Length;
        }

        public void AddGrade(int newGrade)
        {
            grades = grades.Select(g => (int)g).Concat(new[] {(int)newGrade }).Select(g =>(uint)g).ToArray();
        }

        public void AddGradeOther(uint newGrade)
        {
            uint[] newGrades = new uint[grades.Length + 1];
            for (int i = 0; i < grades.Length; i++)
            {
                newGrades[i] = grades[i];
            }
            newGrades[grades.Length] = newGrade;
            grades = newGrades;
        }


        public int CountGradeOccurrences(uint grade)
        {
            int count = 0;
            for (int i = 0; i < grades.Length; i++)
            {
                if (grades[i] == grade)
                {
                    count++;
                }
            }
            return count;
        }
   




        //private List<uint> grades = new List<uint>();

        //public void AddGrade(uint newGrade)
        //{
        //    grades.Add(newGrade);  






        //public int CountGradeOccurrences(int grade)
        //{
        //    return grades.Count(g => g == grade);
        //}

    }
}       




//    // Formázott szöveget ad vissza a tantárgy adataival
//    public string GetFormattedData()
//    {
//        string formattedData = "Subject Code: " + subjectCode + ", Grades: ";

//        for (int i = 0; i < grades.Length; i++)
//        {
//            formattedData += grades[i];
//            if (i < grades.Length - 1)
//            {
//                formattedData += ", ";  // Vesszőt teszünk, de az utolsó elem után már nem
//            }
//        }

//        return formattedData;
//    }



