namespace Configuration;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
class Program
{
    static void Main(string[] args)
    {
        ServiceCollection services = new ServiceCollection();
        services.AddScoped<TestWebConfig>();

        ConfigurationBuilder configBuilder = new ConfigurationBuilder();
        
        configBuilder.Add(new FxConfigSource() { Path="web.config"});
        IConfigurationRoot configRoot = configBuilder.Build();
        services.AddOptions().Configure<WebConfig>(e => configRoot.Bind(e));

        using (var sp = services.BuildServiceProvider())
        {
            var c = sp.GetRequiredService<TestWebConfig>();
            Console.WriteLine(c);
            c.Test();
        }

        Console.ReadKey();

            // read environment
            // add prefix
            configBuilder.AddEnvironmentVariables("TEST_");
        IConfigurationRoot ConfigRoot = configBuilder.Build();
        string Name = ConfigRoot["Name"];
        Console.WriteLine($"Name:{Name}");
        Console.ReadKey();

        // read command
        configBuilder.AddCommandLine(args);
        //IConfigurationRoot ConfigRoot = configBuilder.Build();
        string server = ConfigRoot["sever"];
        Console.WriteLine($"server:{server}");
        Console.Read();

        // read json
        // 注册服务
        configBuilder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //IConfigurationRoot ConfigRoot = configBuilder.Build();
        
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
                Console.WriteLine("可以改配置啦");
                Console.ReadKey();
            }
        }

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
    }
}

public class Config
{
    public string Name { get; set; }
    public int Age { get; set; }
    public Proxy Proxy { get; set; }
    
}

public class Proxy
{
    public string Address { get; set; }
    public int Port { get; set; }
}

