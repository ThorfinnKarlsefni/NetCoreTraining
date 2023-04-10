namespace ioc;

using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main(string[] args)
    { 
        ServiceCollection serivices = new ServiceCollection();
        // transient return multiple class
        //serivices.AddTransient<TestServiceImpl>();

        // always be one
        //serivices.AddSingleton<TestServiceImpl>();

        // scope
        serivices.AddScoped<TestServiceImpl>();
        // 服务定位器
        using (ServiceProvider sp = serivices.BuildServiceProvider()) {
            TestServiceImpl t = sp.GetService<TestServiceImpl>();
            t.Name = "askeladd";
            t.SayHi();
            // transient
            // a new object is returnd each time
            TestServiceImpl t1 = sp.GetService<TestServiceImpl>();
            Console.WriteLine(object.ReferenceEquals(t, t1));
            // life cycle
            using (IServiceScope scope1 = sp.CreateScope())
            {
                // 给类构造函数中打印,看看不同生命周期的对象创建.使用serviceProvider.createScope() 创建scope
                // 如果一个类实现了IDisposable()接口, 则离开了作用域之后容器会自动调用对象的Dispose方法
                //不要在唱长生命周期的对象中引用比它短的生命周期对象,在net core中这样默认会抛出异常
                // 生命周期的选择如果类无状态.建议为singletion; 如果有状态且有scope控制 建议scpoed,因为通常这种scope控制下的代码都是运行在同一个线程中的 没有并发修改的问题;在使用transient的时候要谨慎

                // net 重载的方法很多
                // gets the associated object in scope,
                // scopel.serviceProvider instead of sp
                TestServiceImpl t2 = scope1.ServiceProvider.GetService<TestServiceImpl>();
                TestServiceImpl t3 = scope1.ServiceProvider.GetService<TestServiceImpl>();
                // false
                Console.WriteLine(object.ReferenceEquals(t, t2));
                // true
                Console.WriteLine(object.ReferenceEquals(t2, t3));
                
            }
        };
        Console.Read();

       

        //Console.WriteLine("Hello, World!");
        //TestServiceImpl test = new TestServiceImpl();
        //test.Name = "Cheung";
        //test.SayHi();
        //Console.Read();
    }
}

public interface ItesteService
{
    public string Name { get; set; }

    public void SayHi();
}

public class TestServiceImpl : ItesteService
{
    public string? Name { get; set; }

    public void SayHi()
    {
        Console.WriteLine($"hello,i am {Name}");
    }
}

