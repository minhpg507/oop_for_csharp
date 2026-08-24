using System;

namespace OOP_Exercises
{
    public class Student
    {
        private string fullName;
        private string major;
        private string projectGroup;

        public Student(string fullName, string major, string projectGroup)
        {
            this.fullName = fullName;
            this.major = major;
            this.projectGroup = projectGroup;
        }

        public void Study()
        {
            Console.WriteLine(fullName + " đang học chuyên ngành " + major + " tại UEH.");
        }

        public void TeamWork()
        {
            Console.WriteLine(fullName + " đang thảo luận dự án cùng nhóm " + projectGroup + ".");
        }

        public override string ToString()
        {
            return "Sinh viên: " + fullName + " | Chuyên ngành: " + major;
        }
    }
}