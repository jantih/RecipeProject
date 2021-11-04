using System;
using System.Collections.Generic;

namespace ListTest
{
    class Person : IEquatable<Person> {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public override string ToString()
        {
            return $"{Name}, {Age}: {Address}";
        }
        public override bool Equals(object obj)
        {
            if (obj == null) {
                return false;
            }

            Person person = obj as Person;
            
            if (person == null) {
                return false;
            } else { 
                return Equals(person);
            }
        }
        public override int GetHashCode()
        {
            return PersonId;
        }
        public bool Equals(Person other)
        {
            if (other == null) return false;
            return this.Address.Equals(other.Address);
        }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>
            {
                new Person { PersonId = 1, Name = "Jani", Age = 31, Address = "Finland" },
                new Person { PersonId = 2, Name = "Hefe", Age = 20, Address = "Mexico" },
                new Person { PersonId = 3, Name = "John", Age = 55, Address = "USA" }
            };
            Console.WriteLine("All items in a list:");
            foreach (Person person in persons) 
            {
                Console.WriteLine("ID: " + person.GetHashCode());
                Console.WriteLine(person.ToString());
            }
            

            Console.WriteLine("\nContains(\"USA\"): {0}", persons.Contains(new Person { Address = "USA"}));

            Console.WriteLine("\nRemove ID 2...");
            persons.Remove(new Person { PersonId = 2 });
            foreach (Person person in persons)
            {
                Console.WriteLine("ID: " + person.GetHashCode());
                Console.WriteLine(person.ToString());
            }
        }
    }
}
