using System;

namespace OOP_exercises
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Students student1 = new Students("Alice", 8.5);
            Students student2 = new Students("Bob", 6.0);
            Students student3 = new Students("Charlie", 4.5);
            Students student4 = new Students("David", 9.0);
            Students student5 = new Students("Eve", 7.5);
            Students[] students = { student1, student2, student3, student4, student5 };
            foreach (Students s in students)
            {
                Console.WriteLine($"Name: {s.GetName()}, Score: {s.GetScore()}, Passed: {s.IsPassed()}, Classification: {s.GetClassification()}");
            }
            Students.DisplayTotalStudents();
            Students topStudent = Students.FindTopStudent(students);
            if (topStudent != null)
            {
                Console.WriteLine($"Top Student: {topStudent.GetName()} with Score: {topStudent.GetScore()}");
                Console.WriteLine($"Average Score: {Students.CalculateAverageScore(students):F2}");
            }
        }
    }
}
