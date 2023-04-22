// See https://aka.ms/new-console-template for more information

using many_to_many;
using Microsoft.EntityFrameworkCore;

await using TestDbContext Db = new TestDbContext();

//Student s1 = new Student { Name = "Cheung"};
//Student s2 = new Student { Name = "jammy" };
//Student s3 = new Student { Name = "jerry" };

//Teacher t1 = new Teacher { Name = "ton"};
//Teacher t2 = new Teacher { Name = "honey" };
//Teacher t3 = new Teacher { Name = "mon" };
//s1.Teachers.Add(t1);
//s1.Teachers.Add(t2);

//s2.Teachers.Add(t2);
//s2.Teachers.Add(t3);

//s3.Teachers.Add(t1);
//s3.Teachers.Add(t2);
//s3.Teachers.Add(t3);

//Db.AddRange(s1, s2, s3);
//await Db.SaveChangesAsync();

foreach (var t in Db.Teachers.Include(s=>s.Students))
{
    Console.WriteLine($"老师{t.Name}");
    foreach (var s in t.Students)
    {
        Console.WriteLine($"----{s.Name}");
    }
}

Console.WriteLine("Hello, World!");
Console.Read();