using System.ComponentModel;
using System.Net.Cache;
using System.Security.Cryptography;

namespace LinqCommonMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> list = new List<Employee>();

            list.Add(new Employee { Id = 1, Name = "jerry", Age = 30, Gender = true, Salary = 5000 });
            list.Add(new Employee { Id = 2, Name = "jimmy", Age = 31, Gender = true, Salary = 8000 });
            list.Add(new Employee { Id = 3, Name = "Cheung", Age = 25, Gender = false, Salary = 6000 });
            list.Add(new Employee { Id = 4, Name = "ziming", Age = 23, Gender = true, Salary = 300 });
            list.Add(new Employee { Id = 5, Name = "hha", Age = 18, Gender = false, Salary = 2000 });
            list.Add(new Employee { Id = 6, Name = "hani", Age = 18, Gender = false, Salary = 2000 });

            /*IEnumerable<Employee> l = list.Where(e => e.Age > 20);

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


            // single grammar
            IEnumerable<Employee> el = list.Where(e =>e.Name == "jerry");
            Console.WriteLine(list.Single(e=>e.Name=="jerry"));
            // single default,return null
            Console.WriteLine(list.SingleOrDefault(e=>e.Name == "askeladd") == null);

            int[] nums = new int[] { 3, 4, 5 };
            // 一条都没有返回 int 默认值
            int i = nums.SingleOrDefault(i => i>10);
            Console.WriteLine(i);
            Console.WriteLine(nums.SingleOrDefault(i=>i>10));

            // First and firstOrDefault
            // First 如果没有报错 FirstOrDefault 如果没有返回空
            //Console.WriteLine(list.First(e => e.Age > 300));
            Console.WriteLine(list.FirstOrDefault(e => e.Age > 40));

            // order 返回新数据 旧数据不受影响
            IEnumerable<Employee> item2 = list.OrderBy(e=>e.Age);

            foreach (Employee el2 in item2)
            {
                Console.WriteLine(el2);
            }

            // order desc
            IEnumerable<Employee> itme3 = list.OrderByDescending(e => e.Age);
            int[] num = new int[] { 3, 4, 5 ,3213, 32, 31};

            IEnumerable<int> num2 = num.OrderBy(i => i);
            // Randdom
            var rand = new Random();
            var r = list.OrderByDescending(i => rand.Next());
            
            var item3 = list.OrderByDescending(e =>  Guid.NewGuid());

            // 最后字母的排序
            var letter = list.OrderByDescending(i => i.Name[i.Name.Length - 1]);

            // 多排序规则

            list.OrderBy(e => e.Age).ThenBy(i => i.Salary);

            // 限制结果集
            var Skip = list.Skip(3); //Take(2);
            var SkipAndTake = list.Skip(3).Take(2);*/

            // 聚合函数 Max() Min Average Sum Count

            var item = list.Max(e => e.Age);
            Console.WriteLine(item);
            int a = list.Where(e => e.Id > 3).Max(e => e.Salary);
            Console.WriteLine(a);
            string s = list.Max(e => e.Name); //字符串比较大小
            Console.WriteLine(s);

            // group by 
            // select age,max(salary) from t group by salary
            IEnumerable<IGrouping<int, Employee>> items = list.GroupBy(e => e.Age);
            foreach (IGrouping<int,Employee> i in items)
            {
                Console.WriteLine(i.Key);
                Console.WriteLine("最大工资" + i.Max(e => e.Salary));
                foreach (Employee e in i)
                {
                    Console.WriteLine(e);
                }
                Console.WriteLine
                ("*******************");
            }
        }
    }

    class Employee
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public bool Gender { get; set; }
        public int Salary { get; set; }

        public override string ToString()
        {
            return $"Id={Id},Name={Name},Age={Age},Gender={Gender},Salary={Salary}"; 
        }
    }
}