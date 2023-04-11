namespace MainSerder;
using Microsoft.Extensions.DependencyInjection;
using ConfigServices;
using MailServices;
using LogServices;

class Program
{
    static void Main(string[] args)
    {
        ServiceCollection services = new ServiceCollection();
        services.AddScoped<IConfigService,EnvVarConfigService>();
        services.AddScoped<IMailService, MailService>();
        services.AddScoped<ILogProvider, ConsoleProvider>();
        using (var sp = services.BuildServiceProvider())
        {
            // 第一个根上的对象只能用 serviceLcaator
            var mailServer = sp.GetRequiredService<IMailService>();
            mailServer.Send("hello", "yr233@gmail.com", "cheung");
        }
        Console.Read();
    }
}