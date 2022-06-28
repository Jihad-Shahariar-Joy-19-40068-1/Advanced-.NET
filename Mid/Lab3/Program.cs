using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello World");
            int[]nums = new int[6] { 10, 11, 50, 92, 80, 82 };
            var filter = (from n in nums where n > 50 select n).ToArray();


            var student1 = new Student();
            var student2 = new Student();
            var student3 = new Student();
            var student4 = new Student();
            var student5 = new Student();

            student1.Cgpa = 2.5;
            student1.Id = 1;
            student1.Name = "A";
            student1.Dob = DateTime.Parse("2004-11-27");

            student2.Cgpa = 2.9;
            student2.Id = 2;
            student2.Name = "B";
            student2.Dob = DateTime.Parse("2006-11-27");

            student3.Cgpa = 3.4;
            student3.Id = 3;
            student3.Name = "C";
            student3.Dob = DateTime.Parse("2002-11-27");

            student4.Cgpa = 3.7;
            student4.Id = 4;
            student4.Name = "D";
            student4.Dob = DateTime.Parse("2005-11-27");

            student5.Cgpa = 3.9;
            student5.Id = 5;
            student5.Name = "E";
            student5.Dob = DateTime.Parse("2000-11-27");

            List<Student> students = new List<Student>();
            students.Add(student1);
            students.Add(student2);
            students.Add(student3);
            students.Add(student4);
            students.Add(student5);

            var s1 = (from n in students where n.Cgpa > 3.00 select n).ToList();
            
            var s2 = (from n in students where n.Cgpa > 2.5 && n.Id > 3 select n).ToList();
            foreach (var p1 in s1)
            {
                Console.WriteLine("CGPA: {0} Id: {1} Name: {2}", p1.Cgpa, p1.Id, p1.Name);
            }
            var s3 = (from n in students where (DateTime.Today.Year - (n.Dob).Year) > 18 select n).ToList();
            //var s4 = (from n in students where n.Cgpa > 3.00 select n).ToList();
            //var s5 = (from n in students where n.Cgpa > 3.00 select n).ToList();

        }
    }

    class Student
    {
        /*string Name;
        string Id;
        string Dob;
        float Cgpa;*/

        public string Name { get; set; }
        public int Id { get; set; }
        public DateTime Dob { get; set; }
        public double Cgpa { get; set; }
    }
}
