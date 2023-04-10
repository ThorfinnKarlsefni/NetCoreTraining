namespace di;

using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main(string[] args)
    {
        ServiceCollection service = new ServiceCollection();
        service.AddScoped<Controller>();
        service.AddScoped<ILog, LogImpl>();
        service.AddScoped<IStorage, StorageImpl>();
        service.AddScoped<IConfig, ConfigImpl>();
        using (var sp = service.BuildServiceProvider())
        {
            var c = sp.GetRequiredService<Controller>();
            c.Test();
        }

        Console.Read();
        
    }
}

class Controller
{
    private readonly ILog log;
    private readonly IStorage storage;

    public Controller(ILog log, IStorage storage)
    {
        this.log = log;
        this.storage = storage;
    }

    public void Test()
    {
        log.Log("开始上传");
        this.storage.Save("sadafsafa", "1.txt");
        log.Log("上传结束");
    }
}

interface ILog
{
    public void Log(string msg);
}

class LogImpl : ILog
{
    public void Log(string msg)
    {
        Console.WriteLine($"日志:{msg}");
    }
}

interface IConfig
{
    public string GetValue(string name);
}

class ConfigImpl:IConfig
{
    public string GetValue(string name)
    {
        return "Hello";
    }
}

interface IStorage
{
    public void Save(string content, string name);
}

class StorageImpl: IStorage
{
    // 降低模块之间耦合
    private readonly IConfig config;

    public StorageImpl(IConfig config)
    {
        this.config = config;
    }

    public void Save(string content,string name)
    {
        string server = config.GetValue("server");
        Console.WriteLine($"向服务器{server}的文件名为{name}上传{content}");
    }
}