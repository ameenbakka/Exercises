using System.ComponentModel.DataAnnotations;

namespace bakka
{
    }
    class Person
    {
        private string name="Ameen";

        public string ameen() // Getter
        {
            return name;
        }
    }

    class Program
    {
        static void Main()
        {
            Person p = new Person();
            Console.WriteLine("Name: " + p.ameen());  // Getting value
        }
    }
