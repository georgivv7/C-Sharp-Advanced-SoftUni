using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;
        private int capacity;
        public int Count => this.students.Count;
        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            this.Students = new List<Student>(this.Capacity);
        }
        public List<Student> Students
        {
            get { return this.students; }
            set { this.students = value; }
        }
        public int Capacity
        {
            get { return this.capacity; }
            set { this.capacity = value; }
        }

        public string RegisterStudent(Student student)
        {
            if (this.Capacity > Count)
            {
                this.Students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            else
            {
                return "No seats in the classroom";
            }
        }
        public string DismissStudent(string firstName, string lastName)
        {
            if (this.Students.Any(x=>x.FirstName == firstName && x.LastName == lastName))
            {
                var student = this.Students.First(x => x.FirstName == firstName && x.LastName == lastName);
                this.Students.Remove(student);
                return $"Dismissed student {student.FirstName} {student.LastName}";
            }
            else
            {
                return "Student not found";
            }
        }
        public string GetSubjectInfo(string subject)
        {
            if (this.Students.Any(x=>x.Subject == subject))
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine($"Students:");
                foreach (var student in this.Students)
                {
                    if (student.Subject == subject)
                    {
                        sb.AppendLine($"{student.FirstName} {student.LastName}");
                    }
                }
                return sb.ToString().Trim();
            }
            else
            {
                return "No students enrolled for the subject";
            }
        }
        public int GetStudentsCount()
        {
            return this.Count;
        }
        public Student GetStudent(string firstName, string lastName)
        {
            var student = this.Students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
            return student;
        }
    }
}
