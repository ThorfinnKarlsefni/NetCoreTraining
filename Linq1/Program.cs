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
            var SkipAndTake = list.Skip(3).Take(2);

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
            foreach (IGrouping<int,Employee> x in items)
            {
                Console.WriteLine(x.Key);
                Console.WriteLine("最大工资" + x.Max(e => e.Salary));
                foreach (Employee e in x)
                {
                    Console.WriteLine(e);
                }
                Console.WriteLine
                ("*******************");
            }

            // 投影

            // 把集合中的每一项转换为另外一种类型 类似查询语句
            IEnumerable<int> ages = list.Select(e => e.Age);
            IEnumerable<string> names = list.Where(e => e.Age > 30).Select(e => e.Name+","+e.Age);

            IEnumerable<string> gender = list.Where(e => e.Salary > 5000).Select(e => e.Gender ? "男" : "女");
            foreach (var z in ages)
            {
                Console.WriteLine(z);
            }

            // var 是编译器确定类型
            //如 object obj = new { Name = "Chueng", Age = 21 };
            // console.WriteLine(obj.name) 编译不通过

            IEnumerable<Dog> dog = list.Select(e => new Dog { Nickname = e.Name, Age = e.Age });
            foreach (var d in dog)
            {
                Console.WriteLine($"{d.Nickname},{d.Age}");
            }
           

            var fin = list.GroupBy(e => e.Age).Select(g => new { Nianling = g.Key, MaxS = g.Max(e => e.Salary), MinS = g.Min(e => e.Salary), Count = g.Count() });
           
            foreach(var e in fin)
            {
                Console.WriteLine(e.Nianling + "," + e.MaxS + "," + e.MinS + "," + e.Count);
            }

            // toList  toArray

            // where select OrderBy GroupBy Take Skip
            // 返回的都是 IEnumerable<T> 类型
            // GroupBy : [(key,e)]
            // IEnumerable<IGrouping<int,Employee>>
            IEnumerable<Employee> data = list.Where(e => e.Salary > 6000);
            List<Employee> list2 = data.ToList();
            Employee[] list3 = data.ToArray();

            //获取id>2的数据 然后照age分组 并且把分组按照age排序 然后取出前3条 最后在投影去的年龄、人数、平均工资

            // 这语法糖甜死我了

            var person = list.Where(e => e.Id > 2).GroupBy(e => e.Age).OrderBy(g => g.Key).Take(3).Select(g => new { Age = g.Key, Count = g.Count(), avg = g.Average(g => g.Salary) });

            foreach (var p in person)
            {
                //Console.WriteLine(p.Age + p.Count + p.avg);
                Console.WriteLine(p);
            }
        }
    }

    class Dog
    {
        public string Nickname { get; set; } 
        public int Age { get;set; }
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