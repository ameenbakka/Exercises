namespace week1task
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Course { get; set; }

        public Student(int id, string name, int age, string course)
        {
            Id = id;
            Name = name;
            Age = age;
            Course = course;
        }
    }
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Course(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
    public class StudentManager
    {
        public static List<Student> students = new List<Student>();
        public void AddStudent(int id, string name, int age, string course)
        {
            var Student = new Student(id, name, age, course);
            students.Add(Student);
            Console.WriteLine("Student added successfully");
        }
        public void ViewStudents()
        {
            foreach (var student in students)
            {
                Console.WriteLine($"id: {student.Id}, name:{student.Name}, age:{student.Age}, course: {student.Course}");
            }
        }
        public void UpdateStudent(int id, string newName, int newAge, string newCourse)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                student.Name = newName;
                student.Age = newAge;
                student.Course = newCourse;
                Console.WriteLine("Students information updated successfully");
            }
            else
            {
                Console.WriteLine("Student not found");
            }
        }
        public void DeleteStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                students.Remove(student);
                Console.WriteLine("student deleted successfully");
            }
        }
        public void FindStudentsAboveAge(int age)
        {
            var filteredStudents = students.Where(s => s.Age < 25);
            Console.WriteLine($"students above {age} :");
            foreach (var student in filteredStudents)
            {
                Console.WriteLine($"id: {student.Id} name:{student.Name} age:{student.Age} course: {student.Course}");

            }

        }
        public void FindStudentsCourse(string courseName)
        {
            var filteredStudents = from student in students
                                   where student.Course == courseName
                                   select student;
            Console.WriteLine($"\nStudents in Course '{courseName}':");
            foreach (var student in filteredStudents)
            {
                Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Age: {student.Age}, Course: {student.Course}");
            }
        }
    }
    public class CourseManager
    {
        private List<Course> courses = new List<Course>();
        public void AddCourse(int id , string name) 
        {
            var course = new Course(id, name);
            courses.Add(course);
            Console.WriteLine("course added successfully");
        }
        public void ViewCourse()
        {
            foreach(var course in courses)
            {
                Console.WriteLine($"id : {course.Id} name: {course.Name}");
            }

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentManager studentManager = new StudentManager();
            CourseManager courseManager = new CourseManager();
            courseManager.AddCourse(1, "Malayalam");
            courseManager.AddCourse(2, "English");
            courseManager.AddCourse(1, "Arabic");
            courseManager.AddCourse(1, "Hindi");

            studentManager.AddStudent(1, "ameen", 21, "Malayalam");
            studentManager.AddStudent(2, "Rashid", 25, "Malayalam");
            studentManager.AddStudent(3, "shifan", 22, "Arabic");
            studentManager.FindStudentsCourse("Malayalam");
            courseManager.ViewCourse();
            studentManager.ViewStudents();


        }
    }

}