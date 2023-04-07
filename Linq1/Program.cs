using System.ComponentModel;
using System.Net.Cache;
using System.Security.Cryptography;

namespace Linq1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> list = new List<Employee>();

            list.Add(new Employee { Id = 1, Name = "jerry ", Age = 30, Gender = true, Salary = 5000 });
            list.Add(new Employee { Id = 2, Name = "jimmy", Age = 27, Gender = true, Salary = 8000 });
            list.Add(new Employee { Id = 2, Name = "Cheung", Age = 25, Gender = false, Salary = 6000 });
            list.Add(new Employee { Id = 2, Name = "ziming", Age = 23, Gender = true, Salary = 300 });
            list.Add(new Employee { Id = 2, Name = "hha", Age = 18, Gender = false, Salary = 2000 });

            IEnumerable<Employee> l = list.Where(e => e.Age > 20);

            foreach (Employee e in l)
            {
                Console.WriteLine(e);
            }

            // lambda count
            Console.WriteLine(list.Count(e=>e.Age>20));
            Console.WriteLine(list.Count(e => e.Age > 20 && e.Salary > 6000));

            // any 是否至少有一条数据 返回bool
            Console.WriteLine(list.Any()); // true
            Console.WriteLine(list.Any(e => e.Salary > 9000));
            
            
        }
    }

    class Employee
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }
        public int Salary { get; set; }

        public override string ToString()
        {
            return $"Id={Id},Name={Name},Age={Age},Gender={Gender},Salary={Salary}"; 
        }
    }
}