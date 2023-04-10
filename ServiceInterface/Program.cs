namespace ServiceInterface;

using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main(string[] args)
    {
        ServiceCollection services = new ServiceCollection();
        services.AddScoped<ITestService, TestServiceImpl>();
        services.AddScoped<ITestService, TestServiceImpl2>();
        //services.AddScoped(typeof(ITestService), typeof(TestServiceImpl));
        using (ServiceProvider sp = services.BuildServiceProvider())
        {
            // if not find,getService return null
            ITestService tes1 = sp.GetService<ITestService>();

            // if not find,throw exception
            // sp.GetRequiredService<ITestService>();

            // 显示转换抛异常 as转换return null
            //ITestService tes1 = (ITestService)sp.GetRequiredService<ITestService>();
            tes1.Name = "Cheung";
            tes1.SayHi();
            Console.WriteLine(tes1.GetType());
           
            //get services 实现多个服务
            IEnumerable <ITestService> tests = sp.GetServices<ITestService>();

            foreach (ITestService i in tests)
            {
                Console.WriteLine(i.GetType());
            }
            // 如果是多个服务 使用getservice返回最后一个
            var t = sp.GetService<ITestService>();
            Console.WriteLine(t);
            Console.ReadLine();
        }
    }
}


public interface ITestService
{
    public string Name { get; set; }
    public void SayHi();
}

public class TestServiceImpl : ITestService
{
    public string? Name { get; set; }

    public void SayHi()
    {
        Console.WriteLine($"hello,{Name}");
    }
}

public class TestServiceImpl2 : ITestService
{
    public string? Name { get; set; }

    public void SayHi()
    {
        Console.WriteLine($"hello,{Name}");
    }
}
