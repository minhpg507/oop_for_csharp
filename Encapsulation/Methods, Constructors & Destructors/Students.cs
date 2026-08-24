using System;
namespace OOP_exercises
{
    public class Students
    {
        private string name;
        private double score;

        private static int totalStudents = 0;

        public Students(string name, double score)
        {
            this.name = name;
            this.score = score;

            totalStudents++;
        }

        public static void DisplayTotalStudents()
        {
            Console.WriteLine("Total students: " + totalStudents);
        }

        public string GetName()
        {
            return this.name;
        }
        public double GetScore()
        {
            return this.score;
        }
        public bool IsPassed()
        {
            return this.score >= 5.0;
        }
        public string GetClassification()
        {
            if (this.score >= 8.0)
                return "Excellent";
            else if (this.score >= 6.5)
                return "Good";
            else if (this.score >= 5.0)
                return "Average";
            else
                return "Weak";
        }
        public static int GetTotalStudents()
        {
            return totalStudents;
        }
        public static Students FindTopStudent(Students[] students)
        {
            if (students == null || students.Length == 0)
                return null;
            Students topStudent = students[0];
            foreach (Students s in students)
            {
                if (s.GetScore() > topStudent.GetScore())
                {
                    topStudent = s;
                }
            }
            return topStudent;
        }
        public static double CalculateAverageScore(Students[] students)
        {
            if (students == null || students.Length == 0)
                return 0;
            double total = 0;
            foreach (Students s in students)
            {
                total += s.GetScore();
            }
            return total / students.Length;
        }
    }
}