namespace Configuration;

using System.Reflection;
using Microsoft.Extensions.Configuration;
class Program
{
    static void Main(string[] args)
    {
        ConfigurationBuilder configBuilder = new ConfigurationBuilder();
        
        configBuilder.AddJsonFile("config.json", optional: true, reloadOnChange: true);
        IConfigurationRoot ConfigRoot = configBuilder.Build();
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

