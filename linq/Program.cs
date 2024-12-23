namespace linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //int[] num = { 1, 2, 3, 4, 5 };
            ////var even = from n in num
            ////           where n % 2 == 0
            ////           select n;
            //var even = num.Where(n => n % 2 == 0);
            //Console.WriteLine("Even numbers are :");
            //foreach (var n in even)
            //    Console.WriteLine(n);
            //var people = new[]
            //{
            //    new{Name="ameen", Age=22},
            //    new{Name="rashid", Age=25},
            //    new{Name="sahil", Age=20}
            //};
            //var sortedPeople=people.OrderBy(x => x.Age).Select(x => x.Name);
            //foreach (var person in sortedPeople)
            //{
            //    Console.WriteLine(person);
            //}
            //List<person> list = new List<person>
            //{
            //    new person { name="Ameen", age=21, city="ramanattukara" },
            //     new person { name="Rashid", age=25, city="Kannur" },
            //      new person { name="Ameen", age=22, city="Valanchery" },
            //       new person { name="Ameen", age=30, city="ramanattukara" },
            //        new person { name="sahil", age=26, city="ramanattukara" }
            //};
            //var filteredlist = from a in list
            //                     where a.age > 25 && a.city == "ramanattukara"
            //                    select new  { a.name, a.age };
            //Console.WriteLine("Filtered people (age>25, city = ramanattukara) :");
            //foreach (var n in filteredlist)
            //{
            //    Console.WriteLine($"Name : {n.name}, age: {n.age}");
            //}
            //class person
            //{
            //    public string name { get; set; }
            //    public int age { get; set; }
            //    public string city { get; set; }
            //}
            List<Person> person = new List<Person>
            {
                new Person { Name = "Ameen", Age = 26, City = "calicut" },
                new Person { Name = "Sahil", Age = 26, City = "calicut" },
                new Person {Name="Rashid", Age=21, City="Kannur" },
                new Person {Name="ALAmeen", Age=26, City="calicut" },
                new Person {Name="Shyam", Age=26, City="calicut" },
            };
            var filteredPerson = person.Where(s => s.Age > 25 && s.City == "calicut").Select(s => new { s.Name, s.Age });
            Console.WriteLine("Filtered people (age>25, city= calicut) :");
            foreach (var n in filteredPerson)
            {
                Console.WriteLine($"Name : {n.Name} , Age : {n.Age}");
            }
        }
    }
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
    }

}
