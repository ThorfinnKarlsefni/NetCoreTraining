namespace Configuration;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
class Program
{
    static void Main(string[] args)
    {

        ConfigurationBuilder configBuilder = new ConfigurationBuilder();
        
        configBuilder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        IConfigurationRoot ConfigRoot = configBuilder.Build();
        // Monitor 及时更新
        // Snapshot 在一个范围内 一次http请求
        // 建议使用 IOptionsSnashot
        ServiceCollection services = new ServiceCollection();
        services.AddScoped<Demo>();
        services.AddOptions().Configure<DbSettings>(e => ConfigRoot.GetSection("DB").Bind(e));
        services.AddOptions().Configure<SmtpSettings>(e => ConfigRoot.GetSection("Smtp").Bind(e));

        using (var sp = services.BuildServiceProvider())
        {
            Console.WriteLine(sp);
            while (true)
            {
                using (var scope = sp.CreateScope())
                {
                    var spScope = scope.ServiceProvider;
                    var demo = spScope.GetRequiredService<Demo>();
                    demo.Test();
                }
            }
            Console.WriteLine("可以改配置啦");
            Console.ReadKey();
        }
        /*
        string name = ConfigRoot["name"];
        Console.WriteLine(name);
        string address = ConfigRoot.GetSection("proxy:address").Value;
        Console.WriteLine(address);

        // create class
        // 映射对象
        Proxy proxy = ConfigRoot.GetSection("proxy").Get<Proxy>();
        Console.WriteLine($"{proxy.Address}");
        Console.WriteLine($"{proxy.Port}");

        // 映射config root
        Config config = ConfigRoot.Get<Config>();
        Console.WriteLine(config.Name);
        Console.WriteLine(config.Age);
        Console.WriteLine(config.Proxy.Address);
        Console.ReadKey();
        */

       

    }
}

class Config
{
    public string Name { get; set; }
    public int Age { get; set; }
    public Proxy Proxy { get; set; }
    
}

class Proxy
{
    public string Address { get; set; }
    public int Port { get; set; }
}

