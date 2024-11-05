using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagementSystem
{
  
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Course Course { get; set; }
    }

    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

  
    public class StudentManager
    {
        private List<Student> students = new List<Student>();

        public void AddStudent(Student student)
        {
            students.Add(student);
            Console.WriteLine("Student added successfully.");
        }

        public void ViewStudents()
        {
            foreach (var student in students)
            {
                Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Age: {student.Age}, Course: {student.Course?.Name}");
            }
        }

        public void UpdateStudent(int id, string name, int age, Course course)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                student.Name = name;
                student.Age = age;
                student.Course = course;
                Console.WriteLine("Student updated successfully.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        public void DeleteStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                students.Remove(student);
                Console.WriteLine("Student deleted successfully.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }


        public void FindStudentsAboveAge(int age)
        {
            var result = students.Where(s => s.Age > age).ToList();
            Console.WriteLine("Students above age " + age + ":");
            foreach (var student in result)
            {
                Console.WriteLine($"{student.Name} ({student.Age} years old)");
            }
        }

        public void FindStudentsByCourse(string courseName)
        {
            var result = students.Where(s => s.Course?.Name == courseName).ToList();
            Console.WriteLine("Students in course " + courseName + ":");
            foreach (var student in result)
            {
                Console.WriteLine(student.Name);
            }
        }
    }


    public class CourseManager
    {
        private List<Course> courses = new List<Course>();

        public void AddCourse(Course course)
        {
            courses.Add(course);
            Console.WriteLine("Course added successfully.");
        }

        public void ViewCourses()
        {
            foreach (var course in courses)
            {
                Console.WriteLine($"ID: {course.Id}, Name: {course.Name}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            StudentManager studentManager = new StudentManager();
            CourseManager courseManager = new CourseManager();

            Course course1 = new Course { Id = 1, Name = "Computer Science" };
            Course course2 = new Course { Id = 2, Name = "Mathematics" };
            courseManager.AddCourse(course1);
            courseManager.AddCourse(course2);

            
            studentManager.AddStudent(new Student { Id = 1, Name = "Alice", Age = 22, Course = course1 });
            studentManager.AddStudent(new Student { Id = 2, Name = "Bob", Age = 25, Course = course2 });
            studentManager.AddStudent(new Student { Id = 3, Name = "Charlie", Age = 19, Course = course1 });

            
            Console.WriteLine("\nAll Students:");
            studentManager.ViewStudents();

            Console.WriteLine("\nAll Courses:");
            courseManager.ViewCourses();

            Console.WriteLine("\nFinding students above age 20:");
            studentManager.FindStudentsAboveAge(20);

            Console.WriteLine("\nFinding students in Computer Science:");
            studentManager.FindStudentsByCourse("Computer Science");
        }
    }
}
