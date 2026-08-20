using System;

namespace OOP_Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Dog dog1 = new Dog("Tuffy", "Papillon", 5, "White");
            Dog dog2 = new Dog("Milu", "Corgi", 2, "Brown");

            Console.WriteLine("=== DOG INSTANCES ===");
            Console.WriteLine(dog1.ToString());

            Console.WriteLine("------------------");
            Console.WriteLine(dog2.ToString());

            Console.WriteLine("Chỉ lấy tên của con chó thứ 2: " + dog2.GetName());

            Console.WriteLine("\n=== STUDENT INSTANCES ===");

            Student student1 = new Student("Nguyen Van A", "Information Systems", "Hello Universe");
            Student student2 = new Student("Tran Thi B", "Computer Science", "Team Alpha");

            Console.WriteLine(student1.ToString());
            student1.Study();
            student1.TeamWork();

            Console.WriteLine("------------------");
            Console.WriteLine(student2.ToString());
            student2.Study();

            Console.ReadLine(); 
        }
    }
}