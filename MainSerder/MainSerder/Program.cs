namespace MainSerder;
using Microsoft.Extensions.DependencyInjection;
using MailServices;
using ConfigServices;

class Program
{
    static void Main(string[] args)
    {
        ServiceCollection services = new ServiceCollection();
        // 注册服务

        // config
        services.AddScoped<IConfigService, EnvVarConfigService>();
        // services.AddScoped(typeof(IConfigService),s=>new FileConfigService {FilePath = "mail.ini"});
        services.ConsoleFileConfig("mail.ini");
        services.AddLayeredConfig();
        // mail server
        services.AddScoped<IMailService, MailService>();

        
        // 让服务变得更简单
        // 拓展方法 logs
        //services.AddScoped<ILogProvider, ConsoleProvider>();
        services.AddConsoleLog();
        using (var sp = services.BuildServiceProvider())
        {
            // 第一个根上的对象只能用 serviceLcaator
            var mailServer = sp.GetRequiredService<IMailService>();
            mailServer.Send("hello", "yr233@gmail.com", "cheung");
        }
        Console.Read();
    }
}